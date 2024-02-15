using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Slider slider;
    [SerializeField] private Vector2 snakeValue;
    [SerializeField] private Vector2 catValue;
    [SerializeField] private Vector2 parrotValue;
    [SerializeField] private Vector2 dogValue;

    void Start()
    {
        button.onClick.AddListener(() => CalcValue());
    }

    private void CalcValue()
    {
        int value = (int)slider.value;
        if (value >= snakeValue.x && value <= snakeValue.y)
        {
            GameManager.instance.IncreaseValue(1);
        }
        if (value >= catValue.x && value <= catValue.y)
        {
            GameManager.instance.IncreaseValue(2);
        }
        if (value >= parrotValue.x && value <= parrotValue.y)
        {
            GameManager.instance.IncreaseValue(3);
        }
        if (value >= dogValue.x && value <= dogValue.y)
        {
            GameManager.instance.IncreaseValue(4);
        }
    }
}
