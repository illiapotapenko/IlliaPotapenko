using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnspeed = 20;
    public bool hasKey;
    public TextController textController;

    private Vector3 movement;
    private Animator animator;
    private Rigidbody rigidbody;
    private AudioSource audioSourse;
    private Quaternion rotation = Quaternion.identity;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        audioSourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movement.Set(horizontalInput, 0, verticalInput);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0);
        bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!audioSourse.isPlaying)
            {
                audioSourse.Play();
            }
        }
        else
        {
            audioSourse.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnspeed * Time.deltaTime, 0);
        rotation = Quaternion.LookRotation(desiredForward);
        
 }

    private void OnAnimatorMove()
    {
        rigidbody.MovePosition(rigidbody.position + movement * animator.deltaPosition.magnitude);
        rigidbody.MoveRotation(rotation);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Key key))
        {
            textController.Show(textController.pickUpKey);

            if (!hasKey && Input.GetKeyDown(KeyCode.F))
            {
                textController.Hide(textController.pickUpKey);
                hasKey = true;
               StartCoroutine(textController.ShowTextWithDelay(textController.findExit));
                Destroy(key.gameObject);
            }
        }
    }
}
