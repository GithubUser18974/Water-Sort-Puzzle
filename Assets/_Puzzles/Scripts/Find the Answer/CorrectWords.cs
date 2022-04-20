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
using System.Collections.Generic;

/// <summary>
/// Class untuk menyimpan beberapa object dari ObjectWord.
/// Digunakan untuk meng-sortir beberapa object yang memiliki awalan yang sama
/// </summary>
namespace LOL
{
    [System.Serializable]
    public class CorrectWords
    {
        public string alphabet;
        public List<ObjectWord> correctWords = new List<ObjectWord>();

        public CorrectWords()
        {
            alphabet = "";
            correctWords = new List<ObjectWord>();
        }
    }
}