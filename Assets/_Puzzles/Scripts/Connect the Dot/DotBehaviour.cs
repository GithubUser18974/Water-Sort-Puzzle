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
    public class DotBehaviour : MonoBehaviour, IPointerClickHandler
    {
        public int dot_ID = -1;
        public Sprite start, end;
        public DotStatus status;

        DotParent parent;

        public void Start()
        {
            parent = GetComponentInParent<DotParent>();
        }

        void Update()
        {
            if (status == DotStatus.isFree)
                GetComponent<Image>().sprite = end;
            else
                GetComponent<Image>().sprite = start;
        }

        public float getDistanceTo(Vector3 pos)
        {
            Vector2 from = new Vector2(transform.position.x, transform.position.y);
            Vector2 to = new Vector2(pos.x, pos.y);
            return Vector2.Distance(from, to);
        }

        public float getAngle(Vector3 tr)
        {
            Vector2 from = new Vector2(transform.position.x, transform.position.y);
            Vector2 to = new Vector2(tr.x, tr.y);

            return Mathf.Atan2(to.y - from.y, to.x - from.x) * Mathf.Rad2Deg;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            parent.createLine(this);
        }
    }

    public enum DotStatus
    {
        none = -1,
        isFree = 0,
        isFull = 1
    }
}