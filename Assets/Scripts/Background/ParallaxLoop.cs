using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField]private Transform cameraTransform;
  [SerializeField]  private Vector3 lastCameraPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        
            transform.position += Vector3.left * speed * Time.deltaTime;
      
    }
}