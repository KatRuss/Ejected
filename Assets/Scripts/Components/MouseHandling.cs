using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class MouseHandling : MonoBehaviour
{

    ShipMover selectedObject;
    [SerializeField] CameraController camCon;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Pick up ship
        if(Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.GetComponent<ShipMover>() != null)
            {
                selectedObject = targetObject.GetComponent<ShipMover>();
                selectedObject.isSelected = true;
                Debug.Log(selectedObject.isSelected);
                camCon.SetTarget(selectedObject.transform);
            }
        }

        // Let go of ship
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject.isSelected = false;
            selectedObject = null;
            Debug.Log("Let go");
        }
    }
}
