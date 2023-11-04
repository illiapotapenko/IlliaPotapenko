using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explosion;

    private Rigidbody targetRb;
    private GameManager gameManager;

    private float minSpeed = 12;
    private float maxSpeed = 17;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        transform.position = RandomSpawnPos();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }


    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

   

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.TryGetComponent(out Bad bad)&& gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1 );
        }
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameManager.UpdateScore(pointValue);
        }
    }
} 