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
    }
    public void GoScene(string sceneName)
    {
        if (sceneName != null && sceneName != "")
        {
            SceneManager.LoadScene(sceneName.ToString());

        }
    }


    public void TakeScreenShot()
    {
        #region OLD
//        string paths = "";
//#if UNITY_STANDALONE_WIN || UNITY_EDITOR

//        paths = Application.dataPath + "/StreamingAssets";

//#endif
//#if UNITY_ANDROID
//        paths = Application.dataPath + "/StreamingAssets";
//        // paths = "jar:file:"+"//" + Application.dataPath + "!/assets";

//#endif
        #endregion

        ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/logo.jpg");
        StartCoroutine(SendMailNow());
    }
    IEnumerator SendMailNow()
    {
        yield return new WaitForSeconds(2);
        SendMailDemo.Instance.SendMailWithAttachment();

    }

}