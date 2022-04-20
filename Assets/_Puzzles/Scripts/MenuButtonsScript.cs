/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

/// <summary>
/// Script untuk setiap tombol pada menu Utama
/// </summary>
namespace LOL
{
	public class MenuButtonsScript : MonoBehaviour
	{

		void Start()
		{
			GameParent.alphabetIndex = 0;
		}

		void Update()
		{
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				Application.Quit();
			}
		}

		public void OnUpperButtonClick(int i)
		{
			switch (i)
			{
				case 1:
					{
						SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoRead;
						SubmenuControl.gotoScene = "Learn to Read";
						Application.LoadLevel("Submenu Select");
					}
					break;
				case 2:
					{
						SubmenuControl.menuType = SubmenuControl.SubMenuType.LearntoWrite;
						SubmenuControl.gotoScene = "Learn to Write";
						Application.LoadLevel("Submenu Select");
					}
					break;
				case 3:
					{
						SubmenuControl.menuType = SubmenuControl.SubMenuType.Pattern;
						SubmenuControl.gotoScene = "Patterns";
						Application.LoadLevel("Submenu Select");
					}
					break;
				default:
					break;
			}
			//randomChanceInterstitial();
		}

		public void OnLowerButtonClick(int i)
		{
			switch (i)
			{
				case 4:
					Application.LoadLevel("Find the Answer");
					break;
				case 5:
					Application.LoadLevel("Puzzle");
					break;
				case 6:
					Application.LoadLevel("Quiz");
					break;
			}
			//randomChanceInterstitial();
		}

		private void randomChanceInterstitial()
		{
			//		int rnd = Random.Range (0, 100);
			//		if (rnd >= 20)
			//			AdmobManager.RequestInterstitial ();
		}
	}
}