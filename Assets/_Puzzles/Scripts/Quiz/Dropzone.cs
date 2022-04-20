/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEngine.EventSystems;
namespace LOL
{
    public class Dropzone : MonoBehaviour, IDropHandler
    {
        public string partAnswer;

        QuizManager parent;

        public void OnDrop(PointerEventData eventData)
        {
            GameObject dragObj = eventData.pointerDrag;
            parent = GameObject.FindGameObjectWithTag("Quiz Manager").GetComponent<QuizManager>();

            if (dragObj.tag == "Letter" &&
                compareAnswer(dragObj.GetComponent<LetterTile>().alphabetLetter))
            {
                dragObj.GetComponent<LetterTile>().setParentPos(this.transform);
            }
            else
                parent.PlaySound(false);
        }

        private bool compareAnswer(string a)
        {
            return partAnswer == a;
        }
    }
}