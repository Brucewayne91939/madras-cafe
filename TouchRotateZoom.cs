using UnityEngine;

public class TouchRotateZoom : MonoBehaviour
{
    public float rotationSpeed = 0.2f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.deltaPosition;
                transform.Rotate(Vector3.up, -delta.x * rotationSpeed, Space.World);
                transform.Rotate(Vector3.right, delta.y * rotationSpeed, Space.World);
            }
        }

    }
}
