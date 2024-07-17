using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareTrigger : MonoBehaviour
{
	public GameObject body;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			body.SetActive(true);
		}
	}
}
