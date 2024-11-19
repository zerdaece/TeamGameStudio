using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject stairway;         // The stairway GameObject
    public GameObject roomcoordinate;  // The target room GameObject
    public float speed = 5f;           // Movement speed
    public float wanderDistance = 2f; // Distance to wander along the Y-axis
    public float wanderSpeed = 2f;    // Speed of wandering

    private Vector3 targetPosition;    // Current target position
    private bool isTeleporting = false; // Track teleportation step
    private bool isWandering = false;  // Check if wandering behavior is active
    private float initialY;            // Initial Y position for wandering
    private float wanderDirection = 1; // Direction of wandering (up or down)

    private void Start()
    {
        if (stairway != null)
        {
            // Set the first target as the stairway's position
            targetPosition = stairway.transform.position;
        }
    }

    private void Update()
    {
        if (stairway != null && roomcoordinate != null)
        {
            // If not wandering, move towards the target position
            if (!isWandering)
            {
                MoveTowardsTarget();

                // Check if the customer has reached the stairway
                if (!isTeleporting && HasReachedTarget(stairway.transform.position))
                {
                    // Teleport to roomcoordinate's Y and move to room
                    TeleportToRoomY();
                    isTeleporting = true;
                }
                // Check if the customer has reached the roomcoordinate
                else if (HasReachedTarget(roomcoordinate.transform.position))
                {
                    StartWandering();
                }
            }
            else
            {
                // Perform wandering behavior
                Wander();
            }
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private bool HasReachedTarget(Vector3 target)
    {
        // Check if the object is close enough to the target
        return Vector3.Distance(transform.position, target) < 0.1f;
    }

    private void TeleportToRoomY()
    {
        // Change the Y-coordinate to match roomcoordinate's Y, keeping the same X and Z
        transform.position = new Vector3(transform.position.x, roomcoordinate.transform.position.y, transform.position.z);

        // Set the next target to the roomcoordinate's position
        targetPosition = roomcoordinate.transform.position;
    }

    private void StartWandering()
    {
        // Begin wandering behavior
        isWandering = true;
        initialY = transform.position.y;
    }

    private void Wander()
    {
        // Move up and down along the Y-axis within the wanderDistance range
        float newY = transform.position.y + wanderDirection * wanderSpeed * Time.deltaTime;

        if (Mathf.Abs(newY - initialY) >= wanderDistance)
        {
            // Reverse direction if it reaches the wander range
            wanderDirection *= -1;
            newY = Mathf.Clamp(newY, initialY - wanderDistance, initialY + wanderDistance);
        }

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
