using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : singleTon<SoundManager>
{
    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private AudioSource sfxSource;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider sfxSlider;

    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    // Use this for initialization
    public void Start()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("audio") as AudioClip[];

        foreach (AudioClip clip in clips)
        {
            /*clip.name == name of file*/
            audioClips.Add(clip.name, clip);
        }

        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("Music", 50f);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = PlayerPrefs.GetInt("SFX", 50);
        }
        // musicSlider.onValueChanged.AddListener(delegate { UpdateMusic(); }); /*change musicSlider, then call update music function*/
        //sfxSlider.onValueChanged.AddListener(delegate { UpdateSFX(); });
    }

    public void PlaySFX(string name)
    {
        sfxSource.PlayOneShot(audioClips[name]);
    }

    public void UpdateMusic()
    {
        musicSource.volume = musicSlider.value / 100f;

        /*store sfxslider.value SFX*/
        PlayerPrefs.SetFloat("Music", musicSlider.value);
        PlayerPrefs.Save();
    }

    public void UpdateSFX()
    {
        sfxSource.volume = sfxSlider.value / 100f;

        PlayerPrefs.SetInt("SFX", (int)sfxSlider.value);
        PlayerPrefs.Save();
    }

}
