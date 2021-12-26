using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Money : MonoBehaviour
{
    public Text money;
    static public int moneyGet;
    // Start is called before the first frame update
    void Start()
    {
        money.text= "";
        moneyGet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = moneyGet.ToString();
    }
}
