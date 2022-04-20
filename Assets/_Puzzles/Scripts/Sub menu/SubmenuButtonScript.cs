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
namespace LOL
{
    /// <summary>
    /// Class yang dipasangkan pada setiap Tombol pada Submenu
    /// [Lihat Component pada setiap tombol untuk lebih lengkapnya]
    /// </summary>

    public class SubmenuButtonScript : MonoBehaviour
    {
        public int miniGameID;
        public Sprite spriteButton;
        public LayoutElement layout;

        SubmenuControl parent;

        void Start()
        {
            GetComponent<Image>().sprite = spriteButton;
            layout = GetComponent<LayoutElement>();
            parent = GameObject.FindGameObjectWithTag("Submenu Parent").GetComponent<SubmenuControl>();

            layout.preferredWidth = parent.getWidth();
            layout.preferredHeight = layout.preferredWidth / 5.2f;
        }

        public void OnButtonClick()
        {
            MiniGameMaster.id = miniGameID;
            Application.LoadLevel(SubmenuControl.gotoScene);

            //AdmobManager.bannerShow(true);
        }
    }
}