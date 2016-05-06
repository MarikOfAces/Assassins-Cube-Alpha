using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListOurPoints : MonoBehaviour {
    public List<GameObject> CheckList;
	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            CheckList.Add(child.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {


    }
}
