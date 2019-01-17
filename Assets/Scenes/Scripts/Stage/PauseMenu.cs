using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseText;
    public GameObject audioBGM;
    GameManager GM;

    void Awake()
    {
        GM = GameManager.Instance;
        pauseText.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {            
			if (GM.GetGameState() == GameState.Pause) {
                GM.SetGameState(GameState.Game);
                pauseText.SetActive(false);
                Time.timeScale = 1f;
                audioBGM.GetComponent<AudioSource>().UnPause();
            }
            else if (GM.GetGameState() == GameState.Game)
            {
                GM.SetGameState(GameState.Pause);
                pauseText.SetActive(true);
                Time.timeScale = 0f;
                audioBGM.GetComponent<AudioSource>().Pause();
            }
        }
	}
}
