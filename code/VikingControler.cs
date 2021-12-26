using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class VikingControler : MonoBehaviour//�u���~��monobehavior�~���@����
{
    public AudioClip audioclip1;
    AudioSource jumpMusic;
    public Rigidbody rb = new Rigidbody();//player
    bool run = false;//�ʵe���]�w
    Animator animator;//�ʵe
    bool goRight=false, goLeft=false;//�P�_A.D�O�_���U
    Vector3 velocity;//Ū���ثerb���t��
    float right_left_v=5f;//�a��/�k���t��
    float ahead_v=15;//�V�e�t��
    int deltaSec;//�p��g�L�ɶ�
    int y, w;//�P�_�����V
    void Start()
    {
        Debug.Log("Start");
        Transform t = GetComponent<Transform>();
        t.position = Vector3.one;//position�O����y�СAlocalposition�O�۹�y��(UI�����W)
        animator = GetComponent<Animator>();
        jumpMusic = this.GetComponent<AudioSource>();
    }

    /* �]�w�t�� */
    void setVelocityX(float v)
    {
        velocity = rb.velocity;
        velocity.x = v;
        rb.velocity = velocity;
    }
    void setVelocityZ(float v)
    {
        velocity = rb.velocity;
        velocity.z = v;
        rb.velocity = velocity;
    }
    void Update()
    {
        /* �t���H�ۮɶ��W�[ */
        deltaSec++;
        if (deltaSec % 1000 == 0&&deltaSec!=0)
            ahead_v++;
        Debug.Log("velocity:" + ahead_v);

        y = (int)(transform.rotation.y * 10);
        w= (int)(transform.rotation.w * 10);

        /* �@�}�l�]�w��FALSE */
        run = false;
        /* �a��/�k�� */
        if (Input.GetKey(KeyCode.LeftArrow)){//�a����
            if (y == 0)//0��
                setVelocityX(-right_left_v);
            else if (y == 10 || y == -10)//180��
                setVelocityX(right_left_v);
            else if ((y == 7 || y == -7) && y == w)//90��
                setVelocityZ(right_left_v);
            else if ((y == 7 || y == -7) && y == -w)//270��
                setVelocityZ(-right_left_v);
            run = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)){//�a�k��
            if (y == 0)//0��
                setVelocityX(right_left_v);
            else if (y == 10 || y == -10)//180��
                setVelocityX(-right_left_v);
            else if ((y == 7 || y == -7) && y == w)//90��
                setVelocityZ(-right_left_v);
            else if ((y == 7 || y == -7) && y == -w)//270��
                setVelocityZ(right_left_v);
            run = true;
        }

        /* �e�i+�������s */
        if (Input.GetKey(KeyCode.W))//�e�i
        {
            if (y == 0)//0��
                setVelocityZ(ahead_v);
            else if (y == 10 || y == -10)//180��
                setVelocityZ(-ahead_v);
            else if ((y == 7 || y == -7) && y == w)//90��
                setVelocityX(ahead_v);
            else if ((y == 7 || y == -7) && y == -w)//270��
                setVelocityX(-ahead_v);
            run = true;
        }
        
        /* ���D */
        if (Input.GetKeyDown(KeyCode.Space)&&rb.velocity.y==0)
        {
            velocity=rb.velocity;
            velocity.y = right_left_v;
            rb.velocity = velocity;
            run = true;
            jumpMusic.PlayOneShot(audioclip1);
        }
        animator.SetBool("run", run);
    }
    
    
    
}
