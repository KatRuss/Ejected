using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float smoothSpeed = 5f;
    Transform currentTarget;
    
    private void LateUpdate() 
    {
        if (currentTarget != null)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(currentTarget.position.x,currentTarget.position.y,-10),Time.deltaTime * smoothSpeed);
        }
    }

    public void SetTarget(Transform target) { currentTarget = target; }

}
