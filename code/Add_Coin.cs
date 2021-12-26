using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Coin : MonoBehaviour
{
    public GameObject coin;
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        Show_Money.moneyGet++;
        Debug.Log(Show_Money.moneyGet);
        Destroy(coin);
    }
}
