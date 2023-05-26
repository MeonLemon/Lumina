using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    public float gravitySwitchDuration = 5f;
    public float gravitySwitchTimer = 0f;
    public bool isGravitySwitched = false;
    public Renderer playerRenderer;
    public Material gravitySwitchedMaterial;
    public Material normalMaterial;
    private Vector3 originalGravity;
    private Vector3 floatGravity;
    private Rigidbody rb;
    private bool isFloating = false;

    private void Start()
    {
        originalGravity = Physics.gravity;
        floatGravity = new Vector3(0f, -9.81f, 0f);
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isGravitySwitched)
            {
                isGravitySwitched = true;
                gravitySwitchTimer = gravitySwitchDuration;
                playerRenderer.material = gravitySwitchedMaterial;
                SwitchGravity();
                Debug.Log("F was pressed, gravity is on");
            }
            else
            {
                isGravitySwitched = false;
                playerRenderer.material = normalMaterial;
                SwitchGravity();
                Debug.Log("F was pressed again, gravity is off");
            }
        }

        if (isGravitySwitched)
        {
            gravitySwitchTimer -= Time.deltaTime;
            if (gravitySwitchTimer <= 0f)
            {
                isGravitySwitched = false;
                playerRenderer.material = normalMaterial;
                SwitchGravity();
                Debug.Log("Gravity timer ran out");
            }
        }

        if (isGravitySwitched && !isFloating)
        {
            rb.AddForce(-Physics.gravity, ForceMode.Acceleration);
            isFloating = true;
        }
        else if (!isGravitySwitched && isFloating)
        {
            rb.AddForce(Physics.gravity, ForceMode.Acceleration);
            isFloating = false;
        }
    }

    private void SwitchGravity()
    {
        if (isGravitySwitched)
        {
            Physics.gravity = floatGravity;
        }
        else
        {
            Physics.gravity = originalGravity;
        }
    }
}