using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLight : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material glowMaterial;
    [SerializeField] private Material material;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            meshRenderer.sharedMaterial = glowMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            meshRenderer.sharedMaterial = material;
        }
    }
}
