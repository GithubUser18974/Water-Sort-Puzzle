using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMainMenu : MonoBehaviour
{
    public string nameKid;
    public int age;

    public Text kidName_1;
    public Text kidName_2;
    public void SetAge(int agee)
    {
        age = agee;
        PlayerPrefs.SetInt("age", age);
    }
    public void SetName(InputField fields)
    {
        nameKid = fields.text;
        PlayerPrefs.SetString("name", nameKid);
        UpdateUI();
    }
    public void UpdateUI()
    {
        kidName_1.text = nameKid;
        kidName_2.text = nameKid;
    }
}
