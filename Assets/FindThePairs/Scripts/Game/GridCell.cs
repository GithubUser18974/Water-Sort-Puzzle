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
namespace IndieSudioFTPEditors
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com
	///copyright © 2016 IGS. All rights reserved.
	[DisallowMultipleComponent]
	public class GridCell : MonoBehaviour
	{
		/// <summary>
		/// The index of the GridCell in the Grid.
		/// </summary>
		public int index;

		/// <summary>
		/// The pair ID.
		/// </summary>
		[HideInInspector]
		public int pairID;

		/// <summary>
		/// Whether the Grid Cell already used or not.
		/// </summary>
		public bool alreadyUsed;

		void Start()
		{
			GetComponent<Button>().onClick.AddListener(() => GameObject.FindObjectOfType<UIEvents>().GridCellButtonEvent(this));
		}
	}
}