using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    public void GoTOHome()
    {
        MyLevelManager.Instance.GoScene("MyMainMenu");
    }
}
