﻿using UnityEngine;
using System.Collections;
using alphabet;

///Developed by Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DirtyUtil
{
		public static void MarkSceneDirty ()
		{
			#if UNITY_5 && UNITY_EDITOR
				if(!EditorApplication.isSceneDirty){
					EditorApplication.MarkSceneDirty(); 
				}
			#endif
		}
}