/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEditor;

///Developed by Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieSudioFTPEditors
{
		public class GridWindowEditor : EditorWindow
		{
				private Vector2 scrollPos;
				private static Level level;
				private static int numberOfRows, numberOfColumns;
				private static Level.Pair pair;
				private static Texture2D texture;
				private static int gridCellndex;
				private Vector2 offset = new Vector2 (0, 0);
				private Vector2 scale = new Vector2 (45, 45);
				private Vector2 scrollView = new Vector2 (550, 430);
				private static GridWindowEditor window;
				private static string levelTitle;

				public static void Init (Level lvl, string lvlTitle, int NOR, int NOC)
				{
						levelTitle = lvlTitle;
						numberOfRows = NOR;
						numberOfColumns = NOC;
						level = lvl;
						window = (GridWindowEditor)EditorWindow.GetWindow (typeof(GridWindowEditor));
						window.titleContent.text = levelTitle;
				}

				void OnGUI ()
				{
						if (window == null || Application.isPlaying) {
								return;
						}

						window.Repaint ();

						if (level == null) {
								return;
						}

						scrollView = new Vector2 (position.width, position.height);
						scrollPos = EditorGUILayout.BeginScrollView (scrollPos, GUILayout.Width (scrollView.x), GUILayout.Height (scrollView.y));

						GUILayout.Space (5);
						for (int i = 0; i < numberOfRows; i++) {

								GUILayout.BeginHorizontal ();
								GUILayout.Space (5);

								for (int j = 0; j < numberOfColumns; j++) {
										GUI.contentColor = Color.clear;
										gridCellndex = i * numberOfColumns + j;
										getGridCellTexture (gridCellndex);

										if (GUILayout.Button (texture, GUILayout.Width (scale.x), GUILayout.Height (scale.y))) {
												EditorUtility.DisplayDialog ("GridCell", "GridCell of index " + gridCellndex, "ok");
										}

										GUILayout.Space (offset.x);
								}
								GUILayout.EndHorizontal ();
								GUILayout.Space (offset.y);

								GUI.contentColor = Color.white;
								GUILayout.BeginHorizontal ();
								GUILayout.Space (5);
								for (int j = 0; j < numberOfColumns; j++) {
										gridCellndex = i * numberOfColumns + j;

										GUILayout.TextField (gridCellndex + "", GUILayout.Width (scale.x), GUILayout.Height (20));
										GUILayout.Space (offset.x);
								}
								GUILayout.EndHorizontal ();

						}
						EditorGUILayout.Separator ();
						EditorGUILayout.Separator ();
			
						EditorGUILayout.BeginHorizontal ();
						GUILayout.Space (scrollView.x / 2 - 50);
						GUI.contentColor = Color.yellow;
						EditorGUILayout.LabelField (numberOfRows + "x" + numberOfColumns + " Grid");
						GUI.contentColor = Color.white;
						EditorGUILayout.EndHorizontal ();
						EditorGUILayout.Separator ();

						EditorGUILayout.EndScrollView ();
				}

				private void getGridCellTexture (int gridCellndex)
				{
						texture = null;

						if (level == null) {
								return;
						}

						foreach (Level.Pair pair in level.pairs) {

								if (pair.firstElement.index == gridCellndex || pair.secondElement.index == gridCellndex) {
										
										GUI.contentColor = Color.white;

										if (pair.onClickSprite != null)
												texture = pair.onClickSprite.texture;
								}
						}
				}
		}
}
