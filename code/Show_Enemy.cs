using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Show_Enemy : MonoBehaviour
{
    public Text showEnemy;
    public Rigidbody rb;
    int distance;
    int sec;
    int stopToShowSec;
    int hitWall;
    // Start is called before the first frame update
    void Start()
    {
        hitWall = 0;
        distance = 10;
        sec = 0;
        stopToShowSec = 0;
        showEnemy.text = "The Enemy is about \n" + distance + " meters away from you\n";
    }

    // Update is called once per frame
    void Update()
    {
        if (distance != 0)
        {
            hitWall = PlayerPrefs.GetInt("die");
            if (hitWall==1)//¼²¨ìÀð
            {
                stopToShowSec++;
                showEnemy.text = "Hit Dead";
                if (stopToShowSec % 500 == 0&&stopToShowSec!=0)
                    SceneManager.LoadScene(1);
            }
            else if (rb.velocity.y < -10)
            {
                stopToShowSec++;
                showEnemy.text = "Fall to Death";
                if (stopToShowSec % 500 == 0 && stopToShowSec != 0)
                    SceneManager.LoadScene(1);
            }
                
            else
            {
                showEnemy.text = "The Enemy is about \n" + distance + " meters away from you\n";
                if (!Input.GetKey(KeyCode.W))
                    sec++;
                if (sec % 100 == 0 && sec != 0)
                    distance--;
            }
            
        }

        else if (distance == 0)
        {
            stopToShowSec++;
            showEnemy.text = "Enemy catch you already QQ";
            if (stopToShowSec %500== 0&&stopToShowSec!=0)
                SceneManager.LoadScene(1);
            
        }
    }
}
