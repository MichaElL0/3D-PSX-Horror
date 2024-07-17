using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
	public Animator anim;
	public Animator anim2;
	public AudioSource audioS;
	public AudioSource audioS2;
	public AudioSource ring;

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			
			if ((GameManger.instance.counter % 2) != 0)
			{
				ring.Play();
			}

			audioS.Play();
			anim.SetTrigger("Open");
			anim2.SetTrigger("Open");
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			//print("Door is staying open");
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			//print("Close door");
			//print("Close door");
			//print("Close door");
			audioS2.Play();
			anim.SetTrigger("Close");
			anim2.SetTrigger("Close");
		}
	}
}
