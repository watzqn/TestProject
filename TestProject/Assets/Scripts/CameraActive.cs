using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActive : MonoBehaviour {

    //variables
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Player1;
    public GameObject Player2;
    PlayerMovement Script1;
    PlayerMovement Script2;
	
    void Start()
    {
        //assigning script variables to actual scripts
        Script1 = Player1.GetComponent<PlayerMovement>();
        Script2 = Player2.GetComponent<PlayerMovement>();
    }

	// Update is called once per frame
	void Update () {
        //Change Camera and Script on Button Press
		if(Input.GetKeyDown(KeyCode.F))
        {
            if (Camera1.activeInHierarchy == true)
            {
                Camera1.SetActive(false);
                Camera2.SetActive(true);

                Script1.enabled = false;
                Script2.enabled = true;
            }
            else
            {
                Camera2.SetActive(false);
                Camera1.SetActive(true);

                Script2.enabled = false;
                Script1.enabled = true;
            }
        }
	}
}
