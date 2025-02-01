using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Scanner : XRGrabInteractable
{
   [Header("Scanner Data")] 
   public Animator animator;
   public LineRenderer laserRenderer;
   public TextMeshProUGUI targetName;
   public TextMeshProUGUI targetPosition;
   public Material highlightMaterial;

   private Material originalMaterial;
   private Renderer lastScannedRenderer;
   
   protected override void Awake()
   {
      base.Awake();
     ScannerActivated(false);
   }

   protected override void OnSelectEntered(SelectEnterEventArgs args)
   {
      base.OnSelectEntered(args);
      animator.SetBool("Opened", true);
   }

   protected override void OnSelectExited(SelectExitEventArgs args)
   {
      base.OnSelectExited(args);
      animator.SetBool("Opened", false);
   }

   protected override void OnActivated(ActivateEventArgs args)
   {
      base.OnActivated(args);
     ScannerActivated(true);
   }

   protected override void OnDeactivated(DeactivateEventArgs args)
   {
      base.OnDeactivated(args);
      ScannerActivated(false);
   }

   public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
   {
      base.ProcessInteractable(updatePhase);

      if (laserRenderer.gameObject.activeSelf)
      {
         ScanForObjects();
      }
   }

   private void ScannerActivated(bool isActivated)
   {
      laserRenderer.gameObject.SetActive(isActivated);
      targetName.gameObject.SetActive(isActivated);
      targetPosition.gameObject.SetActive(isActivated);

      if (isActivated == false && lastScannedRenderer != null )
      {
         ResetMaterial();
      }
   }

   private void ScanForObjects()
   {
      RaycastHit hit;
      Vector3 worldHit = laserRenderer.transform.position + laserRenderer.transform.forward * 1000;

      if (Physics.Raycast(laserRenderer.transform.position,laserRenderer.transform.forward,out hit))
      {
         worldHit = hit.point;
         
        targetName.SetText(hit.collider.name);
        targetPosition.text = hit.transform.position.ToString();

        Renderer hitRenderer = hit.collider.GetComponent<Renderer>();

        if (hitRenderer != null)
        {
           if (lastScannedRenderer != hitRenderer)
           {
               ResetMaterial();

              originalMaterial = hitRenderer.material;
              hitRenderer.material = highlightMaterial;
              lastScannedRenderer = hitRenderer;
           }
        }
      }
      else
      {
         ResetMaterial();
      }
      
      laserRenderer.SetPosition(1,laserRenderer.transform.InverseTransformPoint(worldHit));
   }

   private void ResetMaterial()
   {
      if (lastScannedRenderer != null && originalMaterial != null)
      {
         lastScannedRenderer.material = originalMaterial;
         lastScannedRenderer = null;
      }
   }
} 
