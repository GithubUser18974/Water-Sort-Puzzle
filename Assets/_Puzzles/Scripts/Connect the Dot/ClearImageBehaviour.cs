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
    public class ClearImageBehaviour : MonoBehaviour
    {
        public List<Sprite> clearImageList = new List<Sprite>();

        Image image;

        void Awake()
        {
            image = GetComponent<Image>();
        }

        public void setClear()
        {
            image.color = new Color(255, 255, 255, .001f);
        }

        public void setVisible()
        {
            image.color = new Color(255, 255, 255, 1);
        }

        public void changeImage(int id)
        {
            image.sprite = clearImageList[id];
            setClear();
        }

        public void debugColor()
        {
            Debug.Log(image.color);
        }
    }
}