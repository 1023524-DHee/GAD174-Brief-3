using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public static PlayerControls current;

	private void Awake()
	{
        current = this;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) SpaceButtonPressed();
		if (Input.GetKeyDown(KeyCode.Tab)) TabButtonPressed();
		if (Input.GetKeyDown(KeyCode.A)) AButtonPressed();
		if (Input.GetKeyDown(KeyCode.D)) DButtonPressed();
	}

	public event Action onSpaceButtonPressed;
	public void SpaceButtonPressed()
	{
		if (onSpaceButtonPressed != null) onSpaceButtonPressed();
	}

	public event Action onTabButtonPressed;
	public void TabButtonPressed()
	{
		if (onTabButtonPressed != null) onTabButtonPressed();
	}

	public event Action onAButtonPressed;
	public void AButtonPressed()
	{
		if (onAButtonPressed != null) onAButtonPressed();
	}

	public event Action onDButtonPressed;
	public void DButtonPressed()
	{
		if (onDButtonPressed != null) onDButtonPressed();
	}
}
