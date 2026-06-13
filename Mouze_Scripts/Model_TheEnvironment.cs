using System;
using System.Xml;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
internal class Model_TheEnvironment
{
	private Camera[] camerasInEnvironment;

	private GameObject[] graphicalObjectsInEnv;

	private GameObject[] graphicalBGsInEnv;

	public Model_TheEnvironment()
	{
		camerasInEnvironment = Camera.allCameras;
		graphicalObjectsInEnv = GameObject.FindGameObjectsWithTag("MOJZ_GraphicalObject");
		graphicalBGsInEnv = GameObject.FindGameObjectsWithTag("MOJZ_GraphicalBG");
	}

	public virtual Camera[] getCamerasInEnvironment()
	{
		return camerasInEnvironment;
	}

	public virtual Camera getBounceCamera()
	{
		int num = 0;
		Camera[] array = camerasInEnvironment;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].name == "Camera: Bounce Camera")
				{
					result = array[num];
					break;
				}
				num++;
				continue;
			}
			result = null;
			break;
		}
		return (Camera)result;
	}

	public virtual Camera getDefaultCamera()
	{
		int num = 0;
		Camera[] array = camerasInEnvironment;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].name == "Camera: Main Camera")
				{
					result = array[num];
					break;
				}
				num++;
				continue;
			}
			result = null;
			break;
		}
		return (Camera)result;
	}

	public virtual GameObject[] getGraphicalObjectsInEnv()
	{
		return graphicalObjectsInEnv;
	}

	public virtual GameObject[] getGraphicalBGsInEnv()
	{
		return graphicalBGsInEnv;
	}

	public virtual void getXMLForTweets()
	{
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			xmlDocument.Load("http://search.twitter.com/search.rss?q=virgingalactic");
		}
		catch (Exception)
		{
			xmlDocument = null;
		}
		if (!RuntimeServices.EqualityOperator(xmlDocument, null))
		{
			string[] array = new string[3] { "tweet1", "tweet2", "tweet3" };
			for (int i = 0; i < Extensions.get_length((System.Array)array); i++)
			{
				Debug.Log(array[i]);
				Global_ApplicationData.getTheDynamicTextTweets().AddTweet(array[i]);
			}
		}
		else
		{
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet("NOT USED");
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet(string.Empty);
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet("What are we?");
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet("Is it merely syncopations...");
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet("Of distance and time,");
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet("Fractured, dense, lively");
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet("But above all...");
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet("Beautiful?");
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet(string.Empty);
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet(string.Empty);
			Global_ApplicationData.getTheDynamicTextTweets().AddTweet(string.Empty);
		}
	}
}
