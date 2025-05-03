using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
   private const string OPEN_CLOSE = "OpenClose";
   
   [SerializeField] private ContainerCounter _containerCounter;
   private Animator _animator;

   private void Awake()
   {
      _animator = GetComponent <Animator>();
   }

   private void Start()
   {
      _containerCounter.OnPlayerGrabedObject += ContainerCounterOnOnPlayerGrabedObject;
   }

   private void ContainerCounterOnOnPlayerGrabedObject()
   {
      _animator.SetTrigger(OPEN_CLOSE);
   }
}
