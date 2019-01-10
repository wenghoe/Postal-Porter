using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public Vector3 rotationDirection;
    public float smoothTime;
    private float convertedTime = 200;
    private float smooth;

    // Update is called once per frame
    void Update()
    {
        smooth = Time.deltaTime * smoothTime * convertedTime;
        transform.Rotate(rotationDirection * smooth);
    }
}
