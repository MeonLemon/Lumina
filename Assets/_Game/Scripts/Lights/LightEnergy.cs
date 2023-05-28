using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnergy : MonoBehaviour
{
    [SerializeField] private Light myLight;
    // Update is called once per frame
    void Update()
    {
        float currentFill = DecreaseFillOverTime.Instance.currentFillAmount;

        myLight.intensity = currentFill;
        
        /*
        if (currentFill >= 0.5f)
        {
            myLight.intensity = 1f;
        }

        if (currentFill < 0.5f)
        {
            myLight.intensity = 0.5f;
        }

        if (currentFill < 0.2f)
        {
            myLight.intensity = 0.2f;
        }
        */
    }
}
