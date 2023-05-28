using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEnergy : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    // Update is called once per frame
    void Update()
    {
        float currentFill = DecreaseFillOverTime.Instance.currentFillAmount;

        if (currentFill >= 0.5f)
        {
            audio.pitch = 1f;
        }

        if(currentFill < 0.5f)
        {
            audio.pitch = 0.5f;
        }

        if(currentFill < 0.2f)
        {
            audio.pitch = 0.2f;
        }
    }
}
