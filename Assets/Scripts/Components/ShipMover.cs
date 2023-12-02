using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ShipMover : MonoBehaviour
{

    [NonSerialized] public bool isSelected = false;
    Player player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 100;
    [SerializeField] float deceleration = 0.5f;
    [SerializeField] float maxVelocityMag = 50;
    Vector2 currentVelocity;

    // Update is called once per frame
    void Update()
    {
        //Eject Player
        if (player != null && Input.GetMouseButtonDown(1))
        {
            player.LeaveSpaceShip(rb.velocity);
        }

        if (isSelected)
        {
            // Movement/Velocity
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentVelocity = (mousePosition - transform.position).normalized;
            rb.AddForce(currentVelocity * speed * Time.deltaTime);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity,maxVelocityMag);
            //TODO: Rotation

        }
        else
        {
            // SLow down the ship
            rb.velocity = Vector2.Lerp(rb.velocity,Vector2.zero,Time.deltaTime * deceleration);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponent<Player>();
            if (player.leavingShip == false)
            {
                player.getInSpaceShip(this.gameObject);
            }
        }
    }
}
