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
    public class AlphabetPhonic : GameParent
    {
        public Button prevButton, nextButton;
        public Image Letter, animalImage;
        public Text nameText;
        public List<AlphabetGroup> alphabetObjet = new List<AlphabetGroup>();

        Text LetterText;
        Animator anim;
        AudioSource source;

        // Use this for initialization
        void Start()
        {
            if (Letter.transform.childCount != 0)
                LetterText = Letter.transform.GetChild(0).GetComponent<Text>();

            source = GetComponent<AudioSource>();
            anim = GetComponent<Animator>();
            InitAlphabets();
        }

        protected override void InitAlphabets()
        {
            LetterText.text = char.ToUpper(changeAlphabet()) + "" + char.ToLower(changeAlphabet());

            anim.SetTrigger("Fade in");
            InitObject();
        }

        /// Method untuk meng-inisialisasi Nama, warna dari Tulisan Nama, Huruf besar dan kecil, gambar
        /// dan suara yang akan dimainkan untuk setiap object
        private void InitObject()
        {
            LetterText.text = alphabetObjet[alphabetIndex].objectAlias;
            nameText.text = alphabetObjet[alphabetIndex].objectName;
            nameText.color = alphabetObjet[alphabetIndex].textColor;
            animalImage.sprite = alphabetObjet[alphabetIndex].objectImage;
            source.PlayOneShot(alphabetObjet[alphabetIndex].narator);
        }
    }
}