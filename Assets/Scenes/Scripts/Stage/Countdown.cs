using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public int timeLeft = 90;

    public TextMeshProUGUI timeCounter;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter.text = ("" + timeLeft);
		if (timeLeft == 0) {
			StopCoroutine("LoseTime");
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
}