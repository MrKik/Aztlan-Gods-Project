
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMaster(float Volume)
    {
        audioMixer.SetFloat("Master", Volume);
        Debug.Log("Volume");
    }
    public void SetVolumeMusic(float Volume)
    {
        audioMixer.SetFloat("Music", Volume);
        Debug.Log("Volume");
    }
    public void SetVolumeSFx(float Volume)
    {
        audioMixer.SetFloat("SFx", Volume);
        Debug.Log("Volume");
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
