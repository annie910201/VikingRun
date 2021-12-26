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
        /* 向左右轉 */
        goLeft = Input.GetKeyDown(KeyCode.A);//是否按下向左轉的按鍵
        goRight = Input.GetKeyDown(KeyCode.D);//是否按下向右轉的按鍵

        if (goLeft)
            player.transform.Rotate(0, -90f, 0);
        if (goRight)
            player.transform.Rotate(0, 90f, 0);
    }
}
