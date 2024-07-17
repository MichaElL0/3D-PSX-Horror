using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamTrigger : MonoBehaviour
{
	public AudioSource audio;

	bool isPlay = false;

	public MouseLook script;

	


	private void Update()
	{
		if (isPlay == true)
		{
			if(audio.isPlaying == false)
			{
				//audio.Play();

				StartCoroutine(Scream());

				
			}

			
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			isPlay = true;
		}
		
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			isPlay = false;
		}
	}

	IEnumerator Scream()
	{
		audio.Play();

		yield return new WaitForSeconds(5);

		audio.enabled = false;

		StartCoroutine(script.DescribeSelf("What the fuck..."));

		yield return new WaitForSeconds(4);

		Destroy(gameObject);
	}

}
