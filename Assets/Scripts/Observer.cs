using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    private bool IsPlayerInRange;

    private void OnTriggerExit(Collider Other)
    {
        if (Other.transform == player)
        {
            IsPlayerInRange = false;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            IsPlayerInRange = true;
        }
    }

    private void Update()
    {
        if (IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);

            RaycastHit raycasthit;
            
            if (Physics.Raycast(ray,out raycasthit))
            {
                if (raycasthit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}

