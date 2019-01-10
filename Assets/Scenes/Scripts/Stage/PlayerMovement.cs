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
    [SerializeField]
    TextMeshProUGUI portalCounter;

    int gemsNumber;
    float magnitude = 3000;
    int health = 3;
    int portals = 3;
    bool canMove = true;
    bool canHurt = true;
    private Material mat;
    private Color[] colors = { Color.white, Color.red };
    private Rigidbody2D rb;
    private Vector2 lastCheckPoint;

    public void Awake()
    {

        mat = GetComponent<SpriteRenderer>().material;
        rb = GetComponent<Rigidbody2D>();
    }

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

        bool portal = Input.GetButtonDown("Fire3");
        if (portal && portals > 0)
        {
            animator.SetTrigger("Fire");
            Portal weapon = GetComponent<Portal>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
            portals--;
        }

        gemCounter.text = gemsNumber.ToString();
        healthCounter.text = health.ToString();
        portalCounter.text = portals.ToString();
    }

    void FixedUpdate ()
    {
        if (!canMove)
        {
            horizontalMove = 0.0f;
        }
            // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime * Time.timeScale, false, jump);
        jump = false;
                
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Enemy") && canHurt)
        {
            Vector2 direction = (transform.position - other.transform.position).normalized;            
            direction.y = 0.0002f;
            rb.AddForce(direction * magnitude);
            health--;
            StartCoroutine(GotHit(0.5f));
            StartCoroutine(Flash(1f, 0.05f));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            gemsNumber++;
            other.enabled = false;
            other.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.2f);
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {

            lastCheckPoint = other.transform.position;
            other.enabled = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Recharge"))
        {
            portals++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Water"))
        {
            health--;
            StartCoroutine(ReturnToLastCheckpoint(0.5f));
            StartCoroutine(GotHit(0.5f));
            StartCoroutine(Flash(1f, 0.05f));   
        }

    }

    IEnumerator GotHit(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;        
    }

    IEnumerator ReturnToLastCheckpoint(float time)
    {
        yield return new WaitForSeconds(time);
        this.transform.position = lastCheckPoint;
    }

    IEnumerator Flash(float time, float intervalTime)
    {
        float elapsedTime = 0f;
        int index = 0;
        canHurt = false;
        while (elapsedTime < time)
        {
            mat.color = colors[index % 2];

            elapsedTime += Time.deltaTime;
            index++;
            yield return new WaitForSeconds(intervalTime);
        }
        mat.color = colors[0];
        canHurt = true;
    }
}
