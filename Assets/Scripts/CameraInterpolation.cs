using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CameraInterpolation : MonoBehaviour
{
    private int currentIndex = 1;
    
    public float interpolationSpeed;
    public List<Transform> cameraPositions;
    public PlayerLook playerFPSCamera;
    public TMP_Text currentPositionText;


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
            InterpolateBetweenPoints_CoroutineStart(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopAllCoroutines();
            InterpolateBetweenPoints_CoroutineStart(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StopAllCoroutines();
            InterpolateBetweenPoints_CoroutineStart(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StopAllCoroutines(); 
            InterpolateBetweenPoints_CoroutineStart(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StopAllCoroutines();
            InterpolateBetweenPoints_CoroutineStart(4);
        }
    }

    IEnumerator InterpolateBetweenPoints(int newPosition)
    {
        currentIndex = newPosition;
        UpdatePositionName();
        while (Vector3.Distance(transform.position, cameraPositions[currentIndex].position) > 0.1f)
        {
            transform.position = InterpolatePosition(currentIndex);
            yield return null;
        }
    }

    public void InterpolateBetweenPoints_CoroutineStart(int newPosition)
    {
        StartCoroutine(InterpolateBetweenPoints(newPosition));
    }

    private void UpdatePositionName()
    {
        switch (currentIndex)
        {
            case 0:
                currentPositionText.text = "TV Corner";
                break;
            case 1:
                currentPositionText.text = "Bonsai Display";
                break;
            case 2:
                currentPositionText.text = "Scythe Display";
                break;
            case 3:
                currentPositionText.text = "PC Corner";
                break;
            case 4:
                currentPositionText.text = "Showcase Cabinet";
                break;
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
