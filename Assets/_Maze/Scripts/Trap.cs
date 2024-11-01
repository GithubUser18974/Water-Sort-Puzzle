﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Maze
{
    public class Trap : MonoBehaviour
    {
        public float delay;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(Go());
        }
        IEnumerator Go()
        {
            while (true)
            {
                GetComponent<Animation>().Play();
                yield return new WaitForSeconds(delay);
            }
        }
    }
}