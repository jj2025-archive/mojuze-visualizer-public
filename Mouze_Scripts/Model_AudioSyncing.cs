using System;
using System.Collections;
using UnityEngine;

[Serializable]
internal class Model_AudioSyncing
{
	private float theAudioTimeSample;

	private Hashtable theAudioCues_00;

	private Hashtable theAudioUserHits_00;

	public Model_AudioSyncing()
	{
		theAudioCues_00 = new Hashtable();
		theAudioUserHits_00 = new Hashtable();
		theAudioCues_00[8f] = "random1";
		theAudioCues_00[15.6f] = "random2";
		theAudioCues_00[23.1f] = "random1";
		theAudioCues_00[31.5f] = "random2";
	}

	public virtual float getTheAudioTimeSample()
	{
		return theAudioTimeSample;
	}

	public virtual Hashtable getTheAudioCues_00()
	{
		return theAudioCues_00;
	}

	public virtual Hashtable getTheAudioUserHits_00()
	{
		return theAudioUserHits_00;
	}

	public virtual void setTheAudioTimeSample(float theTime)
	{
		theAudioTimeSample = theTime;
	}

	public virtual void setTheAudioCues_00()
	{
	}

	public virtual void setTheAudioUserHits_00(string theChange)
	{
		theAudioUserHits_00[theAudioTimeSample] = theChange;
		Debug.Log(theAudioUserHits_00);
	}
}
