using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicMngr : MonoBehaviour
{
    AudioSource audSour;
    public AudioClip nextClip;
    public AudioClip win;
    public AudioClip lose;
    public float secs;
    bool changed;

    void Start()
    {
        audSour = gameObject.GetComponent<AudioSource>();
        //StartCoroutine("Timer");
    }

    private void Update()
    {
        if(!audSour.isPlaying && !changed)
        {
            nextSong();
            changed = true;
        }
    }

    public void WinMusic()
    {
        audSour.clip = win;
        audSour.Play();
    }
    public void LoseMusic()
    {
        audSour.clip = lose;
        audSour.Play();
    }

    /*IEnumerator Timer()
    {
        audSour.Play();
        yield return new WaitForSeconds(secs);
        audSour.clip = nextClip;
        audSour.Play();
        audSour.loop = true;
    }*/

    void nextSong()
    {
        audSour.clip = nextClip;
        audSour.Play();
        audSour.loop = true;
    }
}
