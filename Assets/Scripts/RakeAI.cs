using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RakeAI : MonoBehaviour
{
    public GameObject player;

    public NavMeshAgent agent;

    public Animator animator;

    bool doChase = false;

    public PlayerMovement playerScript;

    public AudioSource audio;

    public GunScript script;

    public AudioSource audioScream;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doChase == true)
		{
            animator.SetTrigger("Chase");
            Chase();
            
        }
    }

    public void Chase()
	{
        agent.SetDestination(player.transform.position);
        
	}

    public void ChaseBool()
	{
        doChase = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            print("PLAYER DIE");

            playerScript.Die();
            audioScream.Stop();

        }
	}

    public void Stop()
	{
        audio.Stop();
	}

    public void Shoot()
	{
        script.canShoot = true;
	}

    public void Scream()
	{
        audioScream.Play();
	}
}
