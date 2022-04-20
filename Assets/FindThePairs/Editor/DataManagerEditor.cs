/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEditor;
using UnityEngine;

///Developed by Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieSudioFTPEditors
{
		[CustomEditor(typeof(DataManager))]
		public class DataManagerEditor : Editor
		{
			public override void OnInspectorGUI()
			{
				if (Application.isPlaying) {
					return;
				}
				DataManager attrib = (DataManager)target;//get the target
				EditorGUILayout.Separator ();
				attrib.fileName = EditorGUILayout.TextField ("File Name",attrib.fileName);
				attrib.serilizationMethod = (DataManager.SerilizationMethod)EditorGUILayout.EnumPopup ("Serilization Method",attrib.serilizationMethod);
		
				EditorGUILayout.Separator ();

				if (GUILayout.Button ("Explore File Folder", GUILayout.Width (120), GUILayout.Height (25))) {
					string path = null;
					#if UNITY_ANDROID
						path = DataManager.GetAndroidFileFolder();
					#elif UNITY_IPHONE
						path = DataManager.GetIPhoneFileFolder();
					#elif UNITY_WP8 || UNITY_WP8_1
						path = DataManager.GetWP8FileFolder();
					#else
						path = DataManager.GetOthersFileFolder();
					#endif
					if(path!=null){
						EditorUtility.RevealInFinder(path);
					}
				}
			}
		}
}
