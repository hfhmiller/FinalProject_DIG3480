using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    public PlayerController pc;

    // Update is called once per frame
    void Update()
    {

        if (pc.win == true)
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            pc.win = false;
        }
 /*       if (Input.GetKeyDown(KeyCode.P))
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            musicSource.Stop();

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            musicSource.loop = true;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            musicSource.loop = false;
        }
        */
    }
}