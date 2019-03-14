using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {
	public Animator transitionAnim;

	public void PlayGame()
    {
		StartCoroutine (LoadScene ());
    }

	IEnumerator LoadScene() {
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

	void Update()
	{
		if (EventSystem.current.currentSelectedGameObject == null)
		{
			Debug.Log("Reselecting first input");
			EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
		}
	}
}
