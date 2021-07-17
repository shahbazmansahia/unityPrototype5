using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minVelocity = 12.0f;
    private float maxVelocity = 16.0f;
    private float maxTorque = 10.0f;
    private float minTorque = -10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -2.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        
        // Generates a random amount of force to swing the object to a certain height value
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // Adding torque to give the swung objects some spin FX; the intensity of the spin on each axis is randomized
        targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);


        transform.position = RandomSpawnPos();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return (Vector3.up * Random.Range(minVelocity, maxVelocity));
    }

    Vector3 RandomTorque()
    {
        
        return (new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
    }
    Vector3 RandomSpawnPos()
    {
        return (new Vector3(Random.Range(-xRange, xRange), ySpawnPos));
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
