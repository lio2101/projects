using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{

    public AudioSource soundPlayer;
    public void playSoundEffect()
    {
        soundPlayer.Play();
    }
}
