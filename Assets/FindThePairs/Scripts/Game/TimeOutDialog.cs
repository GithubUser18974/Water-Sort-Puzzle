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
	public class TimeOutDialog : MonoBehaviour
	{
		/// <summary>
		/// TimeOut Dialog animator.
		/// </summary>
		public Animator timeOutDialogAnimator;

		/// <summary>
		/// The timeout dialog image.
		/// </summary>
		public Image timeOutDialogSpriteImage;


		// Use this for initialization
		void Awake()
		{
			///Setting up the references
			if (timeOutDialogAnimator == null)
			{
				timeOutDialogAnimator = GetComponent<Animator>();
			}

			if (timeOutDialogSpriteImage == null)
			{
				timeOutDialogSpriteImage = GetComponent<Image>();
			}
		}

		/// <summary>
		/// When the GameObject becomes visible
		/// </summary>
		void OnDisable()
		{
			///Hide the TimeOut Dialog
			Hide();
		}

		///Show the TimeOut Dialog
		public void Show()
		{
			if (timeOutDialogAnimator == null)
			{
				return;
			}
			timeOutDialogSpriteImage.enabled = true;
			timeOutDialogAnimator.SetTrigger("Running");
		}

		///Hide the TimeOut Dialog
		public void Hide()
		{
			if (timeOutDialogAnimator != null)
				timeOutDialogAnimator.SetBool("Running", false);
		}
	}
}