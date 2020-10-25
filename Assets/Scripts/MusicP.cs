using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicP : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource deathMusic;

    public bool levelSong=true;
    public bool deathSong=false;

     //added 25-10
    private float musicVolume=1f;
    private float deathVolume=1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //added 25-10
        levelMusic.volume=musicVolume;
        deathMusic.volume=deathVolume;
    }
    
    public void LevelSound()
    {
        levelSong=true;
        deathSong=false;
        levelMusic.Play();
    }
    public void DeathSound()
    {
        if(levelMusic.isPlaying)
            levelSong=false;
        {
            levelMusic.Stop();
        }
        if(!deathMusic.isPlaying && deathSong==false)
        {
            deathMusic.Play();
            deathSong=true;
        }
    }
    //added
    public void SoundControlPause()
    {
        levelMusic.Pause();     
    }
    public void SoundControlResume()
    {
        levelMusic.Play();     
    }

     //added 25-10
    public void SetVolume(float vol)
    {
        musicVolume=vol;
        deathVolume=vol;
    }
}
