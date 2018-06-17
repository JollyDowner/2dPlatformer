using System;
using UnityEngine;


    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    
        [SerializeField] private float m_JumpForce = 400f;                  
        [SerializeField] private bool m_AirControl = false;                 
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // where to check for ground
        const float k_GroundedRadius = .2f; 
        private bool m_Grounded;            
        private Animator m_Anim;            
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  
        private bool hasKey = false;
        private bool hasTurnedIn = false;

        private void Awake()
        {

            m_GroundCheck = transform.Find("GroundCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            //if overlaps with ground layer
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;

                  
                }
              
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // jump animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }
        

        public void Move(float move, bool jump)
        {



    
            if (m_Grounded || m_AirControl)
            {


                m_Anim.SetFloat("Speed", Mathf.Abs(move));


                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

  
                //sprite flipping
                if (move > 0 && !m_FacingRight)
                {

                    Flip();
                }

                else if (move < 0 && m_FacingRight)
                {

                    Flip();
                }
            }
            // if jump
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {

                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.CompareTag("Key"))
            {
                hasKey = true;
              
            }
        }

        public bool getHaskey()
        {
            return hasKey;
        }

        public bool getHasTurnedIn()
        {
            return hasTurnedIn;
        }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if(hasKey && collision.gameObject.CompareTag("Goal")){
                collision.GetComponent<ChestControl>().toggleOpen();
                hasTurnedIn = true;
                hasKey = false;
            }

        if (collision.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(collision.gameObject);
        }

        }

        private void Flip()
        {

            m_FacingRight = !m_FacingRight;


            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    


