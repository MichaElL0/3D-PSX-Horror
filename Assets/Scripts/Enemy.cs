using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 100;

	public AudioSource audio;

	public Animator rake;

	public NavMeshAgent agent;

	public Rigidbody rb;

	public GameObject rakeG;

	public GameObject blood;

	public ParticleSystem particle;

	public Transform bloodPos;

	public AudioSource bloodAudio;

	public GameObject endingTrigger;

	public MouseLook mouseLook;

	public AudioSource death;

	public Collider collider;

	public GameObject descp;

    public void TakeDamage(int damage)
	{
		health -= damage;

		bloodAudio.Play();

		Instantiate(particle, bloodPos.position, Quaternion.identity);

		if(health <= 0)
		{
			Die();

		}
	}

	void Die()
	{
		descp.SetActive(true);

		collider.enabled = false;
		audio.Stop();
		death.Play();
		print("Enemy DIED");
		//Play death sound

		StartCoroutine(waitForSeconds());

		//StartCoroutine(mouseLook.DescribeSelf("(...)"));
		//StartCoroutine(mouseLook.DescribeSelf("(I need to report all this shit.\n\nI have radio in my car.)"));


		agent.enabled = false;

		rake.enabled = false;
		StartCoroutine(wait());
		endingTrigger.SetActive(true);
		
	}

	IEnumerator wait()
	{
		blood.transform.position = rakeG.transform.position;
		blood.SetActive(true);

		yield return new WaitForSeconds(2f);

		rb.isKinematic = true;
	}

	IEnumerator waitForSeconds()
	{
		yield return new WaitForSeconds(3f);

		StartCoroutine(mouseLook.DescribeSelf("(...)"));

		yield return new WaitForSeconds(4f);

		StartCoroutine(mouseLook.DescribeSelf("(I need to report all this shit.\n\nI have radio in my car.)"));
	}
}
