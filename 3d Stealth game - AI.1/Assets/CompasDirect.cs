using UnityEngine;
using System.Collections;

public class CompasDirect : MonoBehaviour {
	 
	public GameObject playerPrefab;
	public GameModeSelected gameMode;
    public GameObject ExitZone;

    // Use this for initialization
    void Start () {
		gameMode = playerPrefab.GetComponent<GameModeSelected> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameMode != null) {
			
				print ("ROTATE COMPAS");
            if (gameMode.currentObjective != null)
				transform.LookAt (gameMode.currentObjective.transform.position);
			}


       

        if (gameMode.AssassinationTarget ==  null)
         {
            print("HGCKSH SKJLKJCAKJXH KCGKJX");
             transform.LookAt(ExitZone.transform.position);
         }

        if ( Vector3.Distance(gameMode.escortObject.transform.position, playerPrefab.transform.position) <= 10)
        {
            transform.LookAt(ExitZone.transform.position);
        }

        if (StealObjectScript.isObjectTaken)
        {
            transform.LookAt(ExitZone.transform.position);
        }
       
    }
}
