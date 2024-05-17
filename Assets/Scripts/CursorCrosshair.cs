using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCrosshair : MonoBehaviour
{
    public Sprite dotcrosshair;
    public Sprite crosshair;
    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dotcrosshair;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = crosshair;
        } else if (Input.GetButtonUp("Fire2")) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dotcrosshair;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
