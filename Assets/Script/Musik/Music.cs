using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class MusikGame : MonoBehaviour
{
    public Suara[] sounds;

    public static MusikGame Instance;

    public AudioMixer audioMixer;



    void Awake()
    {


        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach (Suara s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {

    }

    public void Play(string name, float volume)
    {
        Suara s = Array.Find(sounds, sound => sound.nama == name);
        if (s == null)
        {
            Debug.LogWarning("Sounds:" + name + "not found!");
            return;
        }
        else
        {
            s.source.volume = volume;
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        Suara s = Array.Find(sounds, sound => sound.nama == name);
        if (s == null)
        {
            Debug.LogWarning("Sounds:" + name + "not found!");
            return;
        }
        else
        {
            s.source.Stop();
        }
    }

    public void FadeOut(string name, float duration)
    {
        Suara s = Array.Find(sounds, sound => sound.nama == name);
        if (s == null)
        {
            Debug.LogWarning("Sounds:" + name + "not found!");
            return;
        }
        else
        {
            StartCoroutine(StartFade(s.source, duration, 0f, name));
        }
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume, string name)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        Stop(name);
        yield break;
    }
}

