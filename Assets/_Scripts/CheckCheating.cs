using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCheating : MonoBehaviour
{
    public static CheckCheating Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
 
    string url = "https://raw.githubusercontent.com/mohamedaraby122/Validations/master/KidGame.json";
    void Start()
    {
        _1();
    }
    public void _1()
    {
        StartCoroutine(StartUrl());

    }
    IEnumerator _2()
    {
        yield return new WaitForSeconds(60);
        _1();
    }
    IEnumerator StartUrl()
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            string s = www.text;
            if (s.Contains("false"))
            { transform.GetChild(0).gameObject.SetActive(true); }
            
        }
    }
}
