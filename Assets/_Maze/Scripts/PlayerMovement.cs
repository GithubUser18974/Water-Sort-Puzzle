﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Maze
{
    public class PlayerMovement : MonoBehaviour
    {
        public float movespeed;
        public GameObject deathAnimation;
        public GameManager manager;
        private Vector3 input;

        private float maxspeed = 5;
        private Vector3 spawnPoint;
        // Use this for initialization
        void Start()
        {
            spawnPoint = transform.position;
            manager = manager.GetComponent<GameManager>();
        }
        public void SetLeft()
        {
            input = new Vector3(-0.3f, 0, 0);
        }
        public void SetRight()
        {
            input = new Vector3(0.3f, 0, 0);
        }
        public void SetDown()
        {
            input = new Vector3(0, 0, -0.3f);
        }
        public void SetUp()
        {
            input = new Vector3(0, 0, 0.3f);
        }
        public void SetZero()
        {

        }
        // Update is called once per frame
        void Update()
        {
            //input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            print(input);
            if (GetComponent<Rigidbody>().velocity.magnitude < maxspeed)
                GetComponent<Rigidbody>().AddForce(input * movespeed);

            if (transform.position.y < -3)
                Die();
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.transform.tag == "Enemy")
            {
                Die();
            }
            else if (other.transform.tag == "Goal")
            {
                manager.CompleteLevel();
                manager.currScore += 50;
                if (manager.highScore < manager.currScore)
                {
                    manager.highScore = manager.currScore;
                }
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Enemy")
            {
                Die();
            }
            if (other.transform.tag == "Token")
            {
                manager.AddToken();
                Destroy(other.gameObject);
            }
        }

        void Die()
        {
            Instantiate(deathAnimation, transform.position, Quaternion.identity);
            transform.position = spawnPoint;
            manager.deathScore += 1;
        }



    }
}