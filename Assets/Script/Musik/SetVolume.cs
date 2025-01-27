using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;
    public float tt;
    private float time;
    private float timeDelay;
    private void Start()
    {
        mixer.GetFloat("MusicVol", out tt);
        float values = Mathf.Pow(10, (tt / 20));
        volumeSlider.value = values;
        timeDelay = Time.time + 0.5f;
    }

    private void Update()
    {
        time = Time.time;
    }

    public void SetLevel(float sliderValue)
    {
        if (sliderValue > 0)
        {
            mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        }
        else
        {
            mixer.SetFloat("MusicVol", -50);
        }
        if (timeDelay < time)
        {
            FindFirstObjectByType<MusikGame>().Play("Button", 1f);
            timeDelay = time + 0.5f;
        }
        
    }
}

