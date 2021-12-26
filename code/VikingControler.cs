using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class VikingControler : MonoBehaviour//只有繼承monobehavior才能當作物件
{
    public AudioClip audioclip1;
    AudioSource jumpMusic;
    public Rigidbody rb = new Rigidbody();//player
    bool run = false;//動畫的設定
    Animator animator;//動畫
    bool goRight=false, goLeft=false;//判斷A.D是否按下
    Vector3 velocity;//讀取目前rb的速度
    float right_left_v=5f;//靠左/右的速度
    float ahead_v=15;//向前速度
    int deltaSec;//計算經過時間
    int y, w;//判斷旋轉方向
    void Start()
    {
        Debug.Log("Start");
        Transform t = GetComponent<Transform>();
        t.position = Vector3.one;//position是絕對座標，localposition是相對座標(UI介面上)
        animator = GetComponent<Animator>();
        jumpMusic = this.GetComponent<AudioSource>();
    }

    /* 設定速度 */
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
        /* 速度隨著時間增加 */
        deltaSec++;
        if (deltaSec % 1000 == 0&&deltaSec!=0)
            ahead_v++;
        Debug.Log("velocity:" + ahead_v);

        y = (int)(transform.rotation.y * 10);
        w= (int)(transform.rotation.w * 10);

        /* 一開始設定為FALSE */
        run = false;
        /* 靠左/右走 */
        if (Input.GetKey(KeyCode.LeftArrow)){//靠左走
            if (y == 0)//0度
                setVelocityX(-right_left_v);
            else if (y == 10 || y == -10)//180度
                setVelocityX(right_left_v);
            else if ((y == 7 || y == -7) && y == w)//90度
                setVelocityZ(right_left_v);
            else if ((y == 7 || y == -7) && y == -w)//270度
                setVelocityZ(-right_left_v);
            run = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)){//靠右走
            if (y == 0)//0度
                setVelocityX(right_left_v);
            else if (y == 10 || y == -10)//180度
                setVelocityX(-right_left_v);
            else if ((y == 7 || y == -7) && y == w)//90度
                setVelocityZ(-right_left_v);
            else if ((y == 7 || y == -7) && y == -w)//270度
                setVelocityZ(right_left_v);
            run = true;
        }

        /* 前進+控制轉彎 */
        if (Input.GetKey(KeyCode.W))//前進
        {
            if (y == 0)//0度
                setVelocityZ(ahead_v);
            else if (y == 10 || y == -10)//180度
                setVelocityZ(-ahead_v);
            else if ((y == 7 || y == -7) && y == w)//90度
                setVelocityX(ahead_v);
            else if ((y == 7 || y == -7) && y == -w)//270度
                setVelocityX(-ahead_v);
            run = true;
        }
        
        /* 跳躍 */
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
