using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffleAmbience : MonoBehaviour
{
    public AudioSource forestAmbience;
    public AudioLowPassFilter lowPassFilter;
    public float fadeSpeed = 10;

    private bool fadingOut = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
             GameManger.instance.counter += 1;

            

            if ((GameManger.instance.counter % 2) == 0)
            {
                StartCoroutine(FadeOut2());
            }
            else if ((GameManger.instance.counter % 2) != 0)
            {
                //StartCoroutine(FadeOut());
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !fadingOut)
        {
            //counter++;
            //print(GameManger.instance.counter);
            

            if ((GameManger.instance.counter % 2) == 0)
            {
                
            }
            else if ((GameManger.instance.counter % 2) != 0)
            {
                StartCoroutine(FadeOut());
                
            }

            //StartCoroutine(FadeOut());


            //forestAmbience.volume = Mathf.Lerp(0.3f, 1f, fadeSpeed * Time.deltaTime);

        }
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    IEnumerator FadeOut()
    {
        fadingOut = true;

        // Store the initial volume of the audio source
        float startVolume = forestAmbience.volume;

        // Gradually increase the volume of the audio source
        float currentTime = 0f;
        while (currentTime < fadeSpeed)
        {
            currentTime += Time.deltaTime;
            forestAmbience.volume = Mathf.Lerp(startVolume, 1f, currentTime / fadeSpeed);
            lowPassFilter.cutoffFrequency = 22000f;
            yield return null;
        }

        fadingOut = false;
    }
    IEnumerator FadeOut2()
    {
        fadingOut = true;

        // Store the initial volume of the audio source
        float startVolume = forestAmbience.volume;

        // Gradually increase the volume of the audio source
        float currentTime = 0f;
        while (currentTime < fadeSpeed)
        {
            currentTime += Time.deltaTime;
            forestAmbience.volume = Mathf.Lerp(startVolume, 0.2f, currentTime / fadeSpeed);
            lowPassFilter.cutoffFrequency = 4000f;
            yield return null;
        }

        fadingOut = false;
    }
    
}
