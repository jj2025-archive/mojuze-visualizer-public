using System;
using UnityEngine;

[Serializable]
internal class Controller_AudioSyncing
{
	public virtual void captureInput(string theChange)
	{
		Debug.Log(theChange + ": " + Global_ApplicationData.getTheAudioSyncing().getTheAudioTimeSample());
		Global_ApplicationData.getTheAudioSyncing().setTheAudioUserHits_00(theChange);
	}
}
