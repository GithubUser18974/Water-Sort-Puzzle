/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEngine.EventSystems;
namespace LOL
{
	public class PuzzlePiece : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler
	{

		public bool isInteractable = true;
		public Vector3 posisiAwal;
		public PuzzlePanel puzzlePanel;
		public bool isInPlace
		{
			get
			{
				return Vector3.Distance(transform.localPosition, posisiAwal) < 1;
			}
		}
		Vector2 pivot;

		#region IHandler implementation
		public void OnBeginDrag(PointerEventData eventData)
		{
			pivot = transform.position;
			pivot = pivot - eventData.position;
			transform.SetAsLastSibling();
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (isInteractable)
			{
				transform.position = eventData.position + pivot;
				if (Vector3.Distance(transform.localPosition, posisiAwal) < puzzlePanel.puzzleManager.snapDistance)
				{
					transform.localPosition = posisiAwal;
				}
			}
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (isInteractable)
			{
				transform.position = eventData.position + pivot;
				if (Vector3.Distance(transform.localPosition, posisiAwal) < puzzlePanel.puzzleManager.snapDistance)
				{
					transform.localPosition = posisiAwal;
				}
				else
				{
					puzzlePanel.puzzleManager.PlayMockSound();
				}
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (isInteractable)
			{
				puzzlePanel.CheckPieces();
			}
		}

		#endregion

	}
}