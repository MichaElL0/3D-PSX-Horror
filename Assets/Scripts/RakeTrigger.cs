using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakeTrigger : MonoBehaviour
{
    public GameObject rake;

    public AudioSource step;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            step.Play();

            Destroy(step, 0.5f);

            rake.GetComponent<Animator>().SetTrigger("Turn");

            Destroy(gameObject, 1f);

		}
	}
}
