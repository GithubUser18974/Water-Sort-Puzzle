﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Maze
{
	public class Destroy : MonoBehaviour
	{
		public float lifetime = 0f;
		// Use this for initialization
		void Start()
		{
			Destroy(gameObject, lifetime);
		}
	}
}