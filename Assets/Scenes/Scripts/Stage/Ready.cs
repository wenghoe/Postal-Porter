using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour {
	public GameObject readyText;
	public GameObject audioBGM;

    bool isReady = false;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("StartDelay");
	}

	void Update() {
        if (!isReady)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            Destroy(this);
        }
    }

	IEnumerator StartDelay()
	{		
		float pauseTime = Time.realtimeSinceStartup + 1f;
	
		while (Time.realtimeSinceStartup < pauseTime) 
			yield return 0;

        isReady = true;
        readyText.SetActive (false);
		audioBGM.GetComponent<AudioSource> ().Play ();
        
	}
}
