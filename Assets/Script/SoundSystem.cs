using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSystem : MonoBehaviour
{
    public AudioSource backgroundMusicAudioSource;
    public AudioSource soundEffectsAudioSource;

    public Slider backgroundMusicSlider;
    public Slider soundEffectsSlider;
    public Toggle muteToggle;

    private float initialBackgroundMusicVolume;
    private float initialSoundEffectsVolume;

    private void Start()
    {
        backgroundMusicSlider.value = PlayerPrefs.GetFloat("BackgroundMusicVolume", 1f);
        soundEffectsSlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume", 1f);
        muteToggle.isOn = PlayerPrefs.GetInt("IsMuted", 0) == 1;

        initialBackgroundMusicVolume = backgroundMusicAudioSource.volume;
        initialSoundEffectsVolume = soundEffectsAudioSource.volume;

        backgroundMusicSlider.onValueChanged.AddListener(ChangeBackgroundMusicVolume);
        soundEffectsSlider.onValueChanged.AddListener(ChangeSoundEffectsVolume);
        muteToggle.onValueChanged.AddListener(ToggleMute);
    }

    private void ChangeBackgroundMusicVolume(float volume)
    {
        backgroundMusicAudioSource.volume = volume;
        PlayerPrefs.SetFloat("BackgroundMusicVolume", volume);
    }

    private void ChangeSoundEffectsVolume(float volume)
    {
        soundEffectsAudioSource.volume = volume;
        PlayerPrefs.SetFloat("SoundEffectsVolume", volume);
    }

    private void ToggleMute(bool isMuted)
    {
        backgroundMusicAudioSource.mute = isMuted;
        soundEffectsAudioSource.mute = isMuted;

        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);

        if (isMuted)
        {
            backgroundMusicSlider.value = 0f;
            soundEffectsSlider.value = 0f;
        }
        else
        {
            backgroundMusicSlider.value = initialBackgroundMusicVolume;
            soundEffectsSlider.value = initialSoundEffectsVolume;
        }
    }
}
