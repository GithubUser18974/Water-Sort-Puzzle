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
namespace IndieSudioFTPEditors
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com
	///copyright © 2016 IGS. All rights reserved.
	public class GameObjectUtil
	{
		/// <summary>
		/// Finds the child by tag.
		/// </summary>
		/// <returns>The child by tag.</returns>
		/// <param name="p">parent.</param>
		/// <param name="childTag">Child tag.</param>
		public static Transform FindChildByTag(Transform theParent, string childTag)
		{
			if (string.IsNullOrEmpty(childTag) || theParent == null)
			{
				return null;
			}

			foreach (Transform child in theParent)
			{
				if (child.tag == childTag)
				{
					return child;
				}
			}

			return null;
		}
	}
}