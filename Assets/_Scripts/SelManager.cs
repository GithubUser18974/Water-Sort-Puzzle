using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sel {
public class SelManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip correct, wrong;
        public int A_1, A_2;
        public GameObject[] liness;
        public GameObject[] liness2;
        public GameObject A, B;
        int current = -1;
        public int MaxItems=3;
        int counter = 0;
        public enum Levels
        {
            Level_1,
            Level_2,
        }
        public Levels currLevel;
        private void Start()
        {
            currLevel = Levels.Level_1;
        }
        public void PlayCorrect()
        {
            audioSource.clip = correct;
            audioSource.Play();
        }
        public void PlayWrong()
        {
            audioSource.clip = wrong;
            audioSource.Play();
        }

        public void CheckTouch(GameObject g)
        {
            if (current==-1)
            {
                A_1 = g.gameObject.GetComponent<SelId>().ID;
                A = g;
                current = 1;
            }
            else if(current==1)
            {
                A_2 = g.gameObject.GetComponent<SelId>().ID;
                B = g;
                CheckNow(A_1, A_2);
            }
        }
        public void CheckNow(int a, int b)
        {
            if (a == -1 || b == -1)
            {
                return;
            }
            if (a == b)
            {
                Matched();
                counter++;
                if (counter >= MaxItems)
                {
                    if (currLevel == Levels.Level_2)
                    {
                       
                        Congeratulations();

                    }
                    else
                    {
                       // liness2[a].SetActive(true);
                        Congeratulations();
                    }
                   
                }
                else
                {
                    if (currLevel == Levels.Level_2)
                    {
                        liness2[a].SetActive(true);
                    }
                    else
                    {
                        liness[a].SetActive(true);

                    }

                }
            }
            else
            {
                NotMatched();
            }
            a = -1;
            b = -1;
            current = -1;
        }
        void Matched()
        {
            PlayCorrect();
            //A.SetActive(false);
            //B.SetActive(false);
        }
        void NotMatched()
        {
            PlayWrong();
        }
        void Congeratulations()
        {
            counter = 0;
            MaxItems = 4;
            CompletePanel.SetActive(true);
        }
        public GameObject lev_, Lev_2;
        public GameObject CompletePanel;
        public void NextLevel()
        {
            if (currLevel == Levels.Level_2)
            {
                currLevel = Levels.Level_1;
                myreset();
                lev_.SetActive(true);
                Lev_2.SetActive(false);
                CompletePanel.SetActive(false);
                MaxItems = 3;
                return;
            }
            lev_.SetActive(false);
            Lev_2.SetActive(true);
            CompletePanel.SetActive(false);
            currLevel = Levels.Level_2;

        }
        public void GoHome()
        {
            SceneManager.LoadScene("MyMainMenu");

        }
       void myreset()
        {
            foreach(GameObject i in liness)
            {
                i.SetActive(false);
            }
            foreach (GameObject i in liness2)
            {
                i.SetActive(false);
            }
            current = -1;
            counter = 0;

        }
    }
}
