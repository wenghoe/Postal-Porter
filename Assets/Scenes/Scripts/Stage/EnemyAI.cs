using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    //public Transform Player;
    //public float minDist = 4f;
    //public float maxDist = 4f;

    public bool isForward = true;
    void Start()
    {
        StartCoroutine(Move(2f));
    }

    void Update()
    {
        if (isForward)
            transform.Translate(Vector3.left * Time.deltaTime);
        else
            transform.Translate(Vector3.right * Time.deltaTime);
    }

    IEnumerator Move(float time)
    {
        while (true)
        {
            isForward = !isForward;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            yield return new WaitForSeconds(time);
        }        
    }

    //public enum OccilationFuntion { Sine, Cosine }
    //public void Start()
    //{
    //    //to start at zero
    //    StartCoroutine(Oscillate(OccilationFuntion.Sine, 1f));
    //    //to start at scalar value
    //    //StartCoroutine (Oscillate (OccilationFuntion.Cosine, 1f));
    //}

    //private IEnumerator Oscillate(OccilationFuntion method, float scalar)
    //{
    //    while (true)
    //    {
    //        if (method == OccilationFuntion.Sine)
    //        {
    //            transform.position = new Vector2(Mathf.Sin(Time.time) * scalar + transform.position.x, transform.position.y);
    //        }
    //        else if (method == OccilationFuntion.Cosine)
    //        {
    //            transform.position = new Vector2(Mathf.Cos(Time.time) * scalar + transform.position.x, transform.position.y);
    //        }
    //        yield return new WaitForEndOfFrame();
    //        Debug.Log(transform.position);
    //    }
    //}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Magic")
        {
            float yoffset = 4f;            
            this.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + yoffset);
            Destroy(col.gameObject);
        }
    }
}
