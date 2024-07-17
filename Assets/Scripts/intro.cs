using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public AudioSource audioSource;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.isPlaying == false)
		{
            anim.SetTrigger("Fade");
            //SceneManager.LoadScene("The game");
		}
    }

    public void LoadScene()
	{
        SceneManager.LoadScene("The game");
    }
}
