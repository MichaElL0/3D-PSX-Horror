using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public AudioSource audio;

    public bool isCoffeeDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
	{
        audio.Play();
	}

    public void Done()
	{
        isCoffeeDone = true;
    }
}
