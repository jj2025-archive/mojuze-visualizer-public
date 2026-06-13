using System;
using System.Collections;
using Boo.Lang.Runtime;
using Holoville.HOTween;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
internal class Controller_TheEnvironment
{
	public virtual void DisableAllCameras()
	{
		int i = 0;
		Camera[] camerasInEnvironment = Global_ApplicationData.getTheEnvironment().getCamerasInEnvironment();
		for (int length = camerasInEnvironment.Length; i < length; i++)
		{
			camerasInEnvironment[i].camera.enabled = false;
		}
	}

	public virtual void ShowDefaultCamera()
	{
		int num = default(int);
		num = (int)Global_ApplicationData.getTheCurrentCamera();
		Global_ApplicationData.getTheEnvironment().getCamerasInEnvironment()[num].camera.enabled = true;
	}

	public virtual void DisableAllGraphicalObjs()
	{
		int i = 0;
		GameObject[] graphicalObjectsInEnv = Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv();
		for (int length = graphicalObjectsInEnv.Length; i < length; i++)
		{
			graphicalObjectsInEnv[i].SetActive(value: false);
		}
	}

	public virtual void DisableAllGraphicalBGs()
	{
		int i = 0;
		GameObject[] graphicalBGsInEnv = Global_ApplicationData.getTheEnvironment().getGraphicalBGsInEnv();
		for (int length = graphicalBGsInEnv.Length; i < length; i++)
		{
			graphicalBGsInEnv[i].SetActive(value: false);
		}
	}

	public virtual void ShowDefaultGraphicalObj()
	{
		Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv()[0].SetActive(value: true);
	}

	public virtual void ShowDefaultGraphicalBG()
	{
	}

	public virtual void ModifyBounceCamera(string theAction)
	{
		if (theAction == "speedup")
		{
			Global_ApplicationData.setBounceCameraSpeed(Global_ApplicationData.getBounceCameraSpeed() * 1.001f);
			Camera camera = null;
			camera = Global_ApplicationData.getTheEnvironment().getBounceCamera();
			camera.animation["BPM_Swing_Test_00"].speed = Global_ApplicationData.getBounceCameraSpeed();
		}
		else if (theAction == "slowdown")
		{
			Global_ApplicationData.setBounceCameraSpeed(Global_ApplicationData.getBounceCameraSpeed() / 1.001f);
			Camera camera2 = null;
			camera2 = Global_ApplicationData.getTheEnvironment().getBounceCamera();
			camera2.animation["BPM_Swing_Test_00"].speed = Global_ApplicationData.getBounceCameraSpeed();
		}
	}

	public virtual void DoFilter(string theFilter)
	{
		switch (theFilter)
		{
		case "boostbouncecamglow":
		{
			GlowEffect glowEffect2 = null;
			glowEffect2 = Global_ApplicationData.getTheEnvironment().getBounceCamera().camera.GetComponent("GlowEffect") as GlowEffect;
			if (!(glowEffect2.glowIntensity >= 1.55f))
			{
				glowEffect2.glowIntensity *= 1.05f;
			}
			break;
		}
		case "reducebouncecamglow":
		{
			GlowEffect glowEffect = null;
			glowEffect = Global_ApplicationData.getTheEnvironment().getBounceCamera().camera.GetComponent("GlowEffect") as GlowEffect;
			if (!(glowEffect.glowIntensity <= 0.9f))
			{
				glowEffect.glowIntensity /= 1.05f;
			}
			break;
		}
		case "dostrobe":
			if (Global_ApplicationData.theStrobeOnOff)
			{
				Global_ApplicationData.theStrobeOnOff = false;
			}
			else
			{
				Global_ApplicationData.theStrobeOnOff = true;
			}
			break;
		}
	}

	public virtual void ChangeGraphicalObjPattern(string theChange)
	{
		if (theChange == "advancepattern" && Global_ApplicationData.getMaxGOPattern() >= 0)
		{
			Global_ApplicationData.theFrameForTweet = 1;
			if (Global_ApplicationData.getCurrentGOPattern() < Global_ApplicationData.getMaxGOPattern())
			{
				Global_ApplicationData.setCurrentGOPattern(Global_ApplicationData.getCurrentGOPattern() + 1);
			}
			else
			{
				Global_ApplicationData.setCurrentGOPattern(0);
			}
			ApplyGraphicalObjPattern();
			return;
		}
		if (theChange == "rewindpattern" && Global_ApplicationData.getMaxGOPattern() >= 0)
		{
			Global_ApplicationData.theFrameForTweet = 1;
			if (Global_ApplicationData.getCurrentGOPattern() > 0)
			{
				Global_ApplicationData.setCurrentGOPattern(Global_ApplicationData.getCurrentGOPattern() - 1);
			}
			else
			{
				Global_ApplicationData.setCurrentGOPattern(Global_ApplicationData.getMaxGOPattern());
			}
			ApplyGraphicalObjPattern();
			return;
		}
		switch (theChange)
		{
		case "randompattern1":
			Global_ApplicationData.theFrameForTweet = 1;
			RandomiseGOPattern(1);
			break;
		case "randompattern2":
			Global_ApplicationData.theAudioUserHits_00[Global_ApplicationData.getTheAudioTimeSample()] = theChange;
			Global_ApplicationData.theFrameForTweet = 1;
			RandomiseGOPattern(2);
			break;
		case "randompattern3":
			Global_ApplicationData.theFrameForTweet = 1;
			RandomiseGOPattern(3);
			break;
		case "toggleelectrifiedlogo":
			if (Global_ApplicationData.electrifiedLogo.activeSelf)
			{
				Global_ApplicationData.electrifiedLogo.SetActive(value: false);
			}
			else
			{
				Global_ApplicationData.electrifiedLogo.SetActive(value: true);
			}
			break;
		case "toggleblackout":
		{
			GameObject gameObject = GameObject.Find("Camera: Main Camera");
			GameObject gameObject2 = GameObject.Find("Camera: Bounce Camera");
			if (gameObject.camera.nearClipPlane == 0.5f)
			{
				gameObject.camera.nearClipPlane = 200f;
				gameObject2.camera.nearClipPlane = 200f;
			}
			else
			{
				gameObject.camera.nearClipPlane = 0.5f;
				gameObject2.camera.nearClipPlane = 0.5f;
			}
			break;
		}
		case "toggleplanet":
			if (Global_ApplicationData.getTheSkyBoxOn())
			{
				Global_ApplicationData.getTheEnvironment().getBounceCamera().camera.clearFlags = CameraClearFlags.Color;
				Global_ApplicationData.getTheEnvironment().getDefaultCamera().camera.clearFlags = CameraClearFlags.Color;
				((SunShafts)Global_ApplicationData.getTheEnvironment().getDefaultCamera().GetComponent(typeof(SunShafts))).enabled = true;
				Global_ApplicationData.setTheSkyBoxOn(theonoff: false);
			}
			else
			{
				Global_ApplicationData.getTheEnvironment().getBounceCamera().camera.clearFlags = CameraClearFlags.Skybox;
				Global_ApplicationData.getTheEnvironment().getDefaultCamera().camera.clearFlags = CameraClearFlags.Skybox;
				((SunShafts)Global_ApplicationData.getTheEnvironment().getDefaultCamera().GetComponent(typeof(SunShafts))).enabled = false;
				Global_ApplicationData.setTheSkyBoxOn(theonoff: true);
			}
			break;
		case "toggletwitter":
		{
			Debug.Log("Toggle Twitter Called");
			Global_ApplicationData.theFrameForTweet = 1;
			GameObject[] theTweetHolder = Global_ApplicationData.getTheDynamicTextTweets().getTheTweetHolder();
			GameObject gameObject3 = theTweetHolder[0];
			GameObject gameObject4 = theTweetHolder[1];
			if (Global_ApplicationData.getTheTwitterOn())
			{
				((MeshRenderer)gameObject4.GetComponent(typeof(MeshRenderer))).renderer.material.color = new Color(20f, 20f, 20f, 0f);
				((MeshRenderer)gameObject3.GetComponent(typeof(MeshRenderer))).renderer.material.color = new Color(20f, 20f, 20f, 0f);
				Global_ApplicationData.setTheTwitterOn(theonoff: false);
			}
			else
			{
				((MeshRenderer)gameObject4.GetComponent(typeof(MeshRenderer))).renderer.material.color = new Color(20f, 20f, 20f, 1f);
				((MeshRenderer)gameObject3.GetComponent(typeof(MeshRenderer))).renderer.material.color = new Color(20f, 20f, 20f, 1f);
				Global_ApplicationData.setTheTwitterOn(theonoff: true);
			}
			break;
		}
		case "toggleexplosion":
			if (Global_ApplicationData.getTheExplosionOn())
			{
				Global_ApplicationData.explosionThingy.SetActive(value: false);
				Global_ApplicationData.setTheExplosionOn(theonoff: false);
			}
			else
			{
				Global_ApplicationData.explosionThingy.SetActive(value: true);
				Global_ApplicationData.setTheExplosionOn(theonoff: true);
			}
			break;
		case "toggleinstructions":
			if (Global_ApplicationData.getShowTheInstructions())
			{
				Global_ApplicationData.setShowTheInstructions(showYesNo: false);
			}
			else
			{
				Global_ApplicationData.setShowTheInstructions(showYesNo: true);
			}
			break;
		case "togglemojuzelogo":
			if (Global_ApplicationData.mojuzeLogo.activeSelf)
			{
				Global_ApplicationData.mojuzeLogo.SetActive(value: false);
			}
			else
			{
				Global_ApplicationData.mojuzeLogo.SetActive(value: true);
			}
			break;
		case "togglejtlogo1":
			Global_ApplicationData.theJTLogo1.SetActive(value: false);
			Global_ApplicationData.theJTLogo2.SetActive(value: false);
			Global_ApplicationData.theJTLogo3.SetActive(value: false);
			DisableAllGraphicalObjs();
			DisableAllGraphicalBGs();
			Global_ApplicationData.theJTLogo1.SetActive(value: true);
			break;
		case "togglejtlogo2":
			Global_ApplicationData.theJTLogo1.SetActive(value: false);
			Global_ApplicationData.theJTLogo2.SetActive(value: false);
			Global_ApplicationData.theJTLogo3.SetActive(value: false);
			DisableAllGraphicalObjs();
			DisableAllGraphicalBGs();
			Global_ApplicationData.theJTLogo2.SetActive(value: true);
			break;
		case "togglejtlogo3":
			Global_ApplicationData.theJTLogo1.SetActive(value: false);
			Global_ApplicationData.theJTLogo2.SetActive(value: false);
			Global_ApplicationData.theJTLogo3.SetActive(value: false);
			DisableAllGraphicalObjs();
			DisableAllGraphicalBGs();
			Global_ApplicationData.theJTLogo3.SetActive(value: true);
			break;
		case "killalljtlogo":
			Global_ApplicationData.theJTLogo1.SetActive(value: false);
			Global_ApplicationData.theJTLogo2.SetActive(value: false);
			Global_ApplicationData.theJTLogo3.SetActive(value: false);
			break;
		}
	}

	public virtual void ApplyGraphicalObjPattern()
	{
		int num = 0;
		int i = 0;
		GameObject[] graphicalObjectsInEnv = Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv();
		for (int length = graphicalObjectsInEnv.Length; i < length; i++)
		{
			UnityScript.Lang.Array array = null;
			array = Global_ApplicationData.getTheFavGOPatternArray()[Global_ApplicationData.getCurrentGOPattern()] as UnityScript.Lang.Array;
			if (RuntimeServices.ToBool(array[num]))
			{
				graphicalObjectsInEnv[i].SetActive(value: true);
			}
			else
			{
				graphicalObjectsInEnv[i].SetActive(value: false);
			}
			num++;
		}
	}

	public virtual void ChangeGraphicalBGPattern(string theChange)
	{
		if (theChange == "randompattern1")
		{
			RandomiseGBPattern(1);
		}
		else if (theChange == "disableallbgs")
		{
			DisableAllGraphicalBGs();
		}
	}

	public virtual void ChangeCamera(string theChange)
	{
		DisableAllCameras();
		Camera camera = null;
		int num = default(int);
		num = Global_ApplicationData.getTheEnvironment().getCamerasInEnvironment().Length;
		num--;
		if (theChange == "advancecamera")
		{
			Debug.Log(theChange + ": " + Global_ApplicationData.getTheAudioTimeSample());
			if (!(Global_ApplicationData.getTheCurrentCamera() >= (float)num))
			{
				Global_ApplicationData.setTheCurrentCamera((int)(Global_ApplicationData.getTheCurrentCamera() + 1f));
			}
			else
			{
				Global_ApplicationData.setTheCurrentCamera(0);
			}
		}
		else if (theChange == "rewindcamera")
		{
			Debug.Log(theChange + ": " + Global_ApplicationData.getTheAudioTimeSample());
			if (!(Global_ApplicationData.getTheCurrentCamera() <= 0f))
			{
				Global_ApplicationData.setTheCurrentCamera((int)(Global_ApplicationData.getTheCurrentCamera() - 1f));
			}
			else
			{
				Global_ApplicationData.setTheCurrentCamera(num);
			}
		}
		camera = Global_ApplicationData.getTheEnvironment().getCamerasInEnvironment()[(int)Global_ApplicationData.getTheCurrentCamera()];
		camera.camera.enabled = true;
	}

	public virtual void CalculateSwingBPM()
	{
		float time = Time.time;
		float num = default(float);
		float num2 = default(float);
		int num3 = 5;
		float num4 = 0f;
		num = time - Global_ApplicationData.getTheLastBounceTime();
		num2 = 60f / num;
		if (Global_ApplicationData.getTheBPMWarmUpCycle() > 5)
		{
			Global_ApplicationData.getTheCalcedBPMArray().Push(num2);
		}
		else
		{
			Global_ApplicationData.setTheBPMWarmUpCycle(Global_ApplicationData.getTheBPMWarmUpCycle() + 1);
		}
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(Global_ApplicationData.getTheCalcedBPMArray());
		while (enumerator.MoveNext())
		{
			float num5 = RuntimeServices.UnboxSingle(enumerator.Current);
			num4 += num5;
			UnityRuntimeServices.Update(enumerator, num5);
		}
		if (Global_ApplicationData.getTheCalcedBPMArray().length > num3)
		{
			string text = null;
			text = (Mathf.Round(num4 / (float)(num3 + 1) * Time.timeScale * 10f) / 10f).ToString();
			if (text.Length < 4)
			{
				text += ".0";
			}
			Global_ApplicationData.getTheCalcedBPMArray().Shift();
			Global_ApplicationData.setTheBPMLabel("Swing Cam BPM: " + text);
		}
		else
		{
			Global_ApplicationData.setTheBPMLabel("Swing Cam BPM: Calculating...");
		}
		Global_ApplicationData.setTheLastBounceTime(Time.time);
	}

	public virtual void ResetBounceCamera()
	{
		if (Global_ApplicationData.getTheEnvironment().getBounceCamera().camera.enabled)
		{
			Global_ApplicationData.getTheEnvironment().getBounceCamera().animation.Rewind();
			Global_ApplicationData.getTheCalcedBPMArray().Clear();
			Global_ApplicationData.setTheBPMWarmUpCycle(3);
		}
	}

	public virtual void ToggleSlowMotion()
	{
		Debug.Log("SlowMotion: " + Global_ApplicationData.getTheAudioTimeSample());
		if (Time.timeScale == 1f)
		{
			Time.timeScale = 0.3f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public virtual void AdvanceDynamicText()
	{
		Debug.Log("AdvancedDynamicTextCalled " + Global_ApplicationData.getTheDynamicTextTweets().getCurrentTweetPos());
		int num = default(int);
		GameObject[] array = null;
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		string text = null;
		string text2 = null;
		num = Global_ApplicationData.getTheDynamicTextTweets().getCurrentTweetPos();
		array = Global_ApplicationData.getTheDynamicTextTweets().getTheTweetHolder();
		gameObject = array[0];
		gameObject2 = array[1];
		text = Global_ApplicationData.getTheDynamicTextTweets().getTheTweetArray()[num] as string;
		text2 = ((Global_ApplicationData.getTheDynamicTextTweets().getCurrentTweetPos() != 1) ? (Global_ApplicationData.getTheDynamicTextTweets().getTheTweetArray()[num - 1] as string) : (Global_ApplicationData.getTheDynamicTextTweets().getTheTweetArray()[Global_ApplicationData.getTheDynamicTextTweets().getTheTweetArray().length - 1] as string));
		((TextMesh)gameObject2.GetComponent(typeof(TextMesh))).text = WordWrapText(text, 40);
		((MeshRenderer)gameObject2.GetComponent(typeof(MeshRenderer))).renderer.material.color = new Color(2f, 2f, 2f, 0.9f);
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(gameObject2.transform);
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			Transform transform = current as Transform;
			UnityRuntimeServices.Update(enumerator, current);
			((TextMesh)transform.GetComponent(typeof(TextMesh))).text = WordWrapText(text, 40);
		}
		((TextMesh)gameObject.GetComponent(typeof(TextMesh))).text = WordWrapText(text2, 40);
		IEnumerator enumerator2 = UnityRuntimeServices.GetEnumerator(gameObject.transform);
		while (enumerator2.MoveNext())
		{
			object obj = enumerator2.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform2 = (Transform)obj;
			Transform transform = transform2 as Transform;
			UnityRuntimeServices.Update(enumerator2, transform2);
			((TextMesh)transform.GetComponent(typeof(TextMesh))).text = WordWrapText(text2, 40);
		}
		HOTween.To(gameObject2.transform, 3f, new TweenParms().Prop("position", new Vector3(-28f, 0f, 50f)).Ease(EaseType.EaseOutQuad).Delay(0f));
		gameObject.transform.position = new Vector3(-28f, 0f, 50f);
		HOTween.To(gameObject.transform, 1.5f, new TweenParms().Prop("position", new Vector3(-28f, 0f, 150f)).Ease(EaseType.EaseOutQuad).Delay(0f));
		gameObject2.transform.position = new Vector3(-28f, 0f, -50f);
		Global_ApplicationData.getTheDynamicTextTweets().AdvanceTweetPos();
	}

	public virtual void RandomiseGOPattern(int numberOfElements)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		num = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv()));
		num2 = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv()));
		num3 = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv()));
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		for (int i = 0; i < Extensions.get_length((System.Array)Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv()); i++)
		{
			array.Push(0);
		}
		if (numberOfElements > 2)
		{
			array[num3] = 1;
		}
		if (numberOfElements > 1)
		{
			array[num2] = 1;
		}
		if (numberOfElements > 0)
		{
			array[num] = 1;
		}
		int num4 = 0;
		int j = 0;
		GameObject[] graphicalObjectsInEnv = Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv();
		for (int length = graphicalObjectsInEnv.Length; j < length; j++)
		{
			if (RuntimeServices.ToBool(array[num4]))
			{
				graphicalObjectsInEnv[j].SetActive(value: true);
			}
			else
			{
				graphicalObjectsInEnv[j].SetActive(value: false);
			}
			num4++;
		}
	}

	public virtual void StoreFavGoPattern()
	{
		int num = 0;
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		for (int i = 0; i < Extensions.get_length((System.Array)Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv()); i++)
		{
			array.Push(0);
		}
		int j = 0;
		GameObject[] graphicalObjectsInEnv = Global_ApplicationData.getTheEnvironment().getGraphicalObjectsInEnv();
		for (int length = graphicalObjectsInEnv.Length; j < length; j++)
		{
			if (graphicalObjectsInEnv[j].activeSelf)
			{
				array[num] = 1;
			}
			else
			{
				array[num] = 0;
			}
			num++;
		}
		Global_ApplicationData.addTheFavGOPatternArray(array);
	}

	public virtual void RemoveFavGoPattern()
	{
		if (Global_ApplicationData.getMaxGOPattern() >= 0)
		{
			Global_ApplicationData.removeFavGoPatternArray(Global_ApplicationData.getCurrentGOPattern());
		}
		Debug.Log("REMOVED FAVOURITE");
	}

	public virtual void RandomiseGBPattern(int numberOfElements)
	{
		int num = 0;
		GameObject gameObject = null;
		num = UnityEngine.Random.Range(0, Extensions.get_length((System.Array)Global_ApplicationData.getTheEnvironment().getGraphicalBGsInEnv()));
		gameObject = Global_ApplicationData.getTheEnvironment().getGraphicalBGsInEnv()[num];
		DisableAllGraphicalBGs();
		gameObject.SetActive(value: true);
	}

	public virtual void CheckAndDoTweetTween()
	{
		GameObject[] theTweetHolder = Global_ApplicationData.getTheDynamicTextTweets().getTheTweetHolder();
		GameObject gameObject = theTweetHolder[0];
		float z = gameObject.transform.position.z;
		if (Global_ApplicationData.getTheTwitterOn())
		{
			((MeshRenderer)gameObject.GetComponent(typeof(MeshRenderer))).renderer.material.color = new Color(255f, 255f, 255f, (100f - z) / 300f);
		}
	}

	public virtual void VisualiseAudio(float loudness)
	{
		loudness = loudness * Global_ApplicationData.theMicSensSlider * 10f;
		if (!(loudness <= 0.5f))
		{
			GlowEffect glowEffect = null;
			glowEffect = Global_ApplicationData.getTheEnvironment().getDefaultCamera().camera.GetComponent("GlowEffect") as GlowEffect;
			BloomAndLensFlares bloomAndLensFlares = null;
			bloomAndLensFlares = Global_ApplicationData.getTheEnvironment().getDefaultCamera().camera.GetComponent("BloomAndLensFlares") as BloomAndLensFlares;
			glowEffect.enabled = true;
			glowEffect.glowIntensity = loudness / 6f;
			bloomAndLensFlares.bloomIntensity = loudness / 2f;
		}
	}

	public virtual void CheckAndDoAutoRandomise()
	{
		if (Global_ApplicationData.theFrameForTweet % 1000 == 0 && Global_ApplicationData.autoAdvance)
		{
			Global_ApplicationData.getTheEnvController().ChangeGraphicalObjPattern("randompattern2");
			Global_ApplicationData.theFrameForTweet = 1;
		}
	}

	public virtual int RandomBoolean()
	{
		return (!(UnityEngine.Random.value < 0.5f)) ? 1 : 0;
	}

	public virtual void DoTextEffect(string style)
	{
		string text = "Hello My Name is What What What What Hello Woot Woot Woot";
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		if (Global_ApplicationData.theFrameCount < 200 && Resources.Load("Text_Furore_" + text[Global_ApplicationData.theFrameCount / 4 + 5]) != null)
		{
			gameObject = UnityEngine.Object.Instantiate(Resources.Load("AnimHolder_ Text_01"), new Vector3(-10 + Global_ApplicationData.theFrameCount / 8, 0f, -100f), Quaternion.identity) as GameObject;
			Quaternion identity = Quaternion.identity;
			identity.eulerAngles = new Vector3(0f, 180f, 0f);
			gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("Text_Furore_" + text[Global_ApplicationData.theFrameCount / 4 + 5]), new Vector3(0f, 0f, 0f), identity) as GameObject;
			gameObject2.transform.parent = gameObject.transform.FindChild("Cube");
			gameObject2.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject.transform.FindChild("Cube").GetComponent("MeshRenderer").renderer.enabled = false;
		}
	}

	public virtual string WordWrapText(string input, int lineLength)
	{
		string[] array = null;
		array = input.Split(" "[0]);
		string lhs = string.Empty;
		string text = string.Empty;
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string text2 = null;
			text2 = text + " " + array2[i];
			if (text2.Length > lineLength)
			{
				lhs += text + "\n";
				text = array2[i];
			}
			else
			{
				text = text2;
			}
		}
		lhs += text;
		return lhs.Substring(1, lhs.Length - 1);
	}
}
