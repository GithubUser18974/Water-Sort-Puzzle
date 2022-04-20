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
namespace LOL
{
    /// <summary>
    /// script class behaviour untuk drag and drop tile
    /// </summary>
    public class LetterTile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public string alphabetLetter;
        Transform parentPos;
        QuizManager manager;

        void Start()
        {
            manager = GameObject.FindGameObjectWithTag("Quiz Manager").GetComponent<QuizManager>();
            transform.GetChild(0).GetComponent<Text>().text = alphabetLetter;
        }

        public void setParentPos(Transform tr)
        {
            parentPos = tr;
            GetComponent<CanvasGroup>().interactable = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            parentPos = transform.parent;
            transform.SetParent(parentPos.parent);

            QuizManager.state = InputState.isHold;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            transform.SetParent(parentPos);
            transform.position = parentPos.position;

            QuizManager.state = InputState.isFree;
            manager.PopupActive();
        }
    }
}