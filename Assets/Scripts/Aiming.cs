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

    // bullet
    public LineRenderer lr;

    //-------------------------------------------------------------------------------

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
        StartCoroutine(Shoot()); // starts the coroutine to shoot the bullet
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
    IEnumerator Shoot(){ // Creates a Raycast shooting from the firepoint position and firepoint up, then, if it hits an enemy, it starts the takedamage method from the enemy
    // this is a coroutine, a method that runs over and over again in a time basis
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);

        if(hitInfo){
            EnemyFuncs enemy = hitInfo.transform.GetComponent<EnemyFuncs>();
            if (enemy != null){
                enemy.TakeDamage(bulletDamage);
            }

            lr.SetPosition(0, firePoint.position); // Sets the line renderer to the firepoint
            lr.SetPosition(1, hitInfo.point); // Sets the line renderer to the hit point
        } else { // if it doesn't hit an enemy
            lr.SetPosition(0, firePoint.position); // Sets the line renderer to the firepoint 
            lr.SetPosition(1, firePoint.position + firePoint.up * 100f); // Sets the line renderer to the hit point with a distance of 100
        }

        lr.enabled = true; // Enables the line renderer

        yield return new WaitForSeconds(0.2f); // Waits for 0.2 seconds

        lr.enabled = false; // Disables the line renderer

        }
    }
