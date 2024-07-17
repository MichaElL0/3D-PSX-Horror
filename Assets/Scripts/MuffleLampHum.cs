using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffleLampHum : MonoBehaviour
{
    public AudioSource[] lampSource;
    
    public float fadeSpeed = 10;

    private bool fadingOut = false;


	private void Start()
	{
        //lampSource.enabled = false;
        foreach(AudioSource source in lampSource)
		{
            source.enabled = false;
        }
    }

	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GameManger.instance.counter += 1;
            


            if ((GameManger.instance.counter % 2) == 0)
            {
                foreach (AudioSource source in lampSource)
                {
                    source.enabled = true;
                }
               
            }
            else if ((GameManger.instance.counter % 2) != 0)
            {
                //StartCoroutine(FadeOut());
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //counter++;
            //print(GameManger.instance.counter);
            

            if ((GameManger.instance.counter % 2) == 0)
            {

            }
            else if ((GameManger.instance.counter % 2) != 0)
            {
                foreach (AudioSource source in lampSource)
                {
                    source.enabled = false;
                }
               

            }



        }
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        fadingOut = true;
        float currentTime = 0f;
        // Store the initial volume of the audio source
        float startVolume = 0f;
        foreach (AudioSource source in lampSource)
        {
            startVolume = source.volume = Mathf.Lerp(startVolume, 0f, currentTime / fadeSpeed);
        }


        // Gradually increase the volume of the audio source

        while (currentTime < fadeSpeed)
        {
            currentTime += Time.deltaTime;
            //lampSource.volume = Mathf.Lerp(startVolume, 1f, currentTime / fadeSpeed);
            foreach (AudioSource source in lampSource)
            {
                source.volume = Mathf.Lerp(startVolume, 0f, currentTime / fadeSpeed);
            }

            yield return null;
        }

        fadingOut = false;
    }

    IEnumerator FadeOut()
    {
        fadingOut = true;
        float currentTime = 0f;
        // Store the initial volume of the audio source
        float startVolume = 0f;
        foreach (AudioSource source in lampSource)
        {
            startVolume = source.volume = Mathf.Lerp(startVolume, 1f, currentTime / fadeSpeed);
        }


        // Gradually increase the volume of the audio source
        
        while (currentTime < fadeSpeed)
        {
            currentTime += Time.deltaTime;
            //lampSource.volume = Mathf.Lerp(startVolume, 1f, currentTime / fadeSpeed);
            foreach (AudioSource source in lampSource)
            {
                source.volume = Mathf.Lerp(startVolume, 1f, currentTime / fadeSpeed);
            }

            yield return null;
        }

        fadingOut = false;
    }
    IEnumerator FadeOut2()
    {
        fadingOut = true;

        // Store the initial volume of the audio source
        //float startVolume = lampSource.volume;

        // Gradually increase the volume of the audio source
        float currentTime = 0f;
        while (currentTime < fadeSpeed)
        {
            currentTime += Time.deltaTime;
            //lampSource.volume = Mathf.Lerp(startVolume, 0.2f, currentTime / fadeSpeed);
            
            yield return null;
        }

        fadingOut = false;
    }
}
