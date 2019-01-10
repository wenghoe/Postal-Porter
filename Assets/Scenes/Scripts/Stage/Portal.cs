using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform portalPrefab;

    public float shootingRate = 0.25f;
    public int portalsRemaining = 3;

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (CanAttack && portalsRemaining > 0)
        {
            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(portalPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // Make the portal always towards it
            Move move = portalPrefab.gameObject.GetComponent<Move>();
            if (move != null)
            {
                CharacterController2D cc2d = GetComponent<CharacterController2D>();
                if (cc2d.GetFacing())
                    move.direction = this.transform.right;
                else
                    move.direction = -this.transform.right;
            }
            portalsRemaining--;
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
