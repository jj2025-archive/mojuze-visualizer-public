using System;
using UnityEngine;

[Serializable]
public class Core_Keyboard : MonoBehaviour
{
	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("advancepattern");
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("rewindpattern");
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("randompattern1");
			Global_ApplicationData.getTheAudioSyncController().captureInput("randompattern1");
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("randompattern2");
			Global_ApplicationData.getTheAudioSyncController().captureInput("randompattern2");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("randompattern3");
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("toggleblackout");
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("toggleplanet");
		}
		if (Input.GetKeyDown(KeyCode.V))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalBGPattern("randompattern1");
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalBGPattern("disableallbgs");
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("togglemojuzelogo");
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (Global_ApplicationData.autoAdvance)
			{
				Global_ApplicationData.autoAdvance = false;
			}
			else
			{
				Global_ApplicationData.autoAdvance = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("toggleinstructions");
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Global_ApplicationData.getTheEnvController().StoreFavGoPattern();
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Global_ApplicationData.getTheEnvController().RemoveFavGoPattern();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Global_ApplicationData.getTheEnvController().ChangeCamera("rewindcamera");
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Global_ApplicationData.getTheEnvController().ChangeCamera("advancecamera");
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Global_ApplicationData.getTheEnvController().ResetBounceCamera();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Global_ApplicationData.getTheEnvController().ToggleSlowMotion();
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			Global_ApplicationData.getTheEnvController().ModifyBounceCamera("speedup");
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Global_ApplicationData.getTheEnvController().ModifyBounceCamera("slowdown");
		}
		if (Input.GetKeyDown(KeyCode.Period))
		{
			Global_ApplicationData.getTheEnvController().DoFilter("boostbouncecamglow");
		}
		if (Input.GetKeyDown(KeyCode.Comma))
		{
			Global_ApplicationData.getTheEnvController().DoFilter("reducebouncecamglow");
		}
	}

	public virtual void GestureToKeyboard(string theGesture)
	{
		switch (theGesture)
		{
		case "swiperight":
			break;
		case "swipeup":
			break;
		case "swipedown":
			break;
		case "swipe2fingerleft":
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("randompattern1");
			break;
		case "swipe2fingerright":
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("randompattern2");
			break;
		case "swipe2fingerup":
			Global_ApplicationData.getTheEnvController().ToggleSlowMotion();
			break;
		case "swipe2fingerdown":
			Global_ApplicationData.getTheEnvController().ChangeCamera("advancecamera");
			break;
		case "swipe3fingerleft":
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("advancepattern");
			break;
		case "swipe3fingerright":
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("rewindpattern");
			break;
		case "swipe3fingerup":
			Global_ApplicationData.getTheEnvController().RemoveFavGoPattern();
			break;
		case "swipe3fingerdown":
			Global_ApplicationData.getTheEnvController().StoreFavGoPattern();
			break;
		}
	}

	public virtual void Main()
	{
	}
}
