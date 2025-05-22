using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3 (0, 84, -25);
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private float thresholdRadius = 5f;

    // Internal state
    private Vector3 velocity = Vector3.zero;
    private Vector3 lastTargetPostion;
    private Vector3 desiredPosition;
    private float threshold = 0.01f;
    private bool isCameraPosUpdating;
    void Start()
    {
        Debug.Assert(target != null, "Camera follow target is null");
        if (target != null)
        {
            lastTargetPostion = target.position;

            transform.position = lastTargetPostion + offset;
            transform.LookAt(target);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // NULL check
        if (target == null) return;

        if (!isCameraPosUpdating)
        {
            // Determine if player pawn is still within the dead-zone
            float distMoved = Vector3.Distance(target.position, lastTargetPostion);
            if (distMoved < thresholdRadius) return;

            // if player pawn position outside of dead-zone
            Debug.Log("isCameraPosUpdating: true");
            isCameraPosUpdating = true;
        }

        lastTargetPostion = target.position;
        desiredPosition = target.position + offset;

        // Smooth update the camera position
        //Debug.Log($"transform.position: {transform.position} \nDesired position: {desiredPosition}");
        transform.position = Vector3.SmoothDamp(
            current: transform.position, 
            target: desiredPosition, 
            currentVelocity: ref velocity, 
            smoothTime: smoothTime
        );
        // Update the camera look at direction
        transform.LookAt(target);


        if (Vector3.Distance(transform.position, desiredPosition) < threshold)
        {
            Debug.Log("isCameraPosUpdating: false");
            isCameraPosUpdating = false;
        }
    }
}
