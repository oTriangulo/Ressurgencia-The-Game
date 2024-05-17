using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFuncs : MonoBehaviour
{
    public float EnemyHP = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHP <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        EnemyHP -= damage;
    }
}
