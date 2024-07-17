using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBlock : MonoBehaviour
{
	public MouseLook script;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			print("Block");

			StartCoroutine(script.DescribeSelf("(Why would I go there? Am here for the coffee!)"));
		}
	}
}
