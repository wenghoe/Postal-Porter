using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public int timeLeft = 90;
    GameManager GM;
    public TextMeshProUGUI timeCounter;
    public GameObject timeupText;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    public void Awake()
    {
        GM = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter.text = ("" + timeLeft);
		if (timeLeft == 0) {
            GM.SetGameState(GameState.GameOver);
            StopCoroutine("LoseTime");
            StartCoroutine("ShowTimeOut", 2f);
            GameObject soundObject = GameObject.Find ("BGM");
			AudioSource audioSource = soundObject.GetComponent<AudioSource>();
			audioSource.Stop();
		}
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

    IEnumerator ShowTimeOut(float time)
    {
        timeupText.SetActive(true);

        GameObject soundObject = GameObject.Find("BGM");
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        audioSource.Stop();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("0 MainMenu");
    }
}