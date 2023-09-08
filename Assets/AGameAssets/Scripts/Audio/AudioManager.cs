using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    string currentSceneName;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop; 
        }
    }
     void Update()
     {
        currentSceneName = SceneManager.GetActiveScene().name;

        if(currentSceneName == "Menu")
        {
            gameObject.SetActive(false);
        }
        else{
            gameObject.SetActive(true);
        }
     }
    void Start()
        {
            Play("Theme");
        }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if(sound == null)
        {
            return;
        }
        sound.source.Play();
    }
    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if(sound == null)
        {
            return;
        }
        sound.source.Stop();
    }
}
