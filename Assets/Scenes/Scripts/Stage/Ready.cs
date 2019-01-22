using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour {
	public GameObject readyText;
    GameManager GM;
    bool isReady = false;

    void Awake()
    {
        GM = GameManager.Instance;
        GM.SetGameState(GameState.Intro);
    }

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
            GM.SetGameState(GameState.Game);
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
		GameObject soundObject = GameObject.Find ("BGM");
		AudioSource audioSource = soundObject.GetComponent<AudioSource>();
		audioSource.Play ();
        
	}
}
