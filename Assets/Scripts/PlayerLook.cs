using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Vector2 rotation = Vector2.zero;
    private float speed = 3f;
    private bool lookAllowed, isCameraLook;

	private void Start()
	{
        isCameraLook = true;

        lookAllowed = true;
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Confined;

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
    }

    public void AllowCameraLook(bool allow)
    {
        lookAllowed = allow;
    }

    private void ToggleCameraCursorMode()
    {
        if (isCameraLook)
        {
            isCameraLook = false;
            AllowCameraLook(false);
            Cursor.visible = true;
        }
        else
        {
            isCameraLook = true;
            AllowCameraLook(true);
            Cursor.visible = false;
        }
    }
}
