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
using System;
namespace IndieSudioFTPEditors
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com
	///copyright © 2016 IGS. All rights reserved.
	[DisallowMultipleComponent]
	public class TableLevel : MonoBehaviour
	{
		/// <summary>
		/// The selected level.
		/// </summary>
		public static TableLevel selectedLevel;

		/// <summary>
		/// Table Level ID.
		/// </summary>
		public int ID = -1;

		/// <summary>
		/// The stars number(Rating).
		/// </summary>
		public StarsNumber starsNumber = StarsNumber.ZERO;

		// Use this for initialization
		void Start()
		{
			///Add on click listener
			GetComponent<Button>().onClick.AddListener(() => GameObject.FindObjectOfType<UIEvents>().LevelButtonEvent(this));

			///Setting up the ID for Table Level
			if (ID == -1)
			{
				string[] tokens = gameObject.name.Split('-');
				if (tokens != null)
				{
					ID = int.Parse(tokens[1]);
				}
			}

			///Setting up the Title for Table Level
			GameObject leveTitleGameObject = transform.Find("LevelTitle").gameObject;//Find LevelTitle GameObject
			if (leveTitleGameObject != null)
			{
				TextMesh textMeshComponent = leveTitleGameObject.GetComponent<TextMesh>();//Get LevelTitle Text Mesh Component
				if (textMeshComponent != null)
				{
					if (string.IsNullOrEmpty(textMeshComponent.text))
					{
						textMeshComponent.text = ID.ToString();//Set the Title as the ID
					}
				}
			}
		}

		public enum StarsNumber
		{
			ZERO,
			ONE,
			TWO,
			THREE
		}
	}
}