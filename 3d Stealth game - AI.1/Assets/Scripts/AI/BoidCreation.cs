using UnityEngine;
using System.Collections;

public class BoidCreation : MonoBehaviour
{
    public float minVelocity = 3;
    public float maxVelocity = 5;
    public float Variation = 2;
    public int Size = 5;
    public GameObject clone;
    public GameObject Target;

    public Vector3 Center;
    public Vector3 Velocity;

    public GameObject[] boids;
    

    void Start()
    {
        
        boids = new GameObject[Size];
        for (var i = 0; i < Size; i++)
        {
            transform.position = new Vector3(30,3,30);


           // Vector3 position = new Vector3(5,5,5);
            Vector3 position = Random.insideUnitSphere * 7;
            position += transform.position;

           // float rotation = Random.Range(0.0f, 120.0f);


            GameObject boid = Instantiate(clone, position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<FlockController>().SetController(gameObject);
            boids[i] = boid;
        }
        }
    

    void Update()
    {
        Vector3 theCenter = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;

        foreach (GameObject boid in boids)
        {
            theCenter = Target.transform.position;
            theVelocity = theVelocity + boid.GetComponent<Rigidbody>().velocity;
        }

        Center = Target.transform.position * Random.Range(0.1f,1.9f);
        Velocity = (theVelocity / (Size) / 2);

    }
}