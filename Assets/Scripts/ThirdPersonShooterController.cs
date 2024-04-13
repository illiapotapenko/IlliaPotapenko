using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVertualCamera;
    [SerializeField] private Image crosshair;
    [SerializeField, Range(0, 2)] private float lookSensitivity;
    [SerializeField, Range(0, 1)] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTramsform;
    [SerializeField] private Transform bulletProjectTile;
    [SerializeField] private Transform spawnBulletPosition;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController; 

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        float rayMaxDistance = 999f;

        if (Physics.Raycast(ray, out RaycastHit raycastHit, rayMaxDistance, aimColliderLayerMask))
        {
            debugTramsform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        aimVertualCamera.gameObject.SetActive(starterAssetsInputs.aim);
        crosshair.gameObject.SetActive(starterAssetsInputs.aim);
        thirdPersonController.SetRotateOnMove(!starterAssetsInputs.aim);

        if (starterAssetsInputs.aim )
        {
            thirdPersonController.SetSensitivity(aimSensitivity);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward,aimDirection,20 * Time.deltaTime);
        }
        else
        {
            thirdPersonController.SetSensitivity(lookSensitivity);
        }

        if (starterAssetsInputs.shoot && starterAssetsInputs.aim) 
        {
            Vector3 aimDirection = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(bulletProjectTile, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection,Vector3.up));
            starterAssetsInputs.shoot = false;
        }
    }
} 
