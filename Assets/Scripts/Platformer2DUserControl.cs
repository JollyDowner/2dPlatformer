using System;
using UnityEngine;



    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D charScript;
        private bool isJumping;


        private void Awake()
        {
            charScript = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {


            if (!isJumping)
            {
                isJumping = Input.GetKeyDown(KeyCode.Space);
            }
        }

        //FixedUpdate for physics
        private void FixedUpdate()
        {

            float moveHorizontal = Input.GetAxis("Horizontal");

            charScript.Move(moveHorizontal, isJumping);
            isJumping = false;
        }
    }

