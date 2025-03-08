using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private GameInput _gameInput;

    private bool isWalking;
    
    private void Update()
    {
        Vector2 inputVector = _gameInput.GetMovementVector();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDirection * Time.deltaTime * moveSpeed;

        isWalking = moveDirection != Vector3.zero;
        
        transform.forward = Vector3.Slerp(transform.forward,moveDirection,Time.deltaTime * turnSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
