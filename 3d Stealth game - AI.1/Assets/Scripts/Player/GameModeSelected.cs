using UnityEngine;
using System.Collections;

public class GameModeSelected : MonoBehaviour {

    public GameObject stealableObject;
    public GameObject escortObject;
    public GameObject Checkpoints;
    public GameObject AssassinationTarget;
	public bool GameModeSet;

    // Use this for initialization
    void Start () {
        stealableObject.SetActive(false);
        escortObject.SetActive(false);
        Checkpoints.SetActive(false);
        AssassinationTarget.SetActive(false);
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
	        }

	        if (GUIMainMenu.escortGameMode)
	        {
	            escortObject.SetActive(true);
	            GUIMainMenu.stealGameMode = false;
	            GUIMainMenu.escapeGameMode = false;
	            GUIMainMenu.assassinateGameMode = false;
	            GUIMainMenu.noGameMode = false;
	        }

	        if(GUIMainMenu.escapeGameMode)
	        {
	            Checkpoints.SetActive(true);
	            GUIMainMenu.stealGameMode = false;
	            GUIMainMenu.escortGameMode = false;
	            GUIMainMenu.assassinateGameMode = false;
	            GUIMainMenu.noGameMode = false;
	        }

	        if(GUIMainMenu.assassinateGameMode)
	        {
		            AssassinationTarget.SetActive(true);
		            GUIMainMenu.stealGameMode = false;
		            GUIMainMenu.escortGameMode = false;
		            GUIMainMenu.escapeGameMode = false;
		            GUIMainMenu.noGameMode = false;
	        }
			GameModeSet = true;
		}
    }
}
