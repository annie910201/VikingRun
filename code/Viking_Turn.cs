using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking_Turn : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject floor;
    public Rigidbody rb;
    bool goLeft, goRight;
    void Start()
    {
        floor = gameObject;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider player)
    {
        /* �V���k�� */
        goLeft = Input.GetKeyDown(KeyCode.A);//�O�_���U�V���઺����
        goRight = Input.GetKeyDown(KeyCode.D);//�O�_���U�V�k�઺����

        if (goLeft)
            player.transform.Rotate(0, -90f, 0);
        if (goRight)
            player.transform.Rotate(0, 90f, 0);
    }
}
