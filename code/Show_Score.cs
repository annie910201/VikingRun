using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Score : MonoBehaviour
{
    public Text score;
    static public int scoreGet;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score : ";
        scoreGet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            scoreGet++;
        }
        
        score.text = "Score : "+scoreGet;
    }
}
