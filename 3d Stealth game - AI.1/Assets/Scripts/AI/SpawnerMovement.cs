using UnityEngine;
using System.Collections;

public class SpawnerMovement : customTimer {

    public float WanderRadius = 20.0f;

    public bool hasGoal = false;

    public Vector3 NewTarget;

    // Use this for initialization
    void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        spawnWander();
    }

    void spawnWander()
    {
        if (hasGoal == false)
        {
            NewTarget = Random.insideUnitSphere * WanderRadius;
            NewTarget += transform.position;
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = NewTarget;
            startTime = Time.time;
            hasGoal = true;
        }

        currentTime = Time.time;
        if ((startTime + 5.0f) <= currentTime)
        {
            hasGoal = false;
        }
    }

        // Update is called once per frame
        void Update () {
        spawnWander();
       
	}
}
