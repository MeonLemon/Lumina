using UnityEngine;

public class AnimRotate : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float bobSpeed = 0.5f;
    public float bobHeight = 0.2f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Rotate the star around its own axis
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);

        // Bob the star up and down
        Vector3 bobPosition = startPosition + Vector3.up * Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = bobPosition;
    }
}


