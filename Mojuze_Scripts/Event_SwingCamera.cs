using System;
using UnityEngine;

[Serializable]
public class Event_SwingCamera : MonoBehaviour
{
	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void triggerSwingCameraEvent()
	{
		Global_ApplicationData.getTheEnvController().CalculateSwingBPM();
	}

	public virtual void Main()
	{
	}
}
