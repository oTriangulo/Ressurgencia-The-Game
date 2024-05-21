using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFuncs : MonoBehaviour
{
    // variables for health bar and mouse position
    public float HP;
    public float maxHP = 16f;
    public Camera cam;
    Vector2 mousepos;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0){
            Death();
        }

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (mousepos.x <= gameObject.transform.position.x && gameObject.transform.localScale.x > 0){
            flip();
        } else if (mousepos.x >= gameObject.transform.position.x && gameObject.transform.localScale.x < 0){
            flip();
        }

    }

    void Death(){
        Destroy(gameObject);
    }

    void flip(){
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        //-136.5f degrees         right -43.5
    }
}
