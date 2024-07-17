using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
	public MouseLook script;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			print("Block");

			StartCoroutine(script.DescribeSelf("(I need to get coffee)"));
		}
	}
}
