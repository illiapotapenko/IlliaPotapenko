using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeMovementProvider : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider continiousMovement;
    [SerializeField] private TeleportationProvider teleportMovement;

   public void ToggleMovement()
    {
        if (continiousMovement.enabled)
        {
            continiousMovement.enabled = false;
            teleportMovement.enabled = true;
        }
        else
        {
            continiousMovement.enabled = true;
            teleportMovement.enabled = false;
        }
    }
}