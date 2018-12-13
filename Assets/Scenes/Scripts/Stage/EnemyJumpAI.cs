using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpAI : MonoBehaviour {
    
    public float m_JumpForce = 400f;
    private Animator animator;
    private Rigidbody2D m_Rigidbody2D;    

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {

        StartCoroutine("JumpTime");
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("VelocityY", m_Rigidbody2D.velocity.y);        
    }

    IEnumerator JumpTime()
    {
        while (true)
        {            
            yield return new WaitForSeconds(2);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            //Debug.Log(animator.parameters.ToString());
        }
    }
}
