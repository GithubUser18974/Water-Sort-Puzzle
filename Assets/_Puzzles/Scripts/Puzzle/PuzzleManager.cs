/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System;
namespace LOL
{
	public class PuzzleManager : GameParent
	{

#if UNITY_EDITOR
		[ContextMenu("Ambil Puzzle")]
		void AmbilPosisi()
		{
			if (puzzlePanels != null && puzzlePanels.Length > 0)
			{
				Array.Resize<PuzzlePanel>(ref puzzlePanels, transform.childCount);
			}
			else
			{
				puzzlePanels = new PuzzlePanel[transform.childCount];
			}
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform ttt = transform.GetChild(i);
				PuzzlePanel ppp;
				if (!(ppp = ttt.gameObject.GetComponent<PuzzlePanel>()))
				{
					ppp = ttt.gameObject.AddComponent<PuzzlePanel>();
				}
				ppp.puzzleManager = this;
				puzzlePanels[i] = ppp;
			}
		}
#endif

		public float snapDistance = 50;
		public PuzzlePanel[] puzzlePanels;
		public CongratzUIButtonGroup congratsUI;
		public AudioClip beginSound;
		public AudioClip cringSound;
		public AudioClip[] compliSound;
		public AudioClip mockSound;

		protected override void InitAlphabets()
		{
			for (int i = 0; i < puzzlePanels.Length; i++)
			{
				puzzlePanels[i].gameObject.SetActive(false);
			}
			puzzlePanels[alphabetIndex].gameObject.SetActive(true);
		}

		public override void OnNextButtonClick()
		{
			base.OnNextButtonClick();
			congratsUI.OnActivatingUI(false);
		}

		public override void OnPrevButtonClick()
		{
			base.OnPrevButtonClick();
			congratsUI.OnActivatingUI(false);
		}

		public void PlayCompliSound()
		{
			Invoke("PlayPrivCompli", 1);
			PlaySound(cringSound);
		}

		void PlayPrivCompli()
		{
			PlaySound(compliSound[UnityEngine.Random.Range(0, compliSound.Length)]);
		}

		public void PlayMockSound()
		{
			PlaySound(mockSound);
		}

		void PlaySound(AudioClip ac)
		{
			if (ac)
			{
				AudioSource.PlayClipAtPoint(ac, Vector3.zero);
			}
		}

		void Start()
		{
			PlaySound(beginSound);
			InitAlphabets();
		}
	}
}