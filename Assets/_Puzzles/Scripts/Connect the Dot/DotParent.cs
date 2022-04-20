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
using System.Collections;
using System.Collections.Generic;
namespace LOL
{
    public class DotParent : MonoBehaviour
    {
        public int parentList_id = -1;
        public Image lineConnector;
        public Transform lineParent;
        public static int currentID = -1;
        public DotSequenceManager parent;

        List<DotBehaviour> dotList = new List<DotBehaviour>();

        // Use this for initialization
        void Awake()
        {
            currentID = 1;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<DotBehaviour>().dot_ID = i;
                transform.GetChild(i).name = "Dot " + (i + 1).ToString();
                transform.GetChild(i).GetChild(0).GetComponent<Text>().text = (i + 1).ToString();

                dotList.Add(transform.GetChild(i).GetComponent<DotBehaviour>());
            }
            setAlph();
            dotList[0].status = DotStatus.isFull;
        }

        public void createLine(DotBehaviour dot)
        {
            DotBehaviour startLine = dotList[dot.dot_ID - 1];

            if (dot.dot_ID == currentID && dot.status == DotStatus.isFree)
            {
                Image temp = Instantiate(lineConnector) as Image;
                temp.transform.position = startLine.transform.position;
                temp.transform.Rotate(new Vector3(0, 0, startLine.getAngle(dot.transform.position)));
                temp.rectTransform.sizeDelta = new Vector2(startLine.getDistanceTo(dot.transform.position), 5);

                temp.name = "Line from " + startLine.dot_ID + " to " + dot.dot_ID;
                temp.transform.SetParent(lineParent);
                dot.status = DotStatus.isFull;

                currentID++;
            }
            else
            {
                parent.playSound(false);
            }

            if (currentID == transform.childCount)
                parent.correctAnswer();
        }

        private void setAlph()
        {
            int rnd = Random.Range(0, 26 - dotList.Count);

            foreach (DotBehaviour dot in dotList)
            {
                dot.transform.GetChild(0).GetComponent<Text>().text = GameParent.alphabet[rnd].ToString();
                rnd++;
            }
        }

        public void setLineParent(Transform tr)
        {
            lineParent = tr;
        }
    }
}