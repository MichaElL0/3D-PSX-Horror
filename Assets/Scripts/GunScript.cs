using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class GunScript : MonoBehaviour
{
    public int damage = 50;
    public int range = 20;
    public LayerMask layerMask;

    public Camera cam;

    public ParticleSystem particle;
    public GameObject impact;
    public GameObject smoke;

    public Animator animator;

    private float timeBtwShoots;
    public float startTimeBtwShoots;

    public bool canShoot;
    

    


    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isAiming", false);
        cam.fieldOfView = 65f;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot == true)
        {
            if (timeBtwShoots <= 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    //print("SHOOT");
                    particle.Play();
                    Shoot();
                    CameraShaker.Instance.ShakeOnce(4f, 8f, 0.1f, 0.3f);
                    animator.SetTrigger("Shot");
                    timeBtwShoots = startTimeBtwShoots;
                    FindObjectOfType<AudioManager>().Play("shot");
                }

            }
            else
            {
                timeBtwShoots -= Time.deltaTime;
            }

            if (Input.GetButton("Fire2"))
            {
                //print("AIM");
                animator.SetBool("isAiming", true);
                cam.fieldOfView = 50f;
            }
            else
            {
                //print("Not aim");
                animator.SetBool("isAiming", false);
                cam.fieldOfView = 65f;
            }
        }
        else if (canShoot == false)
		{
            print("Can't shoot");
		}

        
    }

    void Shoot()
	{
		

		RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, layerMask))
		{
            //print("hit " + hit.point);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
			{
                enemy.TakeDamage(damage);
			}

            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            
            Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));

            
        }

		//FindObjectOfType<AudioManager>().Play("shoot");
        

	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
    }

    
}
