using UnityEngine;
using System.Collections;

public class FlockController : MonoBehaviour
{
    private GameObject Controller;
    private bool initiated = false;
    private float minVelocity = 3;
    private float maxVelocity = 5;
    private float Variation;
    private GameObject Target;
    public Vector3 Alignment;

    void Start()
    {
        StartCoroutine("BoidSteering");
    }

    IEnumerator BoidSteering()
    {
        while (true)
        {
            if (initiated)
            {
                GetComponent<Rigidbody>().velocity = ((GetComponent<Rigidbody>().velocity + Calc() * Time.deltaTime) / 4);

                // enforce minimum and maximum speeds for the boids
                float speed = GetComponent<Rigidbody>().velocity.magnitude;
                if (speed > maxVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxVelocity;
                }
                else if (speed < minVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * minVelocity;
                }
            }

            float Delay = Random.Range(0.0f, 0.5f);
            yield return new WaitForSeconds(Delay);
        }
    }

    private Vector3 Calc()
    {
        Vector3 randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        BoidCreation boidController = Controller.GetComponent<BoidCreation>();
        Vector3 Center = boidController.Center;
        Vector3 Velocity = boidController.Velocity;
        Vector3 npcRand = Random.insideUnitSphere * 30.0f;
        Alignment = Target.transform.position + npcRand;

        Center = Center - transform.position;
        Velocity = Velocity - GetComponent<Rigidbody>().velocity;
        Alignment = Alignment - transform.position;

        return (Center + Velocity + Alignment + randomize * Variation);
    }

    public void SetController(GameObject theController)
    {
        Controller = theController;
        BoidCreation boidController = Controller.GetComponent<BoidCreation>();
        minVelocity = boidController.minVelocity;
        maxVelocity = boidController.maxVelocity;
        Variation = boidController.Variation;
        Target = boidController.Target;
        initiated = true;
    }
}