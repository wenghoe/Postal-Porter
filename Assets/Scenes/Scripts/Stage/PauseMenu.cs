using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenuCanvas;

	private enum State {Running, Pause};
	private State currentState;
	// Use this for initialization
	void Start () {
		currentState = State.Running;
	}

	// Update is called once per frame
	void Update () {
		if (currentState == State.Pause)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        } else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
			if (currentState == State.Pause) {
				currentState = State.Running;
			}
			else{
				currentState = State.Pause;
			}

        }
	}
}
