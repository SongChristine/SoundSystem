using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSystem : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle muteToggle;

    private void Start()
    {
        // Load saved audio settings or set default values
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1f);
        muteToggle.isOn = PlayerPrefs.GetInt("Mute", 0) == 1;

        // Add listeners for UI events
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnsfxVolumeChanged);
        muteToggle.onValueChanged.AddListener(OnMuteToggleChanged);
    }

    private void OnMasterVolumeChanged(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    private void OnsfxVolumeChanged(float volume)
    {
        // Adjust sound effects volume using your custom AudioManager or AudioMixer
        // For example: AudioManager.Instance.SetSoundEffectsVolume(volume);
        PlayerPrefs.SetFloat("SoundEffectsVolume", volume);
    }

    private void OnMuteToggleChanged(bool isMuted)
    {
        AudioListener.volume = isMuted ? 0f : masterVolumeSlider.value;
        PlayerPrefs.SetInt("Mute", isMuted ? 1 : 0);
    }
}
