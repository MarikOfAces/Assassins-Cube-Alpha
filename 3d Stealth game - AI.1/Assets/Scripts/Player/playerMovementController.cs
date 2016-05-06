﻿using UnityEngine;
using System.Collections;

public class playerMovementController : customTimer {
	
	public static bool useAction = false;
	public static bool usePressed = false;
    public static bool crouchHeld = false;
    public static bool jumpPressed = false;

    public bool knockout = false;
	public bool attack = false;
	
	public int movementType = 0; //0 = Walk, 1 = stealth, 2 = run
	
	public static bool detectable = true;
	public bool detView = detectable;
	public bool timerDone;
	public bool interactable = true;

	
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouchHeld = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouchHeld = false;
        }
	
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
		else {
			jumpPressed = false;
		}


        //KEYDOWN
        if (interactable)
		{
			if (Input.GetKeyDown(KeyCode.E) && usePressed)
			{
				//usePressed = false;
				useAction = false;
				//print("TOGGLE OFF");
				
			}
			else if (Input.GetKeyDown(KeyCode.E) && !usePressed)
			{
				usePressed = true;
				useAction = true;
				//print("TOGGLE ON" + useAction);
				
			}

		}
		
		
		//KEYUP
		if (Input.GetKeyUp(KeyCode.E))
		{
			//usePressed = false;
		}
		
		//        if(usePressed)
		//        {
		//                //interactable = false;
		//                //useAction = true;
		//                if (ourTimer(1))
		//                {
		//                    Debug.Log("Timer ended");
		//                    interactable = true;
		//                    useAction = false;
		//                    usePressed = false;
		//                }
		//
		//        }
		//        else
		//        {
		//
		//        }
		
	}
}