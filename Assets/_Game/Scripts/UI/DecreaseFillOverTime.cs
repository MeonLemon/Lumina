using UnityEngine;
using UnityEngine.UI;

public class DecreaseFillOverTime : Singleton<DecreaseFillOverTime>
{
    public Image image;
    public float decreaseSpeed = 0.5f;

    public float currentFillAmount;

    private void Start()
    {
        if (image == null)
            image = GetComponent<Image>();

        currentFillAmount = image.fillAmount;
    }

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.Start) return;

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