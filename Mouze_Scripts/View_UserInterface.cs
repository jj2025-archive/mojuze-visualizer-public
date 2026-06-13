using System;
using UnityEngine;

[Serializable]
internal class View_UserInterface
{
	public GameObject theTimeField;

	public View_UserInterface()
	{
		theTimeField = GameObject.Find("Audio_Prompter2");
	}

	public virtual void SetTheGUISkin()
	{
		GUI.skin = Global_ApplicationData.getTheGUISkin();
	}

	public virtual void CheckAndDoStrobeEffect()
	{
		ScreenOverlay screenOverlay = null;
		screenOverlay = Global_ApplicationData.getTheEnvironment().getDefaultCamera().GetComponent("ScreenOverlay") as ScreenOverlay;
		if (Global_ApplicationData.theStrobeOnOff)
		{
			if (Global_ApplicationData.theFrameCount % 20 == 0 || Global_ApplicationData.theFrameCount % 21 == 0 || Global_ApplicationData.theFrameCount % 22 == 0 || Global_ApplicationData.theFrameCount % 23 == 0 || Global_ApplicationData.theFrameCount % 24 == 0 || Global_ApplicationData.theFrameCount % 25 == 0)
			{
				screenOverlay.enabled = true;
			}
			else
			{
				screenOverlay.enabled = false;
			}
		}
		else
		{
			screenOverlay.enabled = false;
		}
	}

	public virtual void DrawUserInterface()
	{
		((GUIText)theTimeField.GetComponent(typeof(GUIText))).text = string.Empty + Global_ApplicationData.getTheAudioSyncing().getTheAudioTimeSample() + "s";
		string empty = string.Empty;
		if (Global_ApplicationData.getShowTheInstructions())
		{
			GUI.Label(Global_ApplicationData.getTheAppLabelPosition(), Global_ApplicationData.getTheAppLabel());
			GUI.Label(Global_ApplicationData.getTheSpeedLabelPosition(), Global_ApplicationData.getTheSpeedLabel() + Time.timeScale + "X");
			GUI.Label(Global_ApplicationData.getTheBPMLabelPosition(), Global_ApplicationData.getTheBPMLabel());
			GUI.Label(Global_ApplicationData.getTheFavSlotPosition(), Global_ApplicationData.getTheFavSlotLabel());
			string empty2 = string.Empty;
			GUI.Label(text: "AutoAdvance (press A): " + ((!Global_ApplicationData.autoAdvance) ? "OFF" : "ON"), position: new Rect(50f, 132f, 300f, 30f));
			GUI.Label(new Rect(50f, 168f, 350f, 30f), "LineIn/ Mic Detect (Needs LOUD! Music)");
			Global_ApplicationData.theMicSensSlider = GUI.HorizontalSlider(new Rect(50f, 194f, 270f, 35f), Global_ApplicationData.theMicSensSlider, 0f, 15f);
			GUI.Label(Global_ApplicationData.theInstructionsLabelPos, Global_ApplicationData.getTheInstructions());
			GUILayout.BeginArea(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 190, 400f, 550f));
			GUILayout.EndArea();
			Global_ApplicationData.mojuzeWatermark.SetActive(value: true);
		}
		else
		{
			Global_ApplicationData.mojuzeWatermark.SetActive(value: true);
		}
	}
}
