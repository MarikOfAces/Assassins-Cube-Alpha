using UnityEngine;
using System.Collections;

public class SmokeBomb : MonoBehaviour {

	bool useGrenade = false;
	public GameObject grenadePrefab;
	public GameObject player;

	float dropTime = 0.0f;
	float Duration = 10.0f;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	if ((Input.GetKeyDown(KeyCode.G)) && (useGrenade == false)) 
		{
			useGrenade = true;
			transform.position = player.transform.position;

		}
		if (useGrenade) {
			if (transform.localScale.y < 10.1f)
			{
				//transform.position = player.transform.position;
				gameObject.GetComponent<MeshRenderer>().enabled = true;
				gameObject.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
			}
			else
			{
				gameObject.GetComponent<MeshRenderer>().enabled = false;
				gameObject.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
					gameObject.transform.position -= new Vector3(0.0f,-20.0f,0.0f);
				useGrenade = false;
			}
		}

	}
}
