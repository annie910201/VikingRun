using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_Path : MonoBehaviour
{
    public GameObject path;
    // Start is called before the first frame update
    void Start()
    {
        path = gameObject;
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider player)
    {
        Destroy(path);
    }
   
}
