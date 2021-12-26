using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    public static bool start = false;
    private void Start()
    {
        start = false;
    }
    public void OnPointerClick(PointerEventData e)
    {
        start = true;
        SceneManager.LoadScene(0);
    }

    
}
