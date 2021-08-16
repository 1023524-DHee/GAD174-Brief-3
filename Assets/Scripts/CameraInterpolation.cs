using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInterpolation : MonoBehaviour
{
    private int currentIndex = 1;
    
    public float interpolationSpeed;
    public List<Transform> cameraPositions;
    public PlayerLook playerFPSCamera;

	private void Start()
	{
        PlayerControls.current.onAButtonPressed += InterpolateLeftPoint;
        PlayerControls.current.onDButtonPressed += InterpolateRightPoint;
	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StopAllCoroutines();
            StartCoroutine(InterpolateBetweenPoints(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopAllCoroutines();
            StartCoroutine(InterpolateBetweenPoints(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StopAllCoroutines();
            StartCoroutine(InterpolateBetweenPoints(2));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StopAllCoroutines();
            StartCoroutine(InterpolateBetweenPoints(3));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StopAllCoroutines();
            StartCoroutine(InterpolateBetweenPoints(4));
        }
    }

    IEnumerator InterpolateBetweenPoints(int newPosition)
    {
        currentIndex = newPosition;
        while (Vector3.Distance(transform.position, cameraPositions[currentIndex].position) > 0.1f)
        {
            transform.position = InterpolatePosition(currentIndex);
            yield return null;
        }
    }

	private void InterpolateRightPoint()
	{
		currentIndex++;
		if (currentIndex >= cameraPositions.Count) currentIndex = 0;
        StartCoroutine(InterpolateBetweenPoints(currentIndex));
    }

	private void InterpolateLeftPoint()
	{
        currentIndex--;
		if (currentIndex < 0) currentIndex = cameraPositions.Count - 1;
        StartCoroutine(InterpolateBetweenPoints(currentIndex));
    }

	private Vector3 InterpolatePosition(int newPosition)
    {
        return Vector3.Lerp(transform.position, cameraPositions[newPosition].position, Time.deltaTime * interpolationSpeed);
    }
}
