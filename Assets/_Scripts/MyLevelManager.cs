using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MyLevelManager Instance;
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
        firstTime = false;
    }
   
    public void GoScene(string sceneName)
    {
        if (sceneName != null && sceneName != "")
        {
            SceneManager.LoadScene(sceneName.ToString());

        }
    }

    public bool firstTime = true;
    public void TakeScreenShot()
    {


        ScreenCapture.CaptureScreenshot("logo.jpg");
        StartCoroutine(SendMailNow());
    }
    public void TakeScreenShot(string levelName)
    {

        SendMailDemo.Instance.userData.level = levelName;
        ScreenCapture.CaptureScreenshot("logo.jpg");
        StartCoroutine(SendMailNow());
    }
    IEnumerator SendMailNow()
    {
        yield return new WaitForSeconds(2);
        SendMailDemo.Instance.SendMailWithAttachment();

    }

}