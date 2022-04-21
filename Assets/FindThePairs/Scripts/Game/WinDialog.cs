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
	[DisallowMultipleComponent]
	public class WinDialog : MonoBehaviour
	{
		/// <summary>
		/// Number of stars for the WinDialog.
		/// </summary>
		private TableLevel.StarsNumber starsNumber;

		/// <summary>
		/// Star sound effect.
		/// </summary>
		public AudioClip starSoundEffect;

		/// <summary>
		/// Win dialog animator.
		/// </summary>
		public Animator winDialogAnimator;

		/// <summary>
		/// The win dialog image.
		/// </summary>
		public Image winDialogSpriteImage;

		/// <summary>
		/// First star fading animator.
		/// </summary>
		public Animator firstStarFading;

		/// <summary>
		/// Second star fading animator.
		/// </summary>
		public Animator secondStarFading;

		/// <summary>
		/// Third star fading animator.
		/// </summary>
		public Animator thirdStarFading;

		// Use this for initialization
		void Awake()
		{
			///Setting up the references
			if (winDialogAnimator == null)
			{
				winDialogAnimator = GetComponent<Animator>();
			}

			if (winDialogSpriteImage == null)
			{
				winDialogSpriteImage = GetComponent<Image>();
			}

			if (firstStarFading == null)
			{
				firstStarFading = GameObject.Find("FirstStarFading").GetComponent<Animator>();
			}

			if (secondStarFading == null)
			{
				secondStarFading = GameObject.Find("SecondStarFading").GetComponent<Animator>();
			}

			if (thirdStarFading == null)
			{
				thirdStarFading = GameObject.Find("ThirdStarFading").GetComponent<Animator>();
			}
		}

		/// <summary>
		/// When the GameObject becomes visible
		/// </summary>
		void OnEnable()
		{
			///Hide the Win Dialog
			Hide();
		}

		/// <summary>
		/// Show the Win Dialog.
		/// </summary>
		public void Show(TableLevel.StarsNumber starsNumber)
		{
			this.starsNumber = starsNumber;
			if (winDialogAnimator == null)
			{
				return;
			}
			winDialogSpriteImage.enabled = true;
			winDialogAnimator.SetTrigger("Running");
			MyLevelManager.Instance.TakeScreenShot();
		}

		/// <summary>
		/// Hide the Win Dialog.
		/// </summary>
		public void Hide()
		{
			StopAllCoroutines();
			winDialogAnimator.SetBool("Running", false);
			firstStarFading.SetBool("Running", false);
			secondStarFading.SetBool("Running", false);
			thirdStarFading.SetBool("Running", false);
		}

		/// <summary>
		/// Fade stars Coroutine.
		/// </summary>
		/// <returns>The stars.</returns>
		public IEnumerator FadeStars()
		{
			float delayBetweenStars = 0.5f;
			if (starsNumber == TableLevel.StarsNumber.ONE)
			{//Fade with One Star
				AudioSource.PlayClipAtPoint(starSoundEffect, Vector3.zero);
				firstStarFading.SetTrigger("Running");
			}
			else if (starsNumber == TableLevel.StarsNumber.TWO)
			{//Fade with Two Star
				AudioSource.PlayClipAtPoint(starSoundEffect, Vector3.zero);
				firstStarFading.SetTrigger("Running");
				yield return new WaitForSeconds(delayBetweenStars);
				AudioSource.PlayClipAtPoint(starSoundEffect, Vector3.zero);
				secondStarFading.SetTrigger("Running");
			}
			else if (starsNumber == TableLevel.StarsNumber.THREE)
			{//Fade with Three Star
				AudioSource.PlayClipAtPoint(starSoundEffect, Vector3.zero);
				firstStarFading.SetTrigger("Running");
				yield return new WaitForSeconds(delayBetweenStars);
				AudioSource.PlayClipAtPoint(starSoundEffect, Vector3.zero);
				secondStarFading.SetTrigger("Running");
				yield return new WaitForSeconds(delayBetweenStars);
				AudioSource.PlayClipAtPoint(starSoundEffect, Vector3.zero);
				thirdStarFading.SetTrigger("Running");
			}
			yield return 0;
		}

	}
}