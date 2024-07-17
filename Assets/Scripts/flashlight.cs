using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject flashlightLight;
    private bool flashlightEnabled = false;


    // Start is called before the first frame update
    void Start()
    {
        flashlightLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.F))
		{
            if(flashlightEnabled == false)
			{
                flashlightLight.gameObject.SetActive(true);
                flashlightEnabled = true;
                FindObjectOfType<AudioManager>().Play("flashlight");


            }
            else
			{
                flashlightLight.gameObject.SetActive(false);
                flashlightEnabled = false;
                FindObjectOfType<AudioManager>().Play("flashlight");

            }
		}
    }
}
