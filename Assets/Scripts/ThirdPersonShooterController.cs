using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVertualCamera;
    [SerializeField] private Image crosshair;
    [SerializeField, Range(0, 2)] private float lookSensitivity;
    [SerializeField, Range(0, 1)] private float aimSensitivity;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController; 

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        aimVertualCamera.gameObject.SetActive(starterAssetsInputs.aim);  
        crosshair.gameObject.SetActive(starterAssetsInputs.aim);

        if (starterAssetsInputs.aim )
        {
            thirdPersonController.SetSensitivity(aimSensitivity);
        }
        else
        {
            thirdPersonController.SetSensitivity(lookSensitivity);
        }
    }
} 
