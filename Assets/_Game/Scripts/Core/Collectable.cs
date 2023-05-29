using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public float speed = 1;
    public float value = 0.05f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        if(GameManager.Instance.gameState == GameState.End)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            float currentFill = DecreaseFillOverTime.Instance.currentFillAmount;

            if (currentFill + value > 1.0f)
            {
                currentFill = 1;
            }
            else
            {
                currentFill += value;
            }

            DecreaseFillOverTime.Instance.currentFillAmount = currentFill;

            switch(type)
            {
                case CollectableType.Good:
                    AudioManager.Instance.collectEvent.Invoke();
                    break;
                case CollectableType.Bad:
                    AudioManager.Instance.collectBadEvent.Invoke();
                    break;
                case CollectableType.SuperBad:
                    AudioManager.Instance.CollectSuperBadEvent.Invoke();
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
