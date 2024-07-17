using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100;

    public Transform playerbody;

    float xRotation = 0;

    public LayerMask mask;

    public Image dot;

    public TMP_Text description;

	[HideInInspector]
    public RaycastHit hit;

    public GameObject panel;

    public bool isNoteActive;

    public AudioSource[] audiosToNotIgnore;

    public GunScript gunScript;

    public AudioSource paper;

    public float distanceToDetectObjects = 2f;

    //

    public AudioSource door1;
    public AudioSource door2;
    public AudioSource doorLocked;

    public GameObject storyBlock;

    public GameObject gun;

    public GameObject counterDescp;

    public GameObject noteOOO;
    public GameObject noteOOO2;
    
    

    // Start is called before the first frame update
    void Start()
    {
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        description.enabled = false;
        panel.gameObject.SetActive(false);
        isNoteActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerbody.Rotate(Vector3.up * mouseX);

        //Looking at objects

        

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mask))
        {
            var obj = hit.collider.gameObject;
            float dist = Vector3.Distance(obj.transform.position, transform.position);


            if (obj.tag == "Building")
            {
                DeafultDot();
            }


            if (dist < distanceToDetectObjects)
			{
                
                if(obj.tag == "Building")
				{
                    DeafultDot();
                    print("Cant read");
				}
                else if(obj.tag == "Note" || obj.tag == "Describe")
				{
                    ChangeDot();

                    if(panel.activeSelf == true)
					{
                        print("Cant describe");
					}
                    else if(panel.activeSelf == false)
					{
                        if (Input.GetKeyDown(KeyCode.E) && obj.tag == "Note")
                        {
                            if(isNoteActive == false)
							{
                                StartCoroutine(NoteReadOn());

                                isNoteActive = true;

                                print("Read");
                            }
                            
                        }
                        else if (Input.GetKeyDown(KeyCode.E) && obj.tag == "Describe")
                        {
                            print("Describe");
                            StartCoroutine(Describe());

                        }
                    }

                }

                

            }          
            else if(dist > distanceToDetectObjects)
            {
                DeafultDot();
            }


            if(dist < 4)
			{
                if(obj.tag == "Door" || obj.tag == "Door2")
				{
                    ChangeDot();

                    var doorAnimator = hit.collider.GetComponentInParent<Animator>();


                    if (obj.tag == "Door" && Input.GetKeyDown(KeyCode.E))
                    {

                        door1.Play();

                        print("Door1");

                        Destroy(storyBlock);

                        gun.SetActive(true);
                       
                        //gunpickup.enabled = false;

                        if (GameManger.instance.isDoorOpen1 == false)
                        {
                            GameManger.instance.isDoorOpen1 = true;
                            doorAnimator.SetTrigger("Open");
                            doorAnimator.SetBool("isOpen", true);
                        }
                        else if (GameManger.instance.isDoorOpen1 == true)
                        {
                            doorAnimator.SetBool("isOpen", false);
                            GameManger.instance.isDoorOpen1 = false;
                            
                            
                        }
                    }
                    else if (obj.tag == "Door2" && Input.GetKeyDown(KeyCode.E))
                    {
                        door2.Play();

                        print("Door2");

                        if (GameManger.instance.isDoorOpen2 == false)
                        {
                            GameManger.instance.isDoorOpen2 = true;
                            doorAnimator.SetTrigger("Open");
                            doorAnimator.SetBool("isOpen", true);
                        }
                        else if (GameManger.instance.isDoorOpen2 == true)
                        {
                            doorAnimator.SetBool("isOpen", false);
                            GameManger.instance.isDoorOpen2 = false;
                        }
                    }
                    
                }
                else if (obj.tag == "DoorBlock")
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if(doorLocked.isPlaying == false)
						{
                            print("Play sound");
                            doorLocked.Play();
                        }

                        
                    }

                    DeafultDot();
                    print("DONT OPEN DOOR");
                }

            }

            if(dist < 2)
			{
                if (obj.tag == "Coffee")
                {
                    ChangeDot();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.GetComponent<Animator>().SetTrigger("Coffee");
                        
                    }

                    if (hit.collider.GetComponent<Coffee>().isCoffeeDone == true)
                    {
                        DeafultDot();
                        print("DONE");

                        StartCoroutine(DescribeSelf("(I should go to the counter and pay for it first.)"));

                        counterDescp.SetActive(true);

                    }

                }

            }

        }
        else
		{
           DeafultDot();
        }




        if (isNoteActive == true && Input.GetKeyDown(KeyCode.Space))
        {
            
            print("Close note");
            StartCoroutine(NoteReadOff());
            
        }


    }

    void ChangeDot()
	{
        //dot.localScale = new Vector3(2, 2, 1);
        dot.color = new Color32(183, 0, 0, 255);
    }

    void DeafultDot()
	{
        //dot.localScale = new Vector3(1, 1, 1);
        dot.color = new Color32(255, 255, 255, 255);
    }

    
    public IEnumerator Describe()
    {
        description.enabled = true;
        panel.gameObject.SetActive(true);


        description.fontSize = hit.collider.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().fontSize;
        description.text = hit.collider.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text;
        yield return new WaitForSeconds(4);

        description.enabled = false;
        panel.gameObject.SetActive(false);
    }

    public IEnumerator DescribeSelf(string descpt)
    {
        description.enabled = true;
        panel.gameObject.SetActive(true);

        description.text = descpt;   
        yield return new WaitForSeconds(4);

        description.enabled = false;
        panel.gameObject.SetActive(false);
    }

    public IEnumerator NoteReadOn()
	{
        //Open note
        paper.Play();
        hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0f;

        AudioListener.pause = true;

        gunScript.canShoot = false;

        foreach(AudioSource audio in audiosToNotIgnore)
		{
            audio.ignoreListenerPause = true;
		}

        //AudioListener.pause = true;
        yield return null;

    }
    public IEnumerator NoteReadOff()
	{
        //Close note
        isNoteActive = false;

        hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1f;


        FindObjectOfType<AudioManager>().Play("Deselect");

        AudioListener.pause = false;

        gunScript.canShoot = true;

        foreach (AudioSource audio in audiosToNotIgnore)
        {
            audio.ignoreListenerPause = true;
        }


        //AudioListener.pause = false;

        yield return null;

    }

	
}
