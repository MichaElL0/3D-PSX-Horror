using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    public int counter = 1;

    public bool isDoorOpen1 = false;
    public bool isDoorOpen2 = false;

	private void Awake()
	{
        if (instance == null)
		{
            instance = this;
        }
        else if(instance != this)
		{
            Destroy(gameObject);
		}

		
	}


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
