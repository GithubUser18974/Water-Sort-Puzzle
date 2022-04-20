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
using System.Collections.Generic;
namespace LOL
{
	public class DotSequenceManager : GameParent
	{
		public Image clearImage;
		public AudioClip introSound, correctSound, wrongSound;
		public Transform levelParent;
		public CongratzUIButtonGroup congratzUI;
		public List<Sprite> backgroundList = new List<Sprite>();

		public int counter = 0;
		int bgIndex = 0;
		AudioSource source;
		ClearImageBehaviour image;

		/// inisialisasi atribute dan inisialisasi game
		void Start()
		{
			source = GetComponent<AudioSource>();
			image = transform.GetChild(0).GetComponent<ClearImageBehaviour>();

			GetComponent<Image>().sprite = backgroundList[bgIndex];
			bgIndex++;

			for (int i = 0; i < levelParent.childCount; i++)
			{
				levelParent.GetChild(i).GetComponent<DotParent>().parentList_id = i;
				levelParent.GetChild(i).GetComponent<DotParent>().setLineParent(transform.GetChild(1));
			}

			source.PlayOneShot(introSound);
			InitAlphabets();
		}
       
        public override void OnNextButtonClick()
		{
			counter++;
            if (counter > 10)
            {
				counter = 0;
            }
			congratzUI.OnActivatingUI(false);
			foreach (Transform t in transform.GetChild(1))
				Destroy(t.gameObject);

			InitAlphabets();
		}

		public override void OnPrevButtonClick()
		{
			counter--;
			if (counter <0)
			{
				counter = 0;
			}
			congratzUI.OnActivatingUI(false);
			foreach (Transform t in transform.GetChild(1))
				Destroy(t.gameObject);

			InitAlphabets();
		}

		protected override void InitAlphabets()
		{
			//DotParent parentProblem;

			GetComponent<Image>().sprite = backgroundList[bgIndex % backgroundList.Count];
			image.changeImage(counter);
			image.setClear();
			bgIndex++;

			foreach (Transform t in levelParent)
			{
				if (t.GetComponent<DotParent>().parentList_id == counter)
				{
					t.gameObject.SetActive(true);

					//                if (t.GetComponent<DotParent>() != null)
					//                    parentProblem = t.GetComponent<DotParent>();
				}
				else
				{
					t.gameObject.SetActive(false);
					//                parentProblem = null;
				}
			}
		}

		public void correctAnswer()
		{
			image.setVisible();
			playSound(true);
			Invoke("congrats", 0.5f);
		}

		public void playSound(bool a)
		{
			if (a)
				source.PlayOneShot(correctSound);
			else
				source.PlayOneShot(wrongSound);

			MyLevelManager.Instance.TakeScreenShot();

		}

		private void congrats()
		{
			congratzUI.OnActivatingUI(true);

		}

		public void GoHome()
		{
			MyLevelManager.Instance.GoScene("MyMainMenu");
		}
	}
}