using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//public class ValueChangedEvent:UnityEvent<int>{}

public class GameManager : MonoBehaviour
{
    private static int roundsPlayed = 0;
    private int levelNumber;
    private static int maxPlayerHealth = 3;
    private static int playerHealth = maxPlayerHealth;
    private int damage = 1;
    private float timeWasted;

    //public UnityEvent roundsChanged = new UnityEvent();


    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel(){
        Debug.Log("nextlevel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Death(){
        playerHealth = maxPlayerHealth;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Win(){
        SceneManager.LoadScene(4);
    }

    public void CloseGame(){
        Application.Quit();
    }
   public int GetRoundsPlayed()
   {
       return roundsPlayed;
   }
   public int GetPlayerHealth()
   {
       return playerHealth;
   }
   public int GetMaxPlayerHealth()
   {
       return maxPlayerHealth;
   }
   public void Damage(){
       playerHealth= playerHealth - damage;
       Debug.Log("Ouch!");
   }
       public int GetActiveScene(){
        return SceneManager.GetActiveScene().buildIndex;
    }
}
