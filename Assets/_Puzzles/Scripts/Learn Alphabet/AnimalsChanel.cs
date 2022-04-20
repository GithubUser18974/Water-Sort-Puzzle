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
    /// Class yang meng-handle minigame Animals pada Learn to Read
    /// </summary>

    public class AnimalsChanel : GameParent
    {
        public Image animalImage;
        public Button tapForSound, prevButton, nextButton;
        public AudioSource animalSource;
        public Text animalName;
        public List<Sprite> backgroundList = new List<Sprite>();
        public List<AnimalGroup> animalGroupList = new List<AnimalGroup>();

        Image background;
        AudioSource source;
        Animator anim;

        void Start()
        {
            background = GetComponent<Image>();
            source = GetComponent<AudioSource>();
            anim = GetComponent<Animator>();
            InitAnimalGroup();
            InitAlphabets();
        }

        /// Method yang berguna untuk mengganti object sesuai dengan Huruf awalan Animal yang ada
        /// Method ini dipanggil pada setiap user menekan tombol Prev atau Next
        protected override void InitAlphabets()
        {
            animalName.text = animalGroupList[alphabetIndex].objectName;
            animalImage.sprite = animalGroupList[alphabetIndex].objectImage;
            background.sprite = animalGroupList[alphabetIndex].background;
            source.PlayOneShot(animalGroupList[alphabetIndex].narator);
            anim.SetTrigger("Fade in");
        }

        /// Method yang digunakan untuk inisialisasi setiap object Animal
        private void InitAnimalGroup()
        {
            for (int i = 0; i < animalGroupList.Count; i++)
            {
                //            animalGroupList[i].objectAlias = "Animal-" + animalGroupList[i].objectName[0];
                //            animalGroupList[i].textColor = new Color(0, 0, 0, 255);
                //            animalGroupList[i].narator = Resources.Load("Sounds/animal" + i) as AudioClip;
                //            animalGroupList[i].animalSound = Resources.Load("Sounds/Animal Sounds/anml" + i) as AudioClip;

                //method untuk mengganti background pada binatang tertentu.
                switch (i)
                {
                    case 2: animalGroupList[i].background = backgroundList[1]; break;
                    case 14: animalGroupList[i].background = backgroundList[2]; break;
                    case 22: animalGroupList[i].background = backgroundList[3]; break;
                    default: animalGroupList[i].background = backgroundList[0]; break;
                }
            }
        }

        public void playAnimalSound()
        {
            animalSource.PlayOneShot(animalGroupList[alphabetIndex].animalSound);
        }
    }
}