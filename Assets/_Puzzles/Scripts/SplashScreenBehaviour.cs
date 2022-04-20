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
	public class SplashScreenBehaviour : MonoBehaviour
	{
		public AudioClip splashSound;
		public string goToScene;
		public AnimationCurve soundCurve;

		AudioSource source;

		void Start()
		{
			source = GetComponent<AudioSource>();
			source.clip = splashSound;
			source.Play();
			Sing.gm.ResetTime();
			Invoke("loadLevel", splashSound.length);
			Debug.Log("Tulaib");
		}

		void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				CancelInvoke();
				loadLevel();
			}
			source.volume = soundCurve.Evaluate(source.time / splashSound.length);
		}

		private void loadLevel()
		{
			Application.LoadLevel(goToScene);
		}
	}
}