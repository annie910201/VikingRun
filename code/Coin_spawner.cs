using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_spawner : MonoBehaviour
{
    public Transform coin;
    public Vector3 distance = new Vector3(0.4f, 0f, 1.9f);
    Transform c;
    int sec = 0;
    void Start()
    {
        
    }
    private void Update()
    {
        sec = 0;
        if (sec < 5)
        {
            c = Instantiate(coin);
            c.parent = transform;
            c.position = transform.position + distance*sec;
        }
        
    }


}
