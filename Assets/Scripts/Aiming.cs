using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    // Aiming variables
    Transform FollowPlayer;
    public Camera cam;
    Vector2 mousepos;
    public Rigidbody2D rb;
    [SerializeField] public float degreesAiming = -40f;

    // Shooting variables
    public bool aiming = false;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 60f;
    public float bulletDamage = 10f;

    private void Start() {
        FollowPlayer = GameObject.Find("Player").transform; // Finds the player and sets it as the follow player
    }

    // Update is called once per frame
    void Update()
    {
        if (mousepos.x <= gameObject.transform.position.x){
            degreesAiming = -136.5f;
            // Flips the arm based on the mouse position
        } else if (mousepos.x >= gameObject.transform.position.x){
            degreesAiming = -43.5f;
        } // Flips the arm based on the mouse position

        if (Input.GetButtonDown("Fire2") && !aiming){
            aiming = true;
        } else if (Input.GetButtonUp("Fire2") && aiming){
            aiming = false;
            rb.rotation = 0f;
        } // Toggles aiming on and off


        if (Input.GetButtonDown("Fire1") && aiming){
        Shoot();
        } // Shoots the bullet when the button is pressed and the player is aiming

        transform.position = new Vector2(FollowPlayer.position.x + -0.2f, FollowPlayer.position.y + 0.8f); // Sets the position of the arm to follow the player
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition); // Gets the position of the mouse on the screen and converts it to world coordinates
    
    }

    private void FixedUpdate() {
        
        if (aiming){        
        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - degreesAiming;
        rb.rotation = angle;
        } // Rotates the arm to face the mouse when the player is aiming
    }
    void Shoot(){ // Creates the bullet and adds force to it. Instiantiated from the firepoint as a prefab
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

    }

}
