using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button cat;
    [SerializeField] private UnityEngine.UI.Button dog;
    [SerializeField] private UnityEngine.UI.Button snake;
    [SerializeField] private UnityEngine.UI.Button parrot;

    void Start()
    {
        //On clicking a button, a specific value is added to the playerpoints. Which Button gives which value can be seen in the instructor
        snake.onClick.AddListener(() => GameManager.instance.IncreaseValue(1));
        cat.onClick.AddListener(() => GameManager.instance.IncreaseValue(2));
        parrot.onClick.AddListener(() => GameManager.instance.IncreaseValue(3));
        dog.onClick.AddListener(() => GameManager.instance.IncreaseValue(4));
    }
}
