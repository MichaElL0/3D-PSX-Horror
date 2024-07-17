using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndngScript : MonoBehaviour
{
	public AudioSource audio;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			audio.Play();
			StartCoroutine(Wait());
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(4.5f);

		SceneManager.LoadScene("Ending");
	}
}
