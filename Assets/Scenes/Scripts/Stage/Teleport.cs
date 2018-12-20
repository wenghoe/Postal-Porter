using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    
    GameObject player;

	GameObject teleportEffect;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D col)
    {        
        if (col.gameObject.tag == "Teleport")
        {
			col.GetComponent<ParticleSystem> ().Play ();
            col.GetComponent<AudioSource>().Play();
            player.transform.position = this.transform.position;
        }
    }
}
