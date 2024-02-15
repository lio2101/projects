using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // Singleton instance of the game manager

    private int score;
    private string result;

    // Property for accessing the score
    public int Score => score;

    private void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    //Increase score value by an amount > see ButtonController and SliderController
    public void IncreaseValue(int value)
    {
        score += value;
    }

    // Reset score
    public void ResetValue()
    {
        Debug.Log("Reset");
        score = 0;
    }

    // Calculate and return the result based on the score
    public string CalcResult()
    {
        if (score <= 18) { result = "Snake"; }
        if (score > 18 && score <= 25) { result = "Cat"; }
        if (score > 25 && score <= 32) { result = "Parrot"; }
        if (score > 32) { result = "Dog"; }

        Debug.Log("Score: " + score + " Result: " + result);

        return result;
    }
}
