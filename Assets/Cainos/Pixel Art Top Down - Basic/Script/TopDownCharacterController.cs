using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float moveSpeed = 5f; // Speed of the player
        private Rigidbody2D rb;
        private Vector2 movement;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("No Rigidbody2D found on " + gameObject.name);
            }
        }

        void Update()
        {
            // Movement input
            movement.x = Input.GetAxis("Horizontal"); // Left/Right movement (A/D or Left/Right arrows)
            movement.y = Input.GetAxis("Vertical");   // Up/Down movement (W/S or Up/Down arrows)
        }

        void FixedUpdate()
        {
            // Apply movement with Rigidbody2D
            if (rb != null)
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }
    
}