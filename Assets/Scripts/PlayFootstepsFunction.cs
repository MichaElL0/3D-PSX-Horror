using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepsFunction : MonoBehaviour
{
    public AudioSource footsteps;

    public void PlayFootstepSound()
    {
        if (footsteps != null)
        {
            footsteps.pitch = Random.Range(0.90f, 1.05f);
            footsteps.volume = Random.Range(0.85f, 0.95f);
            footsteps.Play();
        }
    }
}
