using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    private float minVelocity = 12.0f;
    private float maxVelocity = 16.0f;
    private float maxTorque = 10.0f;
    private float minTorque = -10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -2.0f;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

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

    /** This method checks for clicks on the target objects and updates the score
     * 
     */
    /*  We are disabling this to enable the click-and-swipe functionality; this has been made redundant due to the destroy target method
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    */

    /** This function is implemented to aid with the trail/click-and-swipe collision system we implemented
     * 
     */
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }


    /** This method mostly destroys the objects when they hit the sensor object collider looming at the bottom of the camera
     * 
     */
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.UpdateLives(-1);
        }
    }

    
}
