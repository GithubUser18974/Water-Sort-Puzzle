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
using System;
namespace IndieSudioFTPEditors
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com
	///copyright © 2016 IGS. All rights reserved.
	public class UIExtension : MonoBehaviour
	{
		/// <summary>
		/// Set the size for the UI element.
		/// </summary>
		/// <param name="trans">The Rect transform referenced.</param>
		/// <param name="newSize">The New size.</param>
		public static void SetSize(RectTransform trans, Vector2 newSize)
		{
			Vector2 oldSize = trans.rect.size;
			Vector2 deltaSize = newSize - oldSize;
			trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
			trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
		}

		/// <summary>
		/// Find the game objects with tag.
		/// </summary>
		/// <returns>The game objects with tag(Sorted by name).</returns>
		/// <param name="tag">Tag.</param>
		public static GameObject[] FindGameObjectsWithTag(string tag)
		{
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
			Array.Sort(gameObjects, CompareGameObjects);
			return gameObjects;
		}

		/// <summary>
		/// Compares the game objects.
		/// </summary>
		/// <returns>The game objects.</returns>
		/// <param name="gameObject1">Game object1.</param>
		/// <param name="gameObject2">Game object2.</param>
		private static int CompareGameObjects(GameObject gameObject1, GameObject gameObject2)
		{
			return gameObject1.name.CompareTo(gameObject2.name);
		}

		/// <summary>
		/// Convert Integer value to custom string format.
		/// </summary>
		/// <returns>The to string.</returns>
		/// <param name="value">Value.</param>
		public static string IntToString(int value)
		{
			if (value < 10)
			{
				return "0" + value;
			}
			return value.ToString();
		}


		/// <summary>
		/// Play the one shot clip.
		/// </summary>
		/// <param name="audioClip">Audio clip.</param>
		/// <param name="postion">Postion.</param>
		/// <param name="volume">Volume.</param>
		public static void PlayOneShotClipAt(AudioClip audioClip, Vector3 postion, float volume)
		{
			if (audioClip == null || volume == 0)
			{
				return;
			}

			GameObject oneShotAudio = new GameObject("one shot audio");
			oneShotAudio.transform.position = postion;

			AudioSource tempAudioSource = oneShotAudio.AddComponent<AudioSource>(); //add an audio source
			tempAudioSource.clip = audioClip;//set the audio clip
			tempAudioSource.volume = volume;//set the volume
			tempAudioSource.loop = false;//set loop to false
			tempAudioSource.rolloffMode = AudioRolloffMode.Linear;//linear rolloff mode
			tempAudioSource.Play();// play audio clip
			GameObject.Destroy(oneShotAudio, audioClip.length); //destroy oneShotAudio gameobject after clip duration
		}
	}
}