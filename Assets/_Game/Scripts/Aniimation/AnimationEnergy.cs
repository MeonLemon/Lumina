using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnergy : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;
    // Update is called once per frame
    void Update()
    {
        float currentFill = DecreaseFillOverTime.Instance.currentFillAmount;

        myAnimator.speed = currentFill;

        if(currentFill >= 0.7f)
        {
            myAnimator.speed = 2f;
        }

        if(currentFill <= 0.3f)
        {
            myAnimator.speed = 0.3f;
        }

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
