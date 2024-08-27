using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float rotationSpeed = 2;
    [SerializeField] float distance = 60;
    [SerializeField] float minVAngle = -45;
    [SerializeField] float maxVAngle = 45;
    [SerializeField] Vector2 framingOffset;
    [SerializeField] float heightOffset = 1.5f;
    float rotationX;
    float rotationY;

    [SerializeField] bool invertX;
    [SerializeField] bool invertY;
    float invertXVal;
    float invertYVal;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertYVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVAngle, maxVAngle);

        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotationSpeed;

        var rotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focus = followTarget.position + new Vector3(framingOffset.x, framingOffset.y + heightOffset, 0);

        transform.position = focus - rotation * new Vector3(0, 0, distance);
        transform.rotation = rotation;
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);
}
