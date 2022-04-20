/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
namespace LOL
{
	public class GameManager : MonoBehaviour
	{



		public string loadedLevelNameForAd;
		public float adDelay = 120;
		float curTimePlusDelay;

		bool isTimeUp
		{
			get
			{
				return Time.unscaledTime > curTimePlusDelay;
			}
		}

		public void ResetTime()
		{
			curTimePlusDelay = Time.unscaledTime + adDelay;
		}

		void RequestInterstitialAd()
		{
		}

		void OnIntersLoaded(object o, System.EventArgs args)
		{
			Debug.Log(" intersitialnya wes di load");
		}



		void OnIntersOpening(object o, System.EventArgs args)
		{
			Debug.Log(" intersitialnya lagi di bukak");
		}

		void OnIntersClosed(object o, System.EventArgs args)
		{
			Debug.Log(" intersitialnya wes di tutup");
		}

		void OnIntersLeaving(object o, System.EventArgs args)
		{
			Debug.Log(" intersitialnya metu soko aplikasi");
		}

		void Start()
		{
			RequestInterstitialAd();
			ResetTime();
		}

		void OnLevelWasLoaded(int level)
		{
			Debug.Log(Application.loadedLevelName + "Telah di load");
			if (Application.loadedLevelName == loadedLevelNameForAd)
			{
				if (isTimeUp)
				{
					RequestInterstitialAd();
					ResetTime();
				}
			}
		}
	}
}