using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    float xRot;
    float yRot;
    float xRotCurrent;
    float yRotCurrent;
    public Camera player;
    public GameObject playerGameObject;
    public float sensivity = 5f;
    public float smoothTime = 0.1f;
    float currentVelosityX;
    float currentVelosityY;

    private void Update()
    {
        MouseMove();
    }
    private void MouseMove()
    {
        xRot += Input.GetAxis("Mouse X") * sensivity;
        yRot += Input.GetAxis("Mouse Y") * sensivity;
        yRot = Mathf.Clamp(yRot,-45, 70);
        xRot = Mathf.Clamp(xRot, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, smoothTime);

        player.transform.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
        playerGameObject.transform.rotation = Quaternion.Euler(0f, xRotCurrent, 0f);

    }
    
}
