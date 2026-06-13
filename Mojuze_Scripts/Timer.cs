using System;
using UnityEngine;

[Serializable]
public class Timer : MonoBehaviour
{
	public int seconds;

	public int minutes;

	public Timer()
	{
		seconds = 60;
		minutes = 60;
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		guiText.text = "T MINUS 14 H " + minutes + " M " + seconds + " S";
		if (seconds <= 0)
		{
			seconds = 60;
			if (minutes <= 0)
			{
				minutes = 0;
			}
			else
			{
				minutes--;
			}
		}
		else
		{
			seconds--;
		}
	}

	public virtual void Main()
	{
	}
}
