using System;
using UnityEngine;

[Serializable]
public class Core_MVC : MonoBehaviour
{
	public virtual void Start()
	{
		Global_ApplicationData.setTheEnvironment(new Model_TheEnvironment());
		Global_ApplicationData.setTheAudioSyncing(new Model_AudioSyncing());
		Global_ApplicationData.setTheDynamicTextTweets(new Model_DynamicText_Tweets());
		Global_ApplicationData.setTheAudioSyncController(new Controller_AudioSyncing());
		Global_ApplicationData.setTheEnvController(new Controller_TheEnvironment());
		Global_ApplicationData.setTheKeyboardInputController(new Controller_KeyboardInput());
		Global_ApplicationData.setTheViewUserInterface(new View_UserInterface());
		Global_ApplicationData.getTheEnvController().DisableAllCameras();
		Global_ApplicationData.getTheEnvController().ShowDefaultCamera();
		Global_ApplicationData.getTheEnvironment().getBounceCamera().animation["BPM_Swing_Test_00"].speed = Global_ApplicationData.getBounceCameraSpeed();
		Global_ApplicationData.getTheEnvController().DisableAllGraphicalObjs();
		Global_ApplicationData.getTheEnvController().ShowDefaultGraphicalObj();
		Global_ApplicationData.getTheEnvController().DisableAllGraphicalBGs();
		Global_ApplicationData.mojuzeLogo.SetActive(value: true);
		Global_ApplicationData.electrifiedLogo.SetActive(value: false);
		Global_ApplicationData.getTheEnvironment().getXMLForTweets();
		Global_ApplicationData.getTheEnvController().AdvanceDynamicText();
	}

	public virtual void Update()
	{
		Global_ApplicationData.getTheViewUserInterface().CheckAndDoStrobeEffect();
		Global_ApplicationData.getTheEnvController().CheckAndDoAutoRandomise();
		Global_ApplicationData.theFrameForTweet++;
		Global_ApplicationData.getTheEnvController().CheckAndDoTweetTween();
	}

	public virtual void OnGUI()
	{
		Global_ApplicationData.getTheViewUserInterface().SetTheGUISkin();
		Global_ApplicationData.getTheViewUserInterface().DrawUserInterface();
	}

	public virtual void NonClassedVisualiseAudio(float loudness)
	{
		loudness = loudness * Global_ApplicationData.theMicSensSlider * 10f;
		GlowEffect glowEffect = null;
		glowEffect = Global_ApplicationData.getTheEnvironment().getDefaultCamera().camera.GetComponent("GlowEffect") as GlowEffect;
		BloomAndLensFlares bloomAndLensFlares = null;
		bloomAndLensFlares = Global_ApplicationData.getTheEnvironment().getDefaultCamera().camera.GetComponent("BloomAndLensFlares") as BloomAndLensFlares;
		if (!(loudness <= 0.5f))
		{
			glowEffect.enabled = true;
			glowEffect.glowIntensity = loudness / 6f;
			bloomAndLensFlares.bloomIntensity = loudness / 2f;
		}
		else
		{
			glowEffect.enabled = true;
			glowEffect.glowIntensity = 0.2f;
			bloomAndLensFlares.bloomIntensity = 10f;
		}
	}

	public virtual void Main()
	{
	}
}
