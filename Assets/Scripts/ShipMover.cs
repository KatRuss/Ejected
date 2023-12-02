using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ShipMover : MonoBehaviour
{

    [NonSerialized] public bool isSelected = false;
    bool hasPlayer = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 100;

    // Update is called once per frame
    void Update()
    {
        //Test Mouse input, replace later
        if (isSelected)
        {
            // Movement/Velocity
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;
            rb.AddForce(direction * speed * Time.deltaTime);

            //TODO: Rotation

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasPlayer = true;
            Debug.Log("Collided into Player");
        }
    }
}
