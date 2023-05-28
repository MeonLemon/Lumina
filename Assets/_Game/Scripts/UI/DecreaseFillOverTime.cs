using UnityEngine;
using UnityEngine.UI;

public class DecreaseFillOverTime : MonoBehaviour
{
    public Image image;
    public float decreaseSpeed = 0.5f;

    private float currentFillAmount;

    private void Start()
    {
        if (image == null)
            image = GetComponent<Image>();

        currentFillAmount = image.fillAmount;
    }

    private void Update()
    {
        if (currentFillAmount > 0f)
        {
            currentFillAmount -= decreaseSpeed * Time.deltaTime;
            image.fillAmount = currentFillAmount;
        }

        if(currentFillAmount < 0f)
        {
            GameManager.Instance.gameState = GameState.End;
        }
    }
}