using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Inflator : XRGrabInteractable
{
   [Header("Balloon Data")] public Transform attachPoint;
   public Balloon balloonPrefab;

   private Balloon balloonInstanse;

   protected override void OnSelectEntered(SelectEnterEventArgs args)
   {
      base.OnSelectEntered(args);

      balloonInstanse = Instantiate(balloonPrefab, attachPoint);
      balloonInstanse.transform.localPosition = attachPoint.localPosition;
   }

   protected override void OnSelectExited(SelectExitEventArgs args)
   {
      base.OnSelectExited(args);

      Destroy(balloonInstanse.gameObject);
   }
}


   