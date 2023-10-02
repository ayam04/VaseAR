using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToMove : MonoBehaviour
{
    private Touch touch;
    private float speedModifier = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 newPosition = transform.position + new Vector3(touch.deltaPosition.x * speedModifier, touch.deltaPosition.y * speedModifier, 0f);
                transform.position = newPosition;
            }
        }
    }
}
