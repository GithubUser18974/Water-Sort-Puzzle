/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections.Generic;
namespace LOL
{
	public class WritePanel : MonoBehaviour
	{
#if UNITY_EDITOR
		[ContextMenu("Get Beziers")]
		void GetBeziers()
		{
			if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
			{
				for (int i = writeManager.parentForLines.childCount - 1; i >= 0; i--)
				{
					DestroyImmediate(writeManager.parentForLines.GetChild(i).gameObject);
				}
				InitLines();
				for (int i = 0; i < lines.Count; i++)
				{
					lines[i].lineRef.gameObject.SetActive(true);
				}
			}
		}
#endif

		public WriteManager writeManager;
		public List<WriteLine> lines = new List<WriteLine>();

		public void InitLines()
		{
			lines.Clear();
			BezierSpline[] writeBezierSplines = GetComponentsInChildren<BezierSpline>(true);
			WriteLine wlT = null;
			for (int wi = 0; wi < writeBezierSplines.Length; wi++)
			{
				if (writeBezierSplines[wi].frequency > 0)
				{
					float stepSize = writeBezierSplines[wi].frequency;
					if (writeBezierSplines[wi].Loop || System.Math.Abs(stepSize - 1) < Mathf.Epsilon)
					{
						stepSize = 1f / stepSize;
					}
					else
					{
						stepSize = 1f / (stepSize - 1);
					}
					for (int f = 0; f < writeBezierSplines[wi].frequency; f++)
					{
						WriteLine wl = Instantiate<WriteLine>(writeManager.writeLine);
						wl.transform.SetParent(writeManager.parentForLines);
						wl.transform.localScale = Vector3.one;
						wl.rectTransform.position = writeBezierSplines[wi].GetPoint(f * stepSize);
						Vector3 len = writeBezierSplines[wi].GetPoint((f + 1) * stepSize) - wl.rectTransform.position;
						wl.rectTransform.sizeDelta = new Vector2(len.magnitude / wl.transform.lossyScale.x, 0);
						float a = Mathf.Atan2(-len.x, len.y) * Mathf.Rad2Deg + 90;
						wl.rectTransform.localEulerAngles = new Vector3(0, 0, a);
						wl.lineRef.gameObject.SetActive(false);
						if (f == 0)
						{
							wl.isSparate = true;
						}
						if (wlT)
						{
							wlT.nextArea = wl.gameObject;
						}
						wlT = wl;
						lines.Add(wl);
					}

				}
			}
		}

	}
}