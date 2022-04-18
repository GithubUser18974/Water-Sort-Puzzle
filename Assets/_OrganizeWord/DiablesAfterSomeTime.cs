using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Organize_Word
{
    public class DiablesAfterSomeTime : MonoBehaviour
    {
        public float timeOut = 1.0f;
        float tempTime = 0.0f;
        private void Start()
        {
            tempTime = timeOut;
        }

        void Update()
        {
            timeOut -= Time.deltaTime;
            if (timeOut < 0)
            {
                timeOut = tempTime;
                gameObject.SetActive(false);
            }
        }
    }
}