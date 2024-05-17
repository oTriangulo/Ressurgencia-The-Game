using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start() {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Update() {
        Destroy(gameObject, 1f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
    
}
