using UnityEngine;
using UnityEngine.UI;

public class DecreaseFillOverTime : Singleton<DecreaseFillOverTime>
{
    public Image image;
    public float decreaseSpeed = 0.5f;

    public float currentFillAmount;

    public bool gameIsEnding;

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
            image.fillAmount = 0f;
            GameManager.Instance.gameState = GameState.End;
            if(!gameIsEnding)
            {
                gameIsEnding = true;
                GameManager.Instance.StartCoroutine("EndGame");
            }
        }
    }

    public void ChangeColor(bool inverted)
    {
        if(!inverted)
        {
            image.color = HexColor.ToColor("#00C6FF");
        }
        else
        {
            image.color = HexColor.ToColor("#FF0E00");
        }
    }
}