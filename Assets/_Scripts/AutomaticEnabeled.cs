using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticEnabeled : MonoBehaviour
{
    public GameObject[] toShow;
    public GameObject[] toHide;
    public bool hasTime = false;
    public float time;
    private void OnEnable()
    {
        if (!hasTime)
        {
            Hidden();
        }
        else
        {
            Invoke("Hidden", time);
        }
    }
    public void Hidden()
    {
      
        foreach (GameObject i in toShow)
        {
            i.SetActive(true);
        }
        foreach (GameObject i in toHide)
        {
            i.SetActive(false);
        }
    }
}
