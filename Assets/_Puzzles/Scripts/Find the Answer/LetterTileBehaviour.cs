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

/// <summary>
/// Class yang meng-handle input dari user pada setiap tile yang digunakan sebagai
/// pilihan ganda pada minigame Find the Answer
/// </summary>
namespace LOL
{
    public class LetterTileBehaviour : MonoBehaviour
    {
        public Image wrongImage;
        public string alphabet { private set; get; }

        Image child;
        ObjectWord obj = new ObjectWord();
        ScrambleTheChoiceScript parent;

        /// method ini digunakan untuk meng-set value pada setiap tile mulai dari
        /// nama object, alphabet, gambar, sampai sound untuk jawaban benar
        public void setObj(ScrambleTheChoiceScript parent, ObjectWord a)
        {
            obj = a;
            this.parent = parent;

            gameObject.name = obj.objectName + " button";
            alphabet = obj.alphabet;
            GetComponent<Image>().sprite = obj.objectImage;
        }

        /// method ini dipanggil setiap user menekan tile untuk menjawab
        public void onTileClicked()
        {
            bool isCorrect = false;

            if (alphabet == ScrambleTheChoiceScript.alphabet[ScrambleTheChoiceScript.alphabetIndex].ToString())
            {
                parent.AnimationTrigger(obj);
                isCorrect = true;
            }
            else
            {
                CreateWrongIcon();
                isCorrect = false;
            }

            parent.playSound(isCorrect, obj.correctAnswer);
        }

        /// method yang dipanggil ketika user menjawab dengan jawaban yang salah
        /// method ini berguna untuk gambar silang merah akan muncul dan memainkan sound try again
        private void CreateWrongIcon()
        {
            child = Instantiate(wrongImage, transform.position, transform.rotation) as Image;
            child.transform.SetParent(transform);
            Invoke("DestroyWrongIcon", 1.5f);
        }

        private void DestroyWrongIcon()
        {
            Destroy(child.gameObject);
        }
    }
}