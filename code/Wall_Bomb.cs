using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall_Bomb : MonoBehaviour
{
    Transform wall;
    int die;
    // Start is called before the first frame update
    void Start()
    {
        wall = transform;
        die = 0;
        PlayerPrefs.SetInt("die", die);
    }

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("bomb");
        die = 1;
        PlayerPrefs.SetInt("die",die);
    }
}
