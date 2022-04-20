using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMainMenu : MonoBehaviour
{
    public string nameKid;
    public int age;
    
    public Text[] kidName_1;
    public Text GenderText;







    public GameObject Canvas_1;
    public GameObject Canvas_2;
        //private void Start()
        //{
        //    if (MyLevelManager.Instance.firstTime)
        //    {
        //        Canvas_1.SetActive(true);
        //        Canvas_2.SetActive(false);
        //    }
        //    else
        //    {
        //        Canvas_1.SetActive(false);
        //        Canvas_2.SetActive(true);
        //    }
        //}


    public void GoScene(string sceneName)
    {
        if (sceneName != null && sceneName != "")
        {
            MyLevelManager.Instance.GoScene(sceneName);

        }
    }
    public void SetAge(int agee)
    {
        age = agee;
        SendMailDemo.Instance.userData.age = agee+"";
        PlayerPrefs.SetInt("age", age);
    }
    public void SetName(InputField fields)
    {
        nameKid = fields.text;
        SendMailDemo.Instance.userData.name = nameKid;
        PlayerPrefs.SetString("name", nameKid);
        UpdateUI();
    }
    public void UpdateUI()
    {
        foreach (Text i in kidName_1)
        {
            i.text = nameKid;
        }
    }
    public void SetGender(string gend)
    {
        PlayerPrefs.SetString("gender", gend);
        SendMailDemo.Instance.userData.gender = gend;
        GenderText.text = gend;
    }
    GameObject temps;
    public void GoNextPanelWithTime(GameObject g)
    {
        temps = g;
        StartCoroutine(GoNextPanel());
    }
    IEnumerator GoNextPanel()
    {
        yield return new WaitForSeconds(2f);
        temps.SetActive(false);
    }
}
