using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public RectTransform crosshair;

    [SerializeField] float sizeState=50;
    [SerializeField] float sizeMove=100;
    [SerializeField] float sizeCurrent;

    [SerializeField] float speedSize=5;

    private void Update()
    {
        if (isMoving)
        {
            sizeCurrent = Mathf.Lerp(sizeCurrent, sizeMove, Time.deltaTime * speedSize);
        }
        else
        {
            sizeCurrent = Mathf.Lerp(sizeCurrent, sizeState, Time.deltaTime * speedSize);
        }

        crosshair.sizeDelta = new Vector2(sizeCurrent, sizeCurrent);
    }
    bool isMoving
    {
        get
        {
            if (
            Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0
                )
                return true;
            else
                return false;
        }
    }
}
