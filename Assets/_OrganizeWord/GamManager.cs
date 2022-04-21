using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Organize_Word
{
    public class GamManager : MonoBehaviour
    {
        public Transform UnArrangedParent;
        public Transform ArrangedParent;
        public int currentWordNumber = 0;
        public int currentLevel = 0;
        public GameObject WinPanel;
        public GameObject GameOverPanel;
        float tempTime = 0.0f;
        public Image CurrentImage;
        public Sprite[] LevelsImages;
        public int maxLevel = 0;
        /*****************************************************************/
        public GameObject[] WordslevelsPanel;
        /*****************************************************************/
        public Text timerText;
        public Text winnerText;
        public float timeLeft = 30.0f;
        public string[] finalSentens;
        public int score = 0;
       public    bool canCount = true;
        public AudioSource audioSources;
        public AudioClip wrong, correct;
        private void Start()
        {
            currentWordNumber = 0;
           // scoreText.text = score + " Points";
            tempTime = timeLeft;
            // currentLevel = PlayerPrefs.GetInt("Level");
            if (maxLevel < currentLevel || LevelsImages.Length - 1 < currentLevel)
            {
                currentLevel = 0;
                print("hhh");
            }
            HideAllTheWordsAndShowCurrentWords();
            CurrentImage.sprite = LevelsImages[currentLevel];
            WordslevelsPanel[currentLevel].SetActive(true);
            ArrangedParent = WordslevelsPanel[currentLevel].transform.GetChild(0);
            UnArrangedParent = WordslevelsPanel[currentLevel].transform.GetChild(1);
        }
        public void OnClicImage(GameObject img)
        {
            if (!CheckIsHeIsRight(img))
            {
                //He Is un Correct
                // GameOver();
                audioSources.clip = wrong;
                audioSources.Play();
                img.GetComponent<Animator>().SetTrigger("go"); 

                return;
            }
            audioSources.clip = correct;
            audioSources.Play();
            if (img.transform.parent == ArrangedParent)
            {
                img.transform.parent = UnArrangedParent.transform;
            }
            else if (img.transform.parent == UnArrangedParent)
            {
                img.transform.parent = ArrangedParent.transform;
                img.GetComponent<Image>().color = new Color32(246, 146, 22, 255);
            }
            currentWordNumber++;
            if (CheckIfPlayerWin())
            {
                WinPanl();
            }
        }


        public bool CheckIsHeIsRight(GameObject img)
        {
            if (currentWordNumber == img.gameObject.GetComponent<WordNumber>().number)
            {
                return true;
            }
            return false;
        }
        public bool CheckIfPlayerWin()
        {
            if (UnArrangedParent.childCount <= 0)
            {
                audioSources.clip = correct;
                audioSources.Play();
                return true;
            }
            return false;
        }
        void GoMainMenu()
        {
            MyLevelManager.Instance.GoScene("MyMainMenu");
        }

        void Update()
        {
            if (canCount)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    GameOver();
                }
                timerText.text = (int)timeLeft + " Seconds";
            }
        }

        public void GameOver()
        {
            canCount = false;
            score = 0;
           // scoreText.text = score + " Points";
            GameOverPanel.SetActive(true);
            WinPanel.SetActive(false);
            ResetWordsInGameOver();
            timeLeft = tempTime + 9;
            currentWordNumber = 0;
            MyLevelManager.Instance.TakeScreenShot(finalSentens[currentLevel]);
            audioSources.clip = wrong;
            audioSources.Play();
        }
        public void WinPanl()
        {
            canCount = false;
            winnerText.text = finalSentens[currentLevel];
            WinPanel.SetActive(true);
            GameOverPanel.SetActive(false);
            score++;
            currentLevel++;
            audioSources.clip = correct;
            audioSources.Play();
            // scoreText.text = score + " Points";
            if (currentLevel >= maxLevel)
            {
                //Reach the final Question (repeat )
                Invoke("GoMainMenu", 1.5f);
                return;
            }
            else
            {
                StartCoroutine(SHoeNext());
            }
            MyLevelManager.Instance.TakeScreenShot(finalSentens[currentLevel]);

        }
        IEnumerator SHoeNext()
        {
            yield return new WaitForSeconds(2);
            Resting();
            // PlayerPrefs.SetInt("level", currentLevel);
            timeLeft = tempTime + 9;
            HideAllTheWordsAndShowCurrentWords();
            CurrentImage.sprite = LevelsImages[currentLevel];
            currentWordNumber = 0;
        }
        public void Resting()
        {
            canCount = true;
            timeLeft = tempTime;

            HideAllTheWordsAndShowCurrentWords();
            CurrentImage.sprite = LevelsImages[currentLevel];
            currentWordNumber = 0;
        }
        public void HideAllTheWordsAndShowCurrentWords()    
        {
            foreach (GameObject i in WordslevelsPanel)
            {
                i.SetActive(false);
            }
            WordslevelsPanel[currentLevel].SetActive(true);
            ArrangedParent = WordslevelsPanel[currentLevel].transform.GetChild(0);
            UnArrangedParent = WordslevelsPanel[currentLevel].transform.GetChild(1);
        }
        public void ResetWordsInGameOver()
        {
            Resting();
            for (int i = currentWordNumber - 1; i >= 0; i--)
            {
                ArrangedParent.GetChild(i).transform.SetParent(UnArrangedParent);
            }
        }

    }
}