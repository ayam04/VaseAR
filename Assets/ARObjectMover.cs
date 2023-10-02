using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectMover : MonoBehaviour
{
    private bool isMoving = false; // Flag to track if the object is currently being moved.
    private Vector3 touchOffset;   // Offset between the object's position and the touch point.
    private float moveSpeed = 5f;  // Adjust the movement speed as needed.

    void Update()
    {
        // Check for touch input.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Check if the touch hit the 3D object.
                    if (IsTouchingObject(touch.position))
                    {
                        // Calculate the offset between the touch point and the object's position.
                        touchOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                        isMoving = true;
                    }
                    break;

                case TouchPhase.Moved:
                    // If the object is being moved, update its position based on the touch input.
                    if (isMoving)
                    {
                        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f)) + touchOffset;
                        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                    }
                    break;

                case TouchPhase.Ended:
                    // Stop moving the object when the touch is released.
                    isMoving = false;
                    break;
            }
        }
    }

    // Helper function to check if a touch hits the 3D object.
    private bool IsTouchingObject(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == gameObject;
        }

        return false;
    }
}
