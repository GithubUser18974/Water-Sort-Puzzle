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
namespace LOL
{
	/// <summary>
	/// Class parent untuk Script utama pada hampir semua minigame
	/// </summary>

	public class GameParent : MonoBehaviour
	{
		public string backtoScene;

		[HideInInspector]
		public static string
			alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public static int alphabetIndex = 0;

		/// Jika user menekan tombol back, game akan 
		/// kembali pada menu sebelumnya
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
				BackToScene();
		}

		public virtual void BackToScene()
		{
			Application.LoadLevel(backtoScene);
		}

		public virtual void OnPrevButtonClick()
		{
			if (alphabetIndex == 0)
				alphabetIndex = 25;
			else
				alphabetIndex--;
			InitAlphabets();
		}

		public virtual void OnNextButtonClick()
		{
			if (alphabetIndex >= 25)
				alphabetIndex = 0;
			else
				alphabetIndex++;
			InitAlphabets();
		}

		protected virtual void InitAlphabets()
		{

		}

		protected char changeAlphabet()
		{
			return alphabet[alphabetIndex];
		}
	}
}