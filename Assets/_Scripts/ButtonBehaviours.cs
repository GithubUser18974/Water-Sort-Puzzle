using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviours : MonoBehaviour
{
    public GameObject[] ToHideObjects;
    public GameObject[] ToShowObjects;

    public void ClickedIT(){
        foreach(GameObject i in ToHideObjects){i.SetActive(false);}
        foreach(GameObject i in ToShowObjects) {i.SetActive(true);}
        }

}
