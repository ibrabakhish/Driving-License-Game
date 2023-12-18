using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    //public Vector3 targetPosition;
    public Camera mainCamera;  // Reference to the camera

    public float speed = 5f;

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, step);

            if (transform.position == pointB.position)
            {
                isMoving = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (!isMoving)
        {
            isMoving = true;

            if (mainCamera != null)
            {
                mainCamera.transform.parent = transform;
            }
        }
    }
}
