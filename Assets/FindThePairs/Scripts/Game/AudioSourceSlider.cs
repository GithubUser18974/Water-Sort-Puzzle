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
using UnityEngine.UI;
namespace IndieSudioFTPEditors
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com
	///copyright © 2016 IGS. All rights reserved.
	public class AudioSourceSlider : MonoBehaviour
	{
		/// <summary>
		/// The name of the audio source holder.
		/// </summary>
		public string audioSourceHolderName;
		[Range(0, 1)]
		/// <summary>
		/// The index of the audio source.
		/// </summary>
		public int audioSourceIndex;

		// Use this for initialization
		void Start()
		{
			if (string.IsNullOrEmpty(audioSourceHolderName))
			{
				return;
			}

			///Find the audio source holder
			GameObject auidoSourceHolder = GameObject.Find(audioSourceHolderName);
			if (auidoSourceHolder != null)
			{
				//Get the slider reference
				Slider slider = GetComponent<Slider>();
				if (slider != null)
				{
					AudioSource[] audioSources = auidoSourceHolder.GetComponents<AudioSource>();
					///Apply the volume of the audio source on the slider
					if (audioSourceIndex >= 0 && audioSourceIndex < audioSources.Length)
					{
						slider.value = audioSources[audioSourceIndex].volume;
					}
				}
			}
			else
			{
				Debug.Log("AudioSources holder is not found");
			}
		}
	}
}