using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EditorCamMarkMovement : MonoBehaviour
{

    public Vector3 CenterPosition = Vector3.zero;

    private Vector3 previousMousePosition;
    private Vector3 mouseOffset;
    private Vector3 rotation;

    public bool ReverseHorizontalRotation = false;
    public bool ReverseVerticalRotation = false;

    public float ZoomSpeed = 1f;
    public float RotationSpeed = 0.1f;

    public float MinDistance = 2f;
    public float MaxDistance = 10f;
    public float MinCameraAngle = -1f;
    public float MaxCameraAngle = 50f;

    public bool LimitZoomIn = false;
    public bool LimitZoomOut = false;
    public bool LimitRotateUp = false;
    public bool LimitRotateDown = false;

    public CinemachineVirtualCamera vcam1;
    private CinemachineTransposer transposer;

    public bool WIP = false;

    // Start is called before the first frame update
    void Start()
    {
        rotation = Vector3.zero;
        transposer = vcam1.GetCinemachineComponent<CinemachineTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WIP)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * ZoomSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += (-transform.forward) * ZoomSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-10 * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(10 * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(new Vector3(0, -10 * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(new Vector3(0, 10 * Time.deltaTime, 0));
            }
            if (Input.GetMouseButton(2))
            {
                float rh = Input.GetAxis("Mouse X");
                float rv = Input.GetAxis("Mouse Y");

                rotation.x -= rv * 5;
                rotation.y += rh * 5;

                transform.eulerAngles = rotation;
            }
        }
        else
        {
            LimitMovement();
            DragMovementDifference();
            Zoom();
        }
        
    }

    private void DragMovementContinuous()
    {
        if (Input.GetMouseButton(2))
        {
            if (Input.GetAxis("Mouse X") < 0) // moves left
            {
                transform.RotateAround(Vector3.zero, Vector3.up, -75 * Time.deltaTime);
            }
            else if (Input.GetAxis("Mouse X") > 0) // moves right
            {
                transform.RotateAround(transform.position, Vector3.up, 75 * Time.deltaTime);
            }
            if (Input.GetAxis("Mouse Y") < 0) // moves down
            {
                transform.RotateAround(transform.position, Vector3.forward, 75 * Time.deltaTime);
            }
            else if (Input.GetAxis("Mouse Y") > 0) // moves up
            {
                transform.RotateAround(transform.position, Vector3.forward, -75 * Time.deltaTime);
            }
        }
    }

    private void DragMovementDifference()
    {
        if (Input.GetMouseButton(2)) // middle mouse button hold
        {
            mouseOffset = Input.mousePosition - previousMousePosition;
            rotation.y = mouseOffset.x * RotationSpeed; // left and right
            if (ReverseHorizontalRotation)
            {
                rotation.y = -rotation.y;
            }
            rotation.x = -mouseOffset.y * RotationSpeed; // up and down
            if (ReverseVerticalRotation)
            {
                rotation.x = -rotation.x;
            }
            transform.RotateAround(CenterPosition, Vector3.up, rotation.y);
            if ((LimitRotateUp && rotation.x < 0) || (LimitRotateDown && rotation.x > 0))
            {
                rotation.x = 0;
            }
            transform.RotateAround(CenterPosition, Vector3.right, rotation.x);
        }
        previousMousePosition = Input.mousePosition;
    }

    private void Zoom()
    {
        if (Input.mouseScrollDelta.y > 0 && (!LimitZoomIn))
        {
            transform.Translate(Vector3.forward);
            //Vector3 currentOffset = vcam1.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
            //currentOffset.z += ZoomSpeed;
            //vcam1.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = currentOffset;
        }
        else if (Input.mouseScrollDelta.y < 0 && (!LimitZoomOut))
        {
            transform.Translate(Vector3.back);
            //transposer.m_FollowOffset.z -= ZoomSpeed * Time.deltaTime;
        }
    }

    private void LimitMovement()
    {
        float dist = Mathf.Abs(Vector3.Distance(transform.position, CenterPosition));
        if (dist <= MinDistance)
        {
            LimitZoomIn = true;
            LimitZoomOut = false;
        }
        else if (dist >= MaxDistance)
        {
            LimitZoomOut = true;
            LimitZoomIn = false;
        }
        else
        {
            LimitZoomIn = false;
            LimitZoomOut = false;
        }
        float angleX = transform.rotation.x;
        if (angleX <= MinCameraAngle)
        {
            LimitRotateDown = true;
            LimitRotateUp = false;
        }
        else if (angleX >= MaxCameraAngle)
        {
            LimitRotateUp = true;
            LimitRotateDown = false;
        }
        else
        {
            LimitRotateUp = false;
            LimitRotateDown = false;
        }
    }

}
