using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrompt : MonoBehaviour
{
    public MouseLook mouselook;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
            print("DAMN");
            StartCoroutine(mouselook.DescribeSelf("(I need to get coffee)"));
            print("SHIT");
            
            
        }
	}

	
}
