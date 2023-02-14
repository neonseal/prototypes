using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragHandler : MonoBehaviour {
    private GameObject selectedObject;
    private Vector3 mousePosition;

    private void Awake() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update() {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition) != mousePosition) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(0)) {
            // Attempt to get collider of clicked object
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            // Set active object if clicking dice sprite
            if (targetObject && targetObject.transform.gameObject.tag == "Dice") {
                selectedObject = targetObject.transform.gameObject;
            }
        }


        // Drag object
        if (selectedObject) {
            Debug.Log(selectedObject.name);
            // Account for camera Z position offset
            Vector3 offset = selectedObject.transform.position - mousePosition;
            selectedObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, selectedObject.transform.position.z);
        }

        // Drop object
        if (Input.GetMouseButtonUp(0) && selectedObject) {
            selectedObject = null;
        }
    }
}
