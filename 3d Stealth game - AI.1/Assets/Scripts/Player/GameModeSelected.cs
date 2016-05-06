using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModeSelected : MonoBehaviour {

    public GameObject stealableObject;
    public GameObject escortObject;
    public GameObject Checkpoints;
    public GameObject AssassinationTarget;
    public GameObject exitZone;

    public CheckpointZone checkpointZone;
    public List<GameObject> checkpointObjective;

    public GameObject currentObjective;

	public bool GameModeSet;

    // Use this for initialization
    void Start () {
        stealableObject.SetActive(false);
        escortObject.SetActive(false);
        Checkpoints.SetActive(false);
        AssassinationTarget.SetActive(false);
        currentObjective = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameModeSet)
		{


	        if (GUIMainMenu.noGameMode)
	        {
	            GUIMainMenu.escortGameMode = false;
	            GUIMainMenu.escapeGameMode = false;
	            GUIMainMenu.stealGameMode = false;
	            GUIMainMenu.assassinateGameMode = false;
	        }

	        if (GUIMainMenu.stealGameMode && StealObjectScript.isObjectTaken == false)
	        {
	            stealableObject.SetActive(true);
	            GUIMainMenu.escortGameMode = false;
	            GUIMainMenu.escapeGameMode = false;
	            GUIMainMenu.assassinateGameMode = false;
	            GUIMainMenu.noGameMode = false;
                currentObjective = stealableObject;
	        }

	        if (GUIMainMenu.escortGameMode)
	        {
	            escortObject.SetActive(true);
	            GUIMainMenu.stealGameMode = false;
	            GUIMainMenu.escapeGameMode = false;
	            GUIMainMenu.assassinateGameMode = false;
	            GUIMainMenu.noGameMode = false;
                currentObjective = escortObject;
            }

	        if(GUIMainMenu.escapeGameMode)
	        {
	            Checkpoints.SetActive(true);
	            GUIMainMenu.stealGameMode = false;
	            GUIMainMenu.escortGameMode = false;
	            GUIMainMenu.assassinateGameMode = false;
	            GUIMainMenu.noGameMode = false;
                currentObjective = Checkpoints;
            }

	        if(GUIMainMenu.assassinateGameMode)
	        {
		            AssassinationTarget.SetActive(true);
		            GUIMainMenu.stealGameMode = false;
		            GUIMainMenu.escortGameMode = false;
		            GUIMainMenu.escapeGameMode = false;
		            GUIMainMenu.noGameMode = false;
                    currentObjective = AssassinationTarget;
            }
			GameModeSet = true;
		}
        // print("WE GOT HERE COS LOL");
        print("checkpointZone number is " + CheckpointZone.checkpointCount);
        if (GUIMainMenu.escapeGameMode)
        {
            if(CheckpointZone.playerHitLastCheckpoint)
            {
                currentObjective = exitZone;
            }
            currentObjective = Checkpoints.GetComponent<ListOurPoints>().CheckList[CheckpointZone.checkpointCount-1];






               // if (CheckpointZone.checkpointCount == checkpointZone.checkpointNumber)
               // {

               //currentObjective = checkpointObjective[CheckpointZone.checkpointCount].gameObject;

           // }
        }
            
    }
}
