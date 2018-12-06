using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
   
    public float speed = 1.2f;
    public Vector2 pointA;
    public Vector2 pointB;
    SpriteRenderer spriteRenderer;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);

        if (transform.position.x - 0.1f <= pointA.x)
        {

            spriteRenderer.flipX = false;
        }
        if (transform.position.x + 0.1f >= pointB.x)
        {

            spriteRenderer.flipX = true;
        }

        transform.position = Vector2.Lerp(pointA, pointB, time);
    
        
    }

}
