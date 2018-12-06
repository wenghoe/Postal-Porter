using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpAI : MonoBehaviour {
    
    public float m_JumpForce = 400f;
    public Animator animator;
    private Rigidbody2D m_Rigidbody2D;
    bool onGround = true;

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {

        StartCoroutine("JumpTime");
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(onGround);
		if (onGround)
            animator.SetFloat("velocityY", 0);
        else
            animator.SetFloat("velocityY", 1);
    }

    IEnumerator JumpTime()
    {
        while (true)
        {
            onGround = true;
            yield return new WaitForSeconds(2);
            onGround = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            
        }
    }
}
