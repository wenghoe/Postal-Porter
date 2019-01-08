using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearStage : MonoBehaviour {
	public GameObject goalUICanvas;

	void Start () {
		goalUICanvas.SetActive(false);
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
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene ("0 MainMenu");
	}
}
