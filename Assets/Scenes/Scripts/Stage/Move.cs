using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public bool stopObject = false;    
    public bool isStopped = false;

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    void Update()
    {
        if (!isStopped)
        {
            movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

            if (stopObject)
            {
                StartCoroutine(StopObject());
            }
        }

        
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        if (!isStopped)
            rigidbodyComponent.velocity = movement;
    }

    IEnumerator StopObject()
    {
        yield return new WaitForSeconds(1f);
        rigidbodyComponent.velocity = Vector2.zero;
        isStopped = true;
    }
}