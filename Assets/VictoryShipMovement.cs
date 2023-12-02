using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryShipMovement : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update() { transform.position += new Vector3(0, speed * Time.deltaTime, 0); }
}
