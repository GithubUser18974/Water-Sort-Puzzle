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
	/// Script untuk meng-handle Submenu
	/// </summary>
	public class SubmenuControl : MonoBehaviour
	{
		public static string gotoScene;
		public Button submenuButton;
		public static SubMenuType menuType = SubMenuType.LearntoRead;
		public List<string> LearntoRead = new List<string>();
		public List<string> LearntoWrite = new List<string>();
		public List<string> Pattern = new List<string>();

		public enum SubMenuType
		{
			none = 0,
			LearntoRead = 1,
			LearntoWrite = 2,
			Pattern = 3
		}

		void Start()
		{
			GameParent.alphabetIndex = 0;

			if (menuType == 0)
				Application.LoadLevel(gotoScene);
			else
			{
				switch (menuType)
				{
					case SubMenuType.LearntoRead:
						ButtonCloning(LearntoRead);
						break;
					case SubMenuType.LearntoWrite:
						ButtonCloning(LearntoWrite);
						break;
					case SubMenuType.Pattern:
						ButtonCloning(Pattern);
						break;
				}
			}
			//AdmobManager.bannerShow(false);
		}

		/// Method untuk meng-clone Button Submenu sesuai dengan jumlah minigame
		/// pada menu awal yang telah dipilih oleh user
		private void ButtonCloning(List<string> buttonName)
		{
			Button temp;
			for (int i = 0; i < buttonName.Count; i++)
			{
				temp = Instantiate(submenuButton, transform.position, transform.rotation) as Button;
				temp.transform.SetParent(transform);
				temp.transform.GetChild(0).GetComponent<Text>().text = buttonName[i];
				temp.gameObject.name = buttonName[i] + " Button";

				temp.GetComponent<SubmenuButtonScript>().miniGameID = i;
			}
		}

		void Update()
		{
			if (Input.GetKeyUp(KeyCode.Escape))
				BackToScene();
		}

		public void BackToScene()
		{
			Application.LoadLevel(Application.loadedLevel - 1);
		}

		public float getWidth()
		{
			RectTransform temp = GetComponent<RectTransform>();
			return (temp.anchorMax.x - temp.anchorMin.x) * Screen.width;
		}
	}
}