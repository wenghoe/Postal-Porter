using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearStage : MonoBehaviour {
	public GameObject goalUICanvas;
	public Animator transitionAnim;
    GameManager GM;

    void Start () {
		goalUICanvas.SetActive(false);
	}

    public void Awake()
    {
        GM = GameManager.Instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag ("Player")) {
			this.enabled = false;
			StartCoroutine (ShowClear (2f));
		}
    }

	IEnumerator ShowClear(float time)
	{
		goalUICanvas.SetActive (true);
        GM.SetGameState(GameState.Goal);
        transitionAnim.SetTrigger ("end");
		GameObject soundObject = GameObject.Find ("BGM");
		AudioSource audioSource = soundObject.GetComponent<AudioSource>();
		audioSource.Stop();
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene ("0 MainMenu");
	}
}
