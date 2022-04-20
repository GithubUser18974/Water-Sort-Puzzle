/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
namespace LOL
{
    /// <summary>
    /// Class yang meng-handle minigame Letters
    /// </summary>
    public class AlphabetLetters : GameParent
    {
        public Button prevButton, nextButton;
        public Image upperCase, lowerCase;

        public List<AudioClip> UppercaseSound = new List<AudioClip>();
        public List<AudioClip> LowercaseSound = new List<AudioClip>();

        AudioSource audioSource;
        Text upperCaseText, lowerCaseText;
        Animator lowerAnim, upperAnim;

        // Use this for initialization
        void Start()
        {
            if (upperCase.transform.childCount != 0)
                upperCaseText = upperCase.transform.GetChild(0).GetComponent<Text>();
            if (lowerCase.transform.childCount != 0)
                lowerCaseText = lowerCase.transform.GetChild(0).GetComponent<Text>();

            upperAnim = upperCase.GetComponent<Animator>();
            lowerAnim = lowerCase.GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();

            InitAlphabets();
        }

        /// Method untuk meng-generate setiap huruf besar dan kecil setiap
        /// tombol Prev atau Next ditekan
        protected override void InitAlphabets()
        {
            upperCaseText.text = char.ToUpper(changeAlphabet()).ToString();
            lowerCaseText.text = char.ToLower(changeAlphabet()).ToString();

            Invoke("playUpperCase", 0.15f);
        }

        /// Method untuk memainkan animasi dan memainkan suara untuk Huruf besar
        private void playUpperCase()
        {

            upperAnim.SetTrigger("Activate");
            audioSource.PlayOneShot(UppercaseSound[alphabetIndex]);
            Invoke("playlowerCase", 1f);
        }

        /// Method untuk memainkan animasi dan memainkan suara untuk Huruf kecil
        private void playlowerCase()
        {
            lowerAnim.SetTrigger("Activate");
            audioSource.PlayOneShot(LowercaseSound[alphabetIndex]);
        }
    }
}