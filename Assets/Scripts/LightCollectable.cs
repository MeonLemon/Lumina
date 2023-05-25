using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightCollectable : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float bobbingSpeed = 1f;
    public float bobbingHeight = 0.05f;
    public AudioClip collectSound;
    public ParticleSystem collectEffect;
    public TextMeshProUGUI absorbText;

    private bool isPlayerNearby = false;
    private bool isCollected = false;
    private AudioSource audioSource;
    private Collider collider;
    private Renderer renderer;
    private Vector3 originalPosition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
        originalPosition = transform.position;
        absorbText.enabled = false;
    }

    private void Update()
    {
        // Spin the collectible
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Bob the collectible up and down if it's not collected
        if (!isCollected)
        {
            float bobbingOffset = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
            transform.position = originalPosition + new Vector3(0f, bobbingOffset, 0f);
        }

        // Check if the player is nearby and display the absorb text
        if (isPlayerNearby && !isCollected)
        {
            DisplayAbsorbText(true);

            // Check if the player presses the absorb key
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collect();
            }
        }
        else
        {
            DisplayAbsorbText(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void DisplayAbsorbText(bool display)
    {
        absorbText.enabled = display;
    }

    private void Collect()
    {
        isCollected = true;

        // Play the collect sound effect
        audioSource.PlayOneShot(collectSound);

        // Play the collect effect
        collectEffect.Play();

        // Hide the collectible
        renderer.enabled = false;
        collider.enabled = false;

        // TODO: Add logic to handle the effect of absorbing the collectible
    }
}
