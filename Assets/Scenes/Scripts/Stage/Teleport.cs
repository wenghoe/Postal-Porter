using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    //Transform target;
    //public PlayerObject Player
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter2D(Collider2D col)
    {        
        if (col.gameObject.tag == "Teleport")
        {
            player.transform.position = this.transform.position;
        }
    }
}
