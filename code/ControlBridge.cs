using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class ControlBridge : MonoBehaviour
{
    public Transform path;
    public Transform triggerPath;
    Vector3 deltaPosition=new Vector3 (0f, 0f, 35f);
    Vector3 goPosition = new Vector3(0f, 0f, 20f);
    bool trigger = false;

    private void OnTriggerEnter(Collider player)
    {
        if (trigger)
            trigger = false;
        else
            trigger = true;
        if (trigger)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    Transform newGrass = Instantiate(triggerPath);
                    newGrass.localPosition = transform.position + goPosition * i + deltaPosition;
                }
                else
                {
                    Transform newGrass = Instantiate(path);
                    newGrass.localPosition = transform.position + goPosition * i + deltaPosition;
                }
            }
        }
    }
}
