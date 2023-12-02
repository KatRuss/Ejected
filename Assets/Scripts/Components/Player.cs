using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Transform currentSpaceship; //That the spaceman is in.
    public bool leavingShip = false;
    [SerializeField] float currentOxygen;
    [SerializeField] float MaxOxygen;
    [SerializeField] float ejectSpeed;
    [SerializeField] int ejectWaitSeconds;


    // Update is called once per frame
    void Update()
    {
        if (leavingShip)
        {
            StartCoroutine(leavingShipTimer());
        } 
        else
        {
            StopCoroutine(leavingShipTimer());    
        }
    }

    public void getInSpaceShip(GameObject ship)
    {
        currentSpaceship = ship.transform;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void LeaveSpaceShip(Vector2 velocity)
    {
        transform.position = currentSpaceship.position;
        leavingShip = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Rigidbody2D>().AddForce(velocity * ejectSpeed);
    }

    IEnumerator leavingShipTimer()
    {
        yield return new WaitForSeconds(ejectWaitSeconds);
        leavingShip = false;
        Debug.Log("left ship");
    }



}
