﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace DOTS
{
    public class PanelMain : MonoBehaviour
    {

        // game UI elements
        public Text btnStart, btnMore, btnReview;
        public GameObject title;
        public Toggle toggleMusic, toggleSFX;
        public Image mask;

        Scene levelC;
        // Use this for initialization
        void Start()
        {
            GameManager.getInstance().init();
            //		GameManager.getInstance ().hideBanner (true);
            //GameData.getInstance().cLevel = -1;
            fadeOut();

            GameObject.Find("maintitle").GetComponent<Text>().text = Localization.Instance.GetString("mainTitle");




            toggleMusic.isOn = GameData.getInstance().isSoundOn == 1 ? true : false;//0 is on
            toggleSFX.isOn = GameData.getInstance().isSfxOn == 1 ? true : false;

            //GameObject.Find ("btnStart").GetComponentInChildren<Text> ().text = Localization.Instance.GetString ("btnStart");
            //GameObject.Find ("btnMore").GetComponentInChildren<Text> ().text = Localization.Instance.GetString ("btnMore");
            //GameObject.Find ("btnReview").GetComponentInChildren<Text> ().text = Localization.Instance.GetString ("btnReview");

            //title.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("graphic/sprites/" + Localization.Instance.GetString ("titleImageName"));

            //GameManager.getInstance ().hideBanner (true);


            if (all_level != null) return;
            SceneManager.LoadScene("linkLevelMenu", LoadSceneMode.Additive);




        }
        public void GoScene(string names)
        {

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            MyLevelManager.Instance.GoScene(names);
        }
        GameObject all_level;//levelmenu container
        GameObject all_mainMenu;
        void OnEnable()
        {
            all_mainMenu = GameObject.Find("all_mainMenu");

        }




        // Update is called once per frame
        void Update()
        {
#if UNITY_IOS
//		GameManager.getInstance().hideBanner(true);
#endif
        }


        public GameObject panelShop, panelFade;
        /// <summary>
        /// process kind of click events
        /// </summary>
        /// <param name="g">The green component.</param>
        public void OnClick(GameObject g)
        {
            if (GameData.instance.isLock) return;
            switch (g.name)
            {
                case "btnStart":
                    GameManager.getInstance().playSfx("click");



                    if (GameData.instance.mode == 1)//this is always for test because you may not start from the initiate window.
                    {
                        fadeIn("linklevelMenu");

                    }
                    else
                    {
                        all_level = GameObject.Find("all_level");

                        all_level.transform.root.gameObject.SetActive(true);

                        GameData.instance.isLock = true;

                        all_level.transform.parent.GetComponent<LevelMenu>().refreshLevel();
                        all_level.transform.DOMoveX(all_level.transform.position.x - Screen.width, 1f).SetEase(Ease.OutBounce).OnComplete(() => { GameData.instance.currentScene = 1; });
                        all_mainMenu.transform.DOMoveX(all_mainMenu.transform.position.x - Screen.width, 1f).SetEase(Ease.OutBounce);
                    }
                    break;
                case "btnMore":
                    GameManager.getInstance().playSfx("click");
                    if (Application.platform == RuntimePlatform.WP8Player)
                    {
                        //				UnityPluginForWindowsPhone.Class1.moregame ();


                    }
                    else
                    {

#if (UNITY_IPHONE || UNITY_ANDROID)
                        Application.OpenURL("http://itunes.apple.com/WebObjects/MZSearch.woa/wa/search?submit=seeAllLockups&media=software&entity=software&term=xxxxxx");
#endif


                    }
                    break;
                case "btnReview":
                    GameManager.getInstance().playSfx("click");
                    //			UniRate.Instance.RateIfNetworkAvailable();
                    Application.OpenURL("itms-apps://ax.itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?type=Purple+Software&id = " + Const.appid);
                    break;
                case "btnShop":
                    GameManager.getInstance().playSfx("click");
                    panelShop.SetActive(true);
                    break;
                case "btnGC":
                    GameManager.getInstance().playSfx("click");
                    GameManager.getInstance().ShowLeaderboard();
                    break;
            }
        }



        /// <summary>
        /// process toggle button(music and sound effect buttons)
        /// </summary>
        /// <param name="toggle">Toggle.</param>
        public void OnToggle(Toggle toggle)
        {
            switch (toggle.gameObject.name)
            {
                case "ToggleMusic":
                    GameManager.getInstance().playSfx("click");
                    GameData.getInstance().isSoundOn = toggle.isOn ? 1 : 0;

                    if (toggle.isOn)
                    {
                        GameManager.getInstance().stopBGMusic();
                    }
                    else
                    {
                        GameManager.getInstance().playMusic("bgmusic");
                    }
                    PlayerPrefs.SetInt("sound", GameData.getInstance().isSoundOn);

                    break;
                case "ToggleSfx":
                    GameManager.getInstance().playSfx("click");
                    GameData.getInstance().isSfxOn = toggle.isOn ? 1 : 0;
                    if (toggle.isOn)
                    {
                        GameManager.getInstance().stopAllSFX();
                    }

                    PlayerPrefs.SetInt("sfx", GameData.getInstance().isSfxOn);
                    break;
            }
        }


        void fadeOut()
        {
            mask.gameObject.SetActive(true);
            mask.color = Color.black;
            //		mask.DOFade (0, 1).OnComplete (() => {
            //			mask.gameObject.SetActive (false);
            //		});
            ATween.ValueTo(mask.gameObject, ATween.Hash("from", 1, "to", 0, "time", 1, "onupdate", "OnUpdateTween", "onupdatetarget", this.gameObject, "oncomplete", "fadeOutOver", "oncompletetarget", this.gameObject));

        }

        void fadeIn(string sceneName)
        {
            if (mask.IsActive())
                return;
            mask.gameObject.SetActive(true);
            mask.color = new Color(0, 0, 0, 0);
            //		mask.DOFade (1, 1).OnComplete (() => {
            //			//			mask.gameObject.SetActive (false);
            //			SceneManager.LoadScene(sceneName);
            //		});
            ATween.ValueTo(mask.gameObject, ATween.Hash("from", 0, "to", 1, "time", 1, "onupdate", "OnUpdateTween", "onupdatetarget", this.gameObject, "oncomplete", "fadeInOver", "oncompleteparams", sceneName, "oncompletetarget", this.gameObject));

        }


        void fadeInOver(string sceneName)
        {
            if (sceneName.Contains("link"))
            {

            }
            else
            {
                string T = "link" + sceneName;
                sceneName = T;
            }
            SceneManager.LoadScene(sceneName);
        }

        void fadeOutOver()
        {
            mask.gameObject.SetActive(false);
        }

        /// <summary>
        /// tween update event
        /// </summary>
        /// <param name="value">Value.</param>
        void OnUpdateTween(float value)

        {

            mask.color = new Color(0, 0, 0, value);
        }
    }
}