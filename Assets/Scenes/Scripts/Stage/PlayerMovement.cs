using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public Animator animator;

    [SerializeField]
    TextMeshProUGUI gemCounter;
    [SerializeField]
    TextMeshProUGUI healthCounter;

    int gemsNumber;
    float magnitude = 1500;
    int health = 3;

    // Update is called once per frame
    void Update () {
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetTrigger("Jump");
        }

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Careful: For Mac users, ctrl + arrow is a bad idea

        if (shoot)
        {
            animator.SetTrigger("Fire");
            Magic weapon = GetComponent<Magic>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }

        gemCounter.text = gemsNumber.ToString();
        healthCounter.text = health.ToString();
    }

    void FixedUpdate ()
    {
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime * Time.timeScale, false, jump);
        jump = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            gemsNumber++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 force = transform.position - other.transform.position;
            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);
            //rigidbody.velocity *= -1;
            health--;
        }
    }
}
