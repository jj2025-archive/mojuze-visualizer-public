using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
internal class Model_DynamicText_Tweets
{
	private UnityScript.Lang.Array theTweetArray;

	private int currentTweetPosition;

	private GameObject theTweetHolder01;

	private GameObject theTweetHolder02;

	public Model_DynamicText_Tweets()
	{
		theTweetArray = new UnityScript.Lang.Array();
		currentTweetPosition = 1;
		theTweetHolder01 = GameObject.Find("TextHolder_01");
		theTweetHolder02 = (GameObject)UnityEngine.Object.Instantiate(theTweetHolder01);
		GameObject gameObject = null;
		theTweetHolder01.transform.position = new Vector3(8f, 0f, -100f);
		theTweetHolder02.transform.position = new Vector3(8f, 0f, -100f);
		((MeshRenderer)theTweetHolder01.GetComponent(typeof(MeshRenderer))).renderer.material.color = new Color(20f, 20f, 20f, 0f);
		((MeshRenderer)theTweetHolder02.GetComponent(typeof(MeshRenderer))).renderer.material.color = new Color(20f, 20f, 20f, 0f);
	}

	public virtual void AddTweet(string theTweet)
	{
		theTweetArray.Push(theTweet);
	}

	public virtual UnityScript.Lang.Array getTheTweetArray()
	{
		return theTweetArray;
	}

	public virtual int getCurrentTweetPos()
	{
		return currentTweetPosition;
	}

	public virtual void setCurrentTweetPos(int thePosition)
	{
		currentTweetPosition = thePosition;
	}

	public virtual void AdvanceTweetPos()
	{
		if (currentTweetPosition < getTheTweetArray().length - 1)
		{
			Debug.Log(getTheTweetArray().length);
			currentTweetPosition++;
		}
		else
		{
			currentTweetPosition = 1;
		}
	}

	public virtual GameObject[] getTheTweetHolder()
	{
		GameObject[] array = null;
		return new GameObject[2] { theTweetHolder01, theTweetHolder02 };
	}
}
