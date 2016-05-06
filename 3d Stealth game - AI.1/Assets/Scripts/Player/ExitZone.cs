﻿using UnityEngine;
using System.Collections;

public class ExitZone : buttonScript {

    public GameObject escortObject;
    public GameObject playerObject;
    public GameObject lastCheckpoint;
   // public GameObject AssinationTarget;

    public Light illuminateObject;
    bool increaseLight;

    static public bool objectiveCompleted;
    static public float endGameTimer;

	// Use this for initialization
	void Start () {
        objectiveCompleted = false;
        endGameTimer = 5.0f;
        increaseLight = true;
        illuminateObject.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectiveCompleted)
        {
            endGameTimer -= Time.deltaTime;
            if (endGameTimer <= 0)
            {
                Application.LoadLevel(0);
                StealObjectScript.isObjectTaken = false;
                GUIMainMenu.escortGameMode = false;
                GUIMainMenu.stealGameMode = false;
                GUIMainMenu.escapeGameMode = false;
                GUIMainMenu.assassinateGameMode = false;
            }
        }
        if (StealObjectScript.isObjectTaken || GUIMainMenu.escortGameMode || CheckpointZone.playerHitLastCheckpoint || AssassinationTargetController.isTargetDead)
        {
            illuminateExitZone();
        }
    }

    protected override void OnTriggerStay(Collider other)
    {
        if(StealObjectScript.isObjectTaken || (Vector3.Distance(playerObject.transform.position, escortObject.transform.position) <= 5) || CheckpointZone.playerHitLastCheckpoint || AssassinationTargetController.isTargetDead)
        {
			if (other.gameObject.tag == "Player")
            TriggerAction();
        }

    }

    protected override void TriggerAction()
    {
        objectiveCompleted = true;
    }

    void illuminateExitZone()
    {
        if (illuminateObject.intensity >= 8)
        {
            increaseLight = false;
        }
        else if (illuminateObject.intensity <= 0)
        {
            increaseLight = true;
        }

        if (increaseLight == true)
        {
            illuminateObject.intensity += 0.1f;

        }
        else if (increaseLight == false)
        {
            illuminateObject.intensity -= 0.1f;
        }
    }
}
