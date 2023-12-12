using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // The object you want to orbit around
    public float rotationSpeed = 2.0f;

    float touchDist = 0;
    float lastDist = 0;

    public float zoomSpeed = 0.1f;
    
    public float verticalRotationLimit = 80.0f;

    private float verticalRotation = 0.0f;
    
    private bool isPinching = false;

    void Update()
    {
        if (Input.touchCount == 0)
        {
            isPinching = false; // Reset the flag when no touches are detected
        }

        if (isPinching)
        {
            return; // Disable rotation while pinching
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = touch.deltaPosition;
                transform.RotateAround(target.position, Vector3.up, touchDeltaPosition.x * rotationSpeed);
                verticalRotation += touchDeltaPosition.y * rotationSpeed;
                verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
                transform.eulerAngles = new Vector3(verticalRotation, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }

        // Pinch to zoom
        if (Input.touchCount == 2)
        {
            isPinching = true;

            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
            {
                lastDist = Vector2.Distance(touch1.position, touch2.position);
            }

            if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                float newDist = Vector2.Distance(touch1.position, touch2.position);
                touchDist = lastDist - newDist;
                lastDist = newDist;

                // Your Code Here
                Camera.main.fieldOfView += touchDist * zoomSpeed;
            }
        }

        Debug.Log(isPinching);
    }
}
