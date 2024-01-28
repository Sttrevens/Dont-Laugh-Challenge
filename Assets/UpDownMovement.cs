using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float distance = 16f; // Distance to move up and down
    public float speed = 4f;    // Speed of the movement

    private Vector3 startPosition;
    private float movement;

    void Start()
    {
        startPosition = transform.position; // Remember the start position
    }

    void Update()
    {
        // Calculate the new position
        movement = distance * Mathf.Sin(Time.time * speed);
        transform.position = startPosition + new Vector3(0, movement, 0);
    }
}
