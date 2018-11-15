using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Magic")
        {
            float yoffset = 4f;            
            this.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + yoffset);
            Destroy(col.gameObject);
        }
    }
}
