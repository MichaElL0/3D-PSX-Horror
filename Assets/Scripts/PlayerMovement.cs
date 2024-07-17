using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 5f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public AudioClip[] footstpsClips;
    public AudioSource footsteps;

    bool isMoving = false;

    public string floorTag;
    public LayerMask floorMask;

    public Camera cam;

    Vector3 velocity;

    public Animator cameraAnimator;

    public MouseLook mouselook;

    public GameObject screenDeath;


    // Update is called once per frame
    void Start()
    {
        

        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        

        //Move player
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = Vector3.Normalize(transform.right * x + transform.forward * z);
        controller.Move(move * movementSpeed * Time.deltaTime);

        


        if (x != 0 || z != 0)
        {
            //print("Is moving");
            cameraAnimator.SetBool("isWalking", true);
            isMoving = true;
            
        }
        else
        {
            cameraAnimator.SetBool("isWalking", false);
            isMoving = false;
            
        }

        if(isMoving == true && Input.GetKey(KeyCode.LeftShift)) 
        {
            //print("Player is spriting");
            cameraAnimator.SetBool("isSprinting", true);
            movementSpeed = 8f;
        }
        else 
		{
            movementSpeed = 5f;
            cameraAnimator.SetBool("isSprinting", false);
            //print("Is not spriting");
        }

        RaycastHit floorHit;

        Physics.Raycast(cam.transform.position, Vector3.down, out floorHit, 10, floorMask);

        floorTag = floorHit.transform.gameObject.tag;

        switch (floorTag)
        {
            case "kafelki":
                footsteps.clip = footstpsClips[0];
                //print("Kafelki");
                break;
            case "street":
                footsteps.clip = footstpsClips[1];
                //print("Droga");
                break;
            case "forest":
                footsteps.clip = footstpsClips[2];
                //print("Droga leœna");
                break;
            default:
                print("No clip!");
                footsteps.clip = footstpsClips[1];
                break;

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Die()
	{
        print("Player DIE");
        screenDeath.SetActive(true);
        SceneManager.LoadScene("Die ending");
        //Switch scene
        //Play sound
        //END title
	}


}
