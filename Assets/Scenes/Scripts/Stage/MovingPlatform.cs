using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public float speedUpDown = 1;
    public float distanceUpDown = 1;
	
	// Update is called once per frame
	void Update () {
        Vector2 mov = new Vector2(transform.position.x, Mathf.Sin(speedUpDown * Time.time) * distanceUpDown);
        transform.position = mov;        
    }
}
