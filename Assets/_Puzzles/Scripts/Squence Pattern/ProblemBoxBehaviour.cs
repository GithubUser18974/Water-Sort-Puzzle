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
using UnityEngine.EventSystems;
using System.Collections;
using System;
namespace LOL
{
    public class ProblemBoxBehaviour : MonoBehaviour, IDropHandler
    {
        Text childText;
        bool isFilled = false;
        SquenceMasterControl parentScript;

        void Start()
        {
            if (transform.GetChild(0).GetComponent<Text>() != null)
                childText = transform.GetChild(0).GetComponent<Text>();

            parentScript = transform.parent.parent.GetComponent<SquenceMasterControl>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!isFilled && parentScript.answerCheck(eventData.pointerDrag.transform.GetChild(0).GetComponent<Text>().text))
            {
                //eventData.pointerDrag.GetComponent<LetterBehaviour>().setParentTo(this.transform);
                childText.text = eventData.pointerDrag.transform.GetChild(0).GetComponent<Text>().text;
                parentScript.setCorrectAnimation();
            }
            else
                parentScript.playWrongSound();
        }

        public void hasFilled(bool a)
        {
            isFilled = a;
        }
    }
}