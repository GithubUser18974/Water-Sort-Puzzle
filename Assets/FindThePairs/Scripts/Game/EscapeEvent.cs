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
using UnityEngine.SceneManagement;
namespace IndieSudioFTPEditors
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com
	///copyright © 2016 IGS. All rights reserved.

	/// <summary>
	/// Escape or Back event
	/// </summary>

	public class EscapeEvent : MonoBehaviour
	{
		/// <summary>
		/// The name of the scene to be loaded.
		/// </summary>
		public string sceneName;

		/// <summary>
		/// Whether to leave the application on escape click.
		/// </summary>
		public bool leaveTheApplication;

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				OnEscapeClick();
			}
		}

		/// <summary>
		/// On Escape click event.
		/// </summary>
		public void OnEscapeClick()
		{
			if (leaveTheApplication)
			{
				GameObject exitConfirmDialog = GameObject.Find("ExitConfirmDialog");
				if (exitConfirmDialog != null)
				{
					exitConfirmDialog.GetComponent<ConfirmDialog>().Show();
				}
			}
			else
			{
				StartCoroutine("LoadSceneAsync");
			}
		}

		/// <summary>
		/// Loads the scene Async.
		/// </summary>
		IEnumerator LoadSceneAsync()
		{
			if (!string.IsNullOrEmpty(sceneName))
			{
#if UNITY_PRO_LICENSE
					AsyncOperation async = SceneManager.LoadSceneAsync (sceneName);
					while (!async.isDone) {
						yield return 0;
					}
#else
				SceneManager.LoadScene(sceneName);
				yield return 0;
#endif
			}
		}
	}
}