/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using UnityEngine;
namespace LOL
{
	public static class Sing
	{
		static GameManager _gm;
		public static GameManager gm
		{
			get
			{
				return _gm;
			}
		}

		[RuntimeInitializeOnLoadMethod]
		static void Bind()
		{
		}

		static Sing()
		{
			GameManager[] managers = UnityEngine.Object.FindObjectsOfType<GameManager>();
			if (managers.Length != 0)
			{
				for (int i = 1; i < managers.Length; i++)
				{
					UnityEngine.Object.Destroy(managers[i].gameObject);
				}
				_gm = managers[0];
			}
			else
			{
				GameManager gem = Resources.Load<GameManager>("GameManager");
				if (gem)
				{
					_gm = UnityEngine.Object.Instantiate<GameManager>(gem);
				}
				if (!_gm)
				{
					GameObject gO = new GameObject(typeof(GameManager).Name);
					_gm = gO.AddComponent<GameManager>();
				}
			}
			_gm.gameObject.name = typeof(GameManager).Name;
			UnityEngine.Object.DontDestroyOnLoad(_gm.gameObject);
		}

	}

}