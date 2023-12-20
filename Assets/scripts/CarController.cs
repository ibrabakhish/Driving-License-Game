using UnityEngine;

public class CarController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 5f;
    bool isClicked = false;

    private int currentWaypointIndex = 0;

    void Awake()
    {
        // Attempt to automatically find LineRenderer component on the same GameObject
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Check if LineRenderer is still null
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer not found or assigned to the CarController script.");
        }
    }

    void MoveCarOnClick()
    {
        if (Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Hatchback"))
                    {
                        this.isClicked = true;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Main camera not found. Ensure you have an active main camera in the scene.");
        }
    }

    void Update()
    {
        // Check if both lineRenderer and gameObject are not null
        if (lineRenderer != null && gameObject != null)
        {

            MoveCarOnClick();
            if (isClicked)
            {
                MoveToNextWaypoint();
            }
        }
        else
        {
            Debug.LogError("LineRenderer or gameObject is null. Make sure to assign them in the Inspector.");
        }
    }

    void MoveToNextWaypoint()
    {
        if (currentWaypointIndex < lineRenderer.positionCount)
        {
            Vector3 targetPosition = lineRenderer.GetPosition(currentWaypointIndex);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                currentWaypointIndex++;
            }

            if (currentWaypointIndex == 2)
            {
                transform.rotation = Quaternion.Euler(-90f, -90f, -90f);
            }
        }
        else
        {
            // The car has reached the end of the line
            // You may want to reset the currentWaypointIndex or perform other actions
        }
    }
}




