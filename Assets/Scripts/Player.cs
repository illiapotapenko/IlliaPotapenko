using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private GameObject plate;
   [SerializeField] private float rotationspeed;
   
   private AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        plate.transform.Rotate(Vector3.up,rotationspeed*Time.deltaTime);
    }
}
