using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float speed = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            float currentFill = DecreaseFillOverTime.Instance.currentFillAmount;

            if (currentFill + 0.05f > 1.0f)
            {
                currentFill = 1;
            }
            else
            {
                currentFill += 0.05f;
            }

            DecreaseFillOverTime.Instance.currentFillAmount = currentFill;


            Destroy(gameObject);
        }
    }
}
