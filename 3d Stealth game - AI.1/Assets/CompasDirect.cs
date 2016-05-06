using UnityEngine;
using System.Collections;

public class CompasDirect : MonoBehaviour {
	 
	public GameObject playerPrefab;
	public GameModeSelected gameMode;

	// Use this for initialization
	void Start () {
		gameMode = playerPrefab.GetComponent<GameModeSelected> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameMode != null) {
			if (gameMode.stealableObject.activeSelf) {
				print ("ROTATE COMPAS");
				print (gameMode.stealableObject.transform.position);
				transform.LookAt (gameMode.stealableObject.transform.position);
			}
			if (gameMode.escortObject.activeSelf) {
				print ("ROTATE COMPAS");
				transform.LookAt (gameMode.escortObject.transform.position);
			}
			if (gameMode.AssassinationTarget.activeSelf) {
				print ("ROTATE COMPAS");
				transform.LookAt (gameMode.AssassinationTarget.transform.position);
			}
			if (gameMode.Checkpoints.activeSelf) {
				print ("ROTATE COMPAS");
				transform.LookAt (gameMode.stealableObject.transform.position);
			}
		}
	}
}
