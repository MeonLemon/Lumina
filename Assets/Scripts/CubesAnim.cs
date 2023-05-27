using UnityEngine;

using UnityEngine;

public class CubesAnim : MonoBehaviour
{
    public GameObject podiumModel;
    public float rotationSpeed = 100f;
    public float bobSpeed = 0.5f;
    public float bobHeight = 0.2f;
    public float scaleSpeed = 0.5f;
    public float scaleAmount = 0.1f;

    private Vector3 startPosition;
    private Vector3 startScale;

    private void Start()
    {
        startPosition = transform.position;
        startScale = transform.localScale;
    }

    private void Update()
    {
        // Rotate the cubes around their own axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Bob the cubes up and down
        Vector3 bobPosition = startPosition + Vector3.up * Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = bobPosition;

        // Scale the cubes back and forth
        float scale = 1f + Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
        transform.localScale = startScale * scale;
    }
}