﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackZone : MonoBehaviour {

	public List<GameObject> GOs;
	public GameObject arrow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			print ("Left click");
			attackGuards();
		}
		if (Input.GetMouseButtonDown (1)) {
			print ("Fire Arrow");
			shootArrow();
		}
	}

    void OnTriggerEnter(Collider Other)
    {
        if (Other.GetComponent<MoveTo>())
        {
            GOs.Add(Other.gameObject);
            print("Found an enemy");
        }
        else if (Other.GetComponent<eliteController>())
        {
            GOs.Add(Other.gameObject);
            print("Found an enemy");
        }
        else if (Other.GetComponent<rangedController>())
        {
            GOs.Add(Other.gameObject);
            print("Found an enemy");
        }
        else if (Other.GetComponent<AssassinationTargetController>())
        {
            GOs.Add(Other.gameObject);
            print("Found Ass Target");
        }
        else
            print("No enemies");
    }

    void shootArrow(){
		Vector3 thePos = gameObject.transform.position; 
		Instantiate (arrow, thePos, transform.rotation);
		//Vector3 shootPos = Input.mousePosition;
		//shootPos
	}


    void attackGuards()
    {
        print(GOs.Count);
        if (GOs.Count > 0)
        {
            for (int i = 0; i < GOs.Count; i++)
            {
                MoveTo guardMove = GOs[i].GetComponent<MoveTo>();
                eliteController eliteMove = GOs[i].GetComponent<eliteController>();
                rangedController rangeMove = GOs[i].GetComponent<rangedController>();
                AssassinationTargetController assMove = GOs [i].GetComponent<AssassinationTargetController> ();
                if (guardMove != null)
                {
                    guardMove.Health--;
                    print("Enemy Hurt");
                }
                if (eliteMove != null)
                {
                    eliteMove.Health--;
                    print("Enemy Hurt");
                }
                if (rangeMove != null)
                {
                    rangeMove.Health--;
                    print("Enemy Hurt");
                }
                if (assMove != null)
                {
                    assMove.Health--;
                    print("Enemy Hurt");
                }
            }
        }
    }
}
