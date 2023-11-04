using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer),typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera camera;
    private TrailRenderer trailRenderer;
    private BoxCollider boxCollider;

    private Vector3 mousePosition;

    private bool swiping;

    private void Awake()
    {
        camera = Camera.main;
        trailRenderer = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        trailRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    private void UpdateMousePosition()
    {
        mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = mousePosition;
    }

    private void UpdateComponent()
    { 
        trailRenderer.enabled = swiping;
        boxCollider.enabled = swiping;
    }

    private void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponent();
            } else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponent();
            }

            if (swiping == true)
            {
                UpdateMousePosition();
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
        {
            target.DestroyTarget();
        }
    }
}   
