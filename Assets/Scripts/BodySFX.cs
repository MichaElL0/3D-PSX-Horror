using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySFX : MonoBehaviour
{
	public AudioSource bodyHit;
	public AudioSource keysHit;

	public Rigidbody rb;

	private void Start()
	{
		
	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "forest")
		{
			if (bodyHit.isPlaying == false)
			{
				bodyHit.Play();
				keysHit.Play();

				StartCoroutine(KinematicTrigger());

				print("HIT");
			}
		}
	}

	public IEnumerator KinematicTrigger()
	{
		yield return new WaitForSeconds(2);

		rb.isKinematic = true;


	}
	
}
