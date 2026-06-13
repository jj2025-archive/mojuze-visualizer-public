using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
internal class Core_Audio : MonoBehaviour
{
	private GameObject codeHolder_Core_MVC;

	private AudioSource theAudio;

	private float theTime;

	private object triggeredTime;

	private object triggeredHit;

	private GameObject theDisplay;

	private GameObject theDisplay2;

	private void Start()
	{
		codeHolder_Core_MVC = GameObject.Find("CodeHolder_Core_MVC");
		theAudio = (AudioSource)GameObject.Find("CodeHolder_Core_Audio").GetComponent(typeof(AudioSource));
		theDisplay = GameObject.Find("Audio_Prompter");
		theDisplay2 = GameObject.Find("Audio_Prompter2");
		theAudio.Play();
	}

	private void Update()
	{
		Global_ApplicationData.getTheEnvController().VisualiseAudio(GetAveragedVolume());
		Global_ApplicationData.getTheAudioSyncing().setTheAudioTimeSample((float)Math.Round(audio.time, 1));
		string value = Global_ApplicationData.theAudioUserHits_00[theTime - 0.7f] as string;
		string value2 = Global_ApplicationData.theAudioUserHits_00[theTime - 0.6f] as string;
		string text = Global_ApplicationData.theAudioUserHits_00[theTime - 0.5f] as string;
		string value3 = Global_ApplicationData.theAudioUserHits_00[theTime - 0.4f] as string;
		string value4 = Global_ApplicationData.theAudioUserHits_00[theTime - 0.3f] as string;
		string value5 = Global_ApplicationData.theAudioUserHits_00[theTime - 0.2f] as string;
		string value6 = Global_ApplicationData.theAudioUserHits_00[theTime - 0.1f] as string;
		string value7 = Global_ApplicationData.theAudioUserHits_00[theTime] as string;
		string value8 = Global_ApplicationData.theAudioUserHits_00[theTime + 0.1f] as string;
		string value9 = Global_ApplicationData.theAudioUserHits_00[theTime + 0.2f] as string;
		string text2 = Global_ApplicationData.theAudioUserHits_00[theTime + 0.3f] as string;
		string text3 = Global_ApplicationData.theAudioUserHits_00[theTime + 0.4f] as string;
		string text4 = Global_ApplicationData.theAudioUserHits_00[theTime + 0.5f] as string;
		string text5 = Global_ApplicationData.theAudioUserHits_00[theTime + 0.6f] as string;
		string text6 = Global_ApplicationData.theAudioUserHits_00[theTime + 0.7f] as string;
		string text7 = Global_ApplicationData.theAudioUserHits_00[theTime + 0.8f] as string;
		string value10 = Global_ApplicationData.theAudioCues_00[theTime] as string;
		if ((!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(value2) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(value3) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(value4) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(value5) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(value6) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(value7) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(value8) && !string.IsNullOrEmpty(value10)) || (!string.IsNullOrEmpty(value9) && !string.IsNullOrEmpty(value10)))
		{
			UnityEngine.Object.Instantiate(Resources.Load("Audio_Success"), new Vector3(0f, 0f, 0f), Quaternion.identity);
			Debug.Log(theTime + ":SUCCESSS:" + text);
		}
		string value11 = Global_ApplicationData.theAudioCues_00[theTime] as string;
		if (!string.IsNullOrEmpty(value11) && !RuntimeServices.EqualityOperator(theTime, triggeredHit))
		{
			triggeredHit = theTime;
			Global_ApplicationData.explosionThingy.SetActive(value: true);
			Global_ApplicationData.explosionThingy = UnityEngine.Object.Instantiate(Resources.Load("CubeExplosions"), new Vector3(2f, -10f, 0f), Quaternion.Euler(50f, 50f, 50f)) as GameObject;
		}
		string text8 = Global_ApplicationData.theAudioCues_00[theTime + 2f] as string;
		if (!string.IsNullOrEmpty(text8) && !RuntimeServices.EqualityOperator(theTime + 2f, triggeredTime))
		{
			triggeredTime = theTime + 2f;
			((GUIText)theDisplay.GetComponent(typeof(GUIText))).text = ((GUIText)theDisplay.GetComponent(typeof(GUIText))).text + "\n" + (theTime + 2f) + "-" + text8;
		}
	}

	private float GetAveragedVolume()
	{
		float[] array = new float[256];
		float num = 0f;
		theAudio.GetOutputData(array, 0);
		int i = 0;
		float[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			num += Mathf.Abs(array2[i]);
		}
		return num / 256f;
	}
}
