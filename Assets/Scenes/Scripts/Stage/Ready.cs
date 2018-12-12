using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour {
	public GameObject readyText;
	public GameObject audioBGM;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("StartDelay");
	}

	void Update() {
	}

	IEnumerator StartDelay()
	{
		Time.timeScale = 0;
		float pauseTime = Time.realtimeSinceStartup + 1f;
		//yield return new WaitForSeconds(1);
		while (Time.realtimeSinceStartup < pauseTime) 
			yield return 0;
		Time.timeScale = 1;
		readyText.SetActive (false);
		audioBGM.GetComponent<AudioSource> ().Play ();
	}
}
