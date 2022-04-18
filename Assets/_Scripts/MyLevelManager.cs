using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        public void GoScene(string  sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString()) ;
    }  
    }

