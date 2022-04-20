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
	public class AudioSources : MonoBehaviour
	{

		/// <summary>
		/// The wanter bubble sound.
		/// </summary>
		public AudioClip waterBubbleSound;

		[HideInInspector]
		public AudioSource[] audioSources;

		/// <summary>
		/// The audio sources instance.
		/// </summary>
		public static AudioSources instance;

		// Use this for initialization
		void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
			audioSources = GetComponents<AudioSource>();
		}

		public void PlayWaterBubbleSound()
		{
			audioSources[1].clip = waterBubbleSound;
			audioSources[1].Play();
		}
	}
}