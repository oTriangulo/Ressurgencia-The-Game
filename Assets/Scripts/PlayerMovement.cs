using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb; // i called the rigidbody in the inspector to be able to use it with a rb variable
    [SerializeField] private float moveSpeed = 2f; // i created a float variable to set the speed of the player
    Vector2 movement; // i created a vector 2 variable to store the movement

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // i setted the movement x and y to be the horizontal and vertical axis
    }
    
    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // i moved the player using the rigidbody and the movement variable and the speed variable and the time fixed delta time (a method that uses the inside the game time)
    }
    
}


