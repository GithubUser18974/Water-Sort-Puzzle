using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sel {
public class SelManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip correct, wrong;
        public int A_1, A_2;
        public GameObject[] liness;
        public GameObject A, B;
        int current = -1;
        public int MaxItems=3;
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
                liness[a].SetActive(true);
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
    }
}
