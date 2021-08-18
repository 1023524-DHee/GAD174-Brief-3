using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    private Vector2 rotation = Vector2.zero;
    private bool lookAllowed, isCameraLook;

    public float speed = 1f;
    public GameObject middlePoint;
    public Slider lookSpeedSlider;

	private void Start()
	{
        isCameraLook = true;

        lookAllowed = true;
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        PlayerControls.current.onTabButtonPressed += ToggleCameraCursorMode;
        PlayerControls.current.onSpaceButtonPressed += ToggleCameraCursorMode;
    }

	// Update is called once per frame
	void Update()
    {
        if (lookAllowed)
        {
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x -= Input.GetAxis("Mouse Y");
            transform.eulerAngles = rotation * speed;
        }
        speed = lookSpeedSlider.value;
    }

    public void AllowCameraLook(bool allow)
    {
        lookAllowed = allow;
    }

    private void ToggleCameraCursorMode()
    {
        if (isCameraLook)
        {
            Cursor.lockState = CursorLockMode.Confined;
            middlePoint.SetActive(false);
            isCameraLook = false;
            AllowCameraLook(false);
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            middlePoint.SetActive(true);
            isCameraLook = true;
            AllowCameraLook(true);
            Cursor.visible = false;
        }
    }
}
