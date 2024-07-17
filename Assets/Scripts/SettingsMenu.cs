using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audiomixer;

	public MouseLook sens;

    public void SetVolume(float volume)
	{
		audiomixer.SetFloat("Volume", volume);
		PlayerPrefs.SetFloat("Volume", volume);
	}

	public void SetFull(bool isFull)
	{
		Screen.fullScreen = isFull;
	}

	public void IDK()
	{

	}

	public void Sens(float sensitivity)
	{
		sens.mouseSensitivity = sensitivity;
		PlayerPrefs.SetFloat("Sens", sensitivity);
		print(sens.mouseSensitivity);
	}
}
