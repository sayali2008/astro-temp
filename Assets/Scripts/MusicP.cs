using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicP : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource deathMusic;

    public bool levelSong=true;
    public bool deathSong=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
