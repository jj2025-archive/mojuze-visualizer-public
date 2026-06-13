using System;
using System.Collections;
using UnityEngine;
using UnityScript.Lang;

public static class Global_ApplicationData
{
	[NonSerialized]
	private static Model_TheEnvironment theEnvironment;

	[NonSerialized]
	private static Model_AudioSyncing theAudioSyncing;

	[NonSerialized]
	private static Model_DynamicText_Tweets theDynamicTextTweets;

	[NonSerialized]
	private static Controller_AudioSyncing theAudioSyncController;

	[NonSerialized]
	private static Controller_TheEnvironment theEnvController;

	[NonSerialized]
	private static Controller_KeyboardInput theKeyboardInputController;

	[NonSerialized]
	private static View_UserInterface theViewUserInterface;

	[NonSerialized]
	public static int theFrameCount = 1;

	[NonSerialized]
	public static GameObject electrifiedLogo = GameObject.Find("Logo: ELECTRIFIED");

	[NonSerialized]
	public static GameObject explosionThingy;

	[NonSerialized]
	public static GameObject mojuzeWatermark = GameObject.Find("GUI Text: Mojuze Open Beta Watermark 1");

	[NonSerialized]
	public static GameObject mojuzeLogo = GameObject.Find("Logo: MojuzeLogo");

	[NonSerialized]
	public static bool autoAdvance = true;

	[NonSerialized]
	public static float theMicSensSlider = 7.5f;

	[NonSerialized]
	public static int theFrameForTweet = 1;

	[NonSerialized]
	public static bool theStrobeOnOff;

	[NonSerialized]
	public static bool theJTLogoOnOff1;

	[NonSerialized]
	public static GameObject theJTLogo1 = GameObject.Find("Cube: Video Sprite JT 1");

	[NonSerialized]
	public static bool theJTLogoOnOff2;

	[NonSerialized]
	public static GameObject theJTLogo2 = GameObject.Find("Cube: Video Sprite JT 2");

	[NonSerialized]
	public static bool theJTLogoOnOff3;

	[NonSerialized]
	public static GameObject theJTLogo3 = GameObject.Find("Cube: Video Sprite JT 3");

	[NonSerialized]
	private static float theAudioTimeSample;

	[NonSerialized]
	public static Hashtable theAudioCues_00 = new Hashtable();

	[NonSerialized]
	public static Hashtable theAudioUserHits_00 = new Hashtable();

	[NonSerialized]
	private static float theBounceCameraSpeed = 0.93f;

	[NonSerialized]
	private static int theCurrentGOPattern;

	[NonSerialized]
	private static int theCurrentGBPattern;

	[NonSerialized]
	private static int theMaxGOPattern;

	[NonSerialized]
	private static int theMaxGBPattern;

	[NonSerialized]
	private static UnityScript.Lang.Array theFavGOPatternArray = new UnityScript.Lang.Array();

	[NonSerialized]
	private static UnityScript.Lang.Array theFavGBPatternArray = new UnityScript.Lang.Array();

	[NonSerialized]
	private static float theCurrentCamera = 1f;

	[NonSerialized]
	private static bool theSkyBoxOn = true;

	[NonSerialized]
	private static bool theTwitterOn;

	[NonSerialized]
	private static bool theExplosionOn;

	[NonSerialized]
	private static float theLastBounceTime = Time.time;

	[NonSerialized]
	private static UnityScript.Lang.Array theCalcedBPMArray = new UnityScript.Lang.Array();

	[NonSerialized]
	private static int theBPMWarmUpCycle;

	[NonSerialized]
	private static string theAppLabel = "MOJUZE V1.0 Public Beta (C)2013 MobileJuze Pty Ltd\n(Final paid version will be watermark-free)";

	[NonSerialized]
	private static Rect theAppLabelPosition = new Rect(50f, 15f, 500f, 60f);

	[NonSerialized]
	private static string theSpeedLabel = "Speed (press Space): ";

	[NonSerialized]
	private static Rect theSpeedLabelPosition = new Rect(50f, 70f, 500f, 60f);

	[NonSerialized]
	private static string theBPMLabel = "Swing Cam BPM: ";

	[NonSerialized]
	private static Rect theBPMLabelPosition = new Rect(50f, 91f, 500f, 60f);

	[NonSerialized]
	private static string theFavSlotLabel = "Favourite Slot: ";

	[NonSerialized]
	private static Rect theFavSlotPosition = new Rect(50f, 112f, 300f, 30f);

	[NonSerialized]
	private static GUISkin theGUISkin = Resources.Load("MetalGUISkin") as GUISkin;

	[NonSerialized]
	public static Rect theInstructionsLabelPos = new Rect(50f, 220f, 500f, 300f);

	[NonSerialized]
	private static string theInstructions = "Press Esc to show or hide this screen.\n" + "Press 1, 2 or 3 to randomize scenes.\n" + "Press Space to toggle slow-motion.\n" + "Press M to toggle the Mojuze logo.\n" + "Press Up or Down to change cameras.\n" + "Press B to toggle scene blackout.\n" + "Press V for random video background.\n" + "Press C to cancel video background.\n" + "Press Alt-F4 to quit Mojuze.\n" + "Feedback welcome at Mojuze.com!\n " + string.Empty;

	[NonSerialized]
	private static bool showTheInstructions = true;

	[NonSerialized]
	private static string theTwoFiveDLogotype = "Your Text Here";

	public static float getTheAudioTimeSample()
	{
		return theAudioTimeSample;
	}

	public static Model_TheEnvironment getTheEnvironment()
	{
		return theEnvironment;
	}

	public static Model_AudioSyncing getTheAudioSyncing()
	{
		return theAudioSyncing;
	}

	public static Model_DynamicText_Tweets getTheDynamicTextTweets()
	{
		return theDynamicTextTweets;
	}

	public static Controller_AudioSyncing getTheAudioSyncController()
	{
		return theAudioSyncController;
	}

	public static Controller_TheEnvironment getTheEnvController()
	{
		return theEnvController;
	}

	public static Controller_KeyboardInput getTheKeyboardInputController()
	{
		return theKeyboardInputController;
	}

	public static View_UserInterface getTheViewUserInterface()
	{
		return theViewUserInterface;
	}

	public static float getBounceCameraSpeed()
	{
		return theBounceCameraSpeed;
	}

	public static bool getTheSkyBoxOn()
	{
		return theSkyBoxOn;
	}

	public static bool getTheTwitterOn()
	{
		return theTwitterOn;
	}

	public static bool getTheExplosionOn()
	{
		return theExplosionOn;
	}

	public static int getCurrentGOPattern()
	{
		return theCurrentGOPattern;
	}

	public static int getMaxGOPattern()
	{
		return theFavGOPatternArray.length - 1;
	}

	public static UnityScript.Lang.Array getTheFavGOPatternArray()
	{
		return theFavGOPatternArray;
	}

	public static int getCurrentGBPattern()
	{
		return theCurrentGBPattern;
	}

	public static int getMaxGBPattern()
	{
		return theFavGBPatternArray.length - 1;
	}

	public static UnityScript.Lang.Array getTheFavGBPatternArray()
	{
		return theFavGBPatternArray;
	}

	public static float getTheCurrentCamera()
	{
		return theCurrentCamera;
	}

	public static string getTheAppLabel()
	{
		return theAppLabel;
	}

	public static Rect getTheAppLabelPosition()
	{
		return theAppLabelPosition;
	}

	public static string getTheSpeedLabel()
	{
		return theSpeedLabel;
	}

	public static Rect getTheSpeedLabelPosition()
	{
		return theSpeedLabelPosition;
	}

	public static string getTheBPMLabel()
	{
		return theBPMLabel;
	}

	public static Rect getTheBPMLabelPosition()
	{
		return theBPMLabelPosition;
	}

	public static Rect getTheFavSlotPosition()
	{
		return theFavSlotPosition;
	}

	public static string getTheFavSlotLabel()
	{
		return (getTheFavGOPatternArray().length <= 0) ? (theFavSlotLabel + "None, Total: " + getTheFavGOPatternArray().length) : (theFavSlotLabel + (getCurrentGOPattern() + 1) + ", Total: " + getTheFavGOPatternArray().length);
	}

	public static GUISkin getTheGUISkin()
	{
		return theGUISkin;
	}

	public static string getTheInstructions()
	{
		return theInstructions;
	}

	public static bool getShowTheInstructions()
	{
		return showTheInstructions;
	}

	public static string getTheTwoFiveDLogotype()
	{
		return theTwoFiveDLogotype;
	}

	public static float getTheLastBounceTime()
	{
		return theLastBounceTime;
	}

	public static UnityScript.Lang.Array getTheCalcedBPMArray()
	{
		return theCalcedBPMArray;
	}

	public static int getTheBPMWarmUpCycle()
	{
		return theBPMWarmUpCycle;
	}

	public static void setTheAudioTimeSample(float theTimeSample)
	{
		theAudioTimeSample = theTimeSample;
	}

	public static void setTheEnvironment(Model_TheEnvironment theEnv)
	{
		theEnvironment = theEnv;
	}

	public static void setTheAudioSyncing(Model_AudioSyncing theSync)
	{
		theAudioSyncing = theSync;
	}

	public static void setTheDynamicTextTweets(Model_DynamicText_Tweets theTweets)
	{
		theDynamicTextTweets = theTweets;
	}

	public static void setTheAudioSyncController(Controller_AudioSyncing theCtl)
	{
		theAudioSyncController = theCtl;
	}

	public static void setTheEnvController(Controller_TheEnvironment theCtl)
	{
		theEnvController = theCtl;
	}

	public static void setTheKeyboardInputController(Controller_KeyboardInput theKeyb)
	{
		theKeyboardInputController = theKeyb;
	}

	public static void setTheViewUserInterface(View_UserInterface theView)
	{
		theViewUserInterface = theView;
	}

	public static void setShowTheInstructions(bool showYesNo)
	{
		showTheInstructions = showYesNo;
	}

	public static void setTheTwoFiveDLogotype(string theText)
	{
		theTwoFiveDLogotype = theText;
	}

	public static void setBounceCameraSpeed(float theSpeed)
	{
		theBounceCameraSpeed = theSpeed;
	}

	public static void setTheSkyBoxOn(bool theonoff)
	{
		theSkyBoxOn = theonoff;
	}

	public static void setTheTwitterOn(bool theonoff)
	{
		theTwitterOn = theonoff;
	}

	public static void setTheExplosionOn(bool theonoff)
	{
		theExplosionOn = theonoff;
	}

	public static void setCurrentGOPattern(int thePattern)
	{
		theCurrentGOPattern = thePattern;
	}

	public static void addTheFavGOPatternArray(UnityScript.Lang.Array fav)
	{
		theFavGOPatternArray.Push(fav);
	}

	public static void removeFavGoPatternArray(int fav)
	{
		if (theFavGOPatternArray.length > 0)
		{
			Debug.Log(getCurrentGOPattern());
			if (getCurrentGOPattern() + 2 > theFavGOPatternArray.length)
			{
				getTheEnvController().ChangeGraphicalObjPattern("rewindpattern");
			}
			theFavGOPatternArray.RemoveAt(fav);
		}
	}

	public static void setTheCurrentCamera(int theCamera)
	{
		theCurrentCamera = theCamera;
	}

	public static void setTheLastBounceTime(float theTime)
	{
		theLastBounceTime = theTime;
	}

	public static void setTheBPMLabel(string theLabel)
	{
		theBPMLabel = theLabel;
	}

	public static void setTheCalcedBPMArray(UnityScript.Lang.Array theArray)
	{
		theCalcedBPMArray = theArray;
	}

	public static void setTheBPMWarmUpCycle(int theCycle)
	{
		theBPMWarmUpCycle = theCycle;
	}
}
