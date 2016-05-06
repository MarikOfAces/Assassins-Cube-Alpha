using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointZone : buttonScript
{
    public List<GameObject> checkpointList;


    bool checkListhasSetup;
    public Light illuminateObject;
    bool increaseLight;

    static public bool objectiveCompleted;
    static public float endGameTimer;

    static public int checkpointCount;
    public int checkpointNumber;

    public bool isLastCheckpoint;
    static public bool playerHitLastCheckpoint;

    void Start()
    {
        objectiveCompleted = false;
        endGameTimer = 5.0f;
        increaseLight = true;
        illuminateObject.intensity = 0;
        checkpointCount = 1;
        playerHitLastCheckpoint = false;
        checkListhasSetup = false;
    }

    void Update()
    {
       // print("checkpoint number is " + checkpointNumber);
        if (checkpointCount == checkpointNumber)
        {
            illuminateCheckpointZone();
        }
        else { illuminateObject.intensity = 0; }
        //if (!checkListhasSetup)
        //{
        //    print("checkpoint number is " + checkpointNumber);
        //    checkpointList[checkpointNumber].add = gameObject;

        //    print(gameObject.name);
        //    checkListhasSetup = true;
        //}
    }

    protected void OnTriggerEnter(Collider other)
    {
        TriggerAction();
    }

    protected override void TriggerAction()
    {
        checkpointCount++;
        if(isLastCheckpoint)
        {
            playerHitLastCheckpoint = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void illuminateCheckpointZone()
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
