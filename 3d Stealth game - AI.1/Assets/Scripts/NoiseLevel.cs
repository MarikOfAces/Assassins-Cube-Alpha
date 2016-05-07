using UnityEngine;
using System.Collections;

public class NoiseLevel : MonoBehaviour {

    public int floorType;

    float floorNoise;

    float footStep;
    public GameObject player;
    public PlayerMovement pMovement;

	// Use this for initialization
	void Start () {
        floorNoise = 1;
        pMovement = player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        footStep = floorType* floorNoise;
	
	}

    protected void OnTriggerEnter(Collider other)
    {
        print("lololololololololol");
        pMovement.Noise = footStep;

    }


}
