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

        float playerRadius = 0.7f;
        float playerHeight = 2.0f;
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove =  !Physics.CapsuleCast(transform.position,transform.position+Vector3.up*playerHeight,playerRadius,moveDirection,moveDistance);

        if (canMove == false)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove =  !Physics.CapsuleCast(transform.position,transform.position+Vector3.up*playerHeight,playerRadius,moveDirectionX,moveDistance);

            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove =  !Physics.CapsuleCast(transform.position,transform.position+Vector3.up*playerHeight,playerRadius,moveDirectionZ,moveDistance);

                if (canMove)
                {
                    moveDirection = moveDirectionZ;
                }
            }
        }
        
        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }
        

        isWalking = moveDirection != Vector3.zero;
        
        transform.forward = Vector3.Slerp(transform.forward,moveDirection,Time.deltaTime * turnSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
