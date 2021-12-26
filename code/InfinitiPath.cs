using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class InfinitiPath : MonoBehaviour
{
    public Transform path;
    public Transform rightPath;
    public Transform leftPath;
    public Transform triggerPath;
    public Transform coin;
    public Transform newCoin;
    Transform newGrass;
    Transform newBar;
    public Transform bar;

    Vector3 locationY;
    Vector3 locationZ;
    Vector3 locationX;
    Vector3 basic_0degree;
    Vector3 basic_90degree;
    Vector3 basic_270degree;

    List<Transform> pathList;

    int y, w;
    int rand;
    bool trigger_ornot = false;
    private void Start()
    {
        locationY = new Vector3(0, -2, 0);
        locationZ = new Vector3(0, 0, 20);
        locationX = new Vector3(20, 0, 0);
        basic_0degree = new Vector3(-4.7f, 0, 27);
        basic_90degree = new Vector3(26.5f, 0, 5);
        basic_270degree = new Vector3(70f, 0, 5);
    }
    private void OnTriggerEnter(Collider player)
    {
        if (trigger_ornot)
            trigger_ornot = false;
        else
            trigger_ornot = true;
        if (trigger_ornot)
        {
            int coin_appear=Random.Range(1,5);
            int bar_appear = Random.Range(1, 4);
            int hole_appear = Random.Range(0, 100);
            Debug.Log(coin_appear);
            y = (int)(transform.rotation.y * 10);
            w = (int)(transform.rotation.w * 10);   
            for(int i = 1; i <= 5; i++)
            {
                if (i != 5)
                {
                    newGrass = Instantiate(path);
                    newGrass.rotation = transform.rotation;
                }
                if (i == coin_appear)
                {
                    int randomWidth = Random.Range(-6, 6);
                    if (y == 0)//0度
                        newCoin = Instantiate(coin, transform.position + locationZ * i + basic_0degree + locationY+new Vector3(randomWidth,0,0), transform.rotation);
                    else if (y == 10 || y == -10)//180度
                        newCoin = Instantiate(coin, transform.position - locationZ * i - basic_0degree + locationY + new Vector3(randomWidth, 0, 0), transform.rotation);
                    else if ((y == 7 || y == -7) && y == w)//90度
                        newCoin = Instantiate(coin, transform.position + locationX * i + basic_90degree + locationY + new Vector3(0, 0, randomWidth), transform.rotation);
                    else if ((y == 7 || y == -7) && y == -w)//270度
                        newCoin = Instantiate(coin, transform.position - locationX * i - basic_90degree + locationY + new Vector3(0, 0, randomWidth), transform.rotation);
                }
                if (i == bar_appear && i != coin_appear)
                {
                    if (y == 0)//0度
                        newBar = Instantiate(bar, transform.position + locationZ * i + basic_0degree+new Vector3(1,0.5f,0), transform.rotation);
                    else if (y == 10 || y == -10)//180度
                        newBar = Instantiate(bar, transform.position - locationZ * i - basic_0degree + new Vector3(-1, 0.5f, 0), transform.rotation);
                    else if ((y == 7 || y == -7) && y == w)//90度
                        newBar = Instantiate(bar, transform.position + locationX * i + basic_90degree + new Vector3(0, 0.5f, -1), transform.rotation);
                    else if ((y == 7 || y == -7) && y == -w)//270度
                        newBar = Instantiate(bar, transform.position - locationX * i - basic_90degree + new Vector3(0, 0.5f, 1), transform.rotation);
                }
                else if (i == 5)
                {
                    rand = Random.Range(0, 3);
                    if (rand == 0)
                        newGrass = Instantiate(triggerPath, transform.position, transform.rotation);
                    else if (rand == 1)
                        newGrass = Instantiate(rightPath,transform.position, transform.rotation);
                        
                    else if (rand == 2)
                        newGrass = Instantiate(leftPath, transform.position, transform.rotation);
                }
                if (hole_appear < 0){//不產生洞
                    if (y == 0)//0度
                        newGrass.position = transform.position + locationZ * i + basic_0degree;
                    else if (y == 10 || y == -10)//180度
                        newGrass.position = transform.position - locationZ * i - basic_0degree;
                    else if ((y == 7 || y == -7) && y == w)//90度
                        newGrass.position = transform.position + locationX * i + basic_90degree;
                    else if ((y == 7 || y == -7) && y == -w)//270度
                        newGrass.position = transform.position - locationX * i - basic_90degree;
                }
                else//產生洞
                {
                    Debug.Log("有洞欸");
                    if (y == 0)//0度
                        newGrass.position = transform.position + locationZ * i +new Vector3(0,0,5)+ basic_0degree;
                    else if (y == 10 || y == -10)//180度
                        newGrass.position = transform.position - locationZ * i- new Vector3(0, 0, 5) - basic_0degree;
                    else if ((y == 7 || y == -7) && y == w)//90度
                        newGrass.position = transform.position + locationX * i -new Vector3(5, 0, 0) + basic_90degree;
                    else if ((y == 7 || y == -7) && y == -w)//270度
                        newGrass.position = transform.position - locationX * i + new Vector3(5, 0, 0) - basic_90degree;
                }
                
            }   
        }
    }
    
}

