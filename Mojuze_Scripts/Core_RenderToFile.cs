using System;
using System.IO;
using UnityEngine;

[Serializable]
public class Core_RenderToFile : MonoBehaviour
{
	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void renderToScreenTempFunction(int theFrame)
	{
		Camera camera = new GameObject("PPCamera", typeof(Camera)).camera;
		camera.camera.enabled = false;
		camera.CopyFrom(Global_ApplicationData.getTheEnvironment().getDefaultCamera().camera);
		camera.clearFlags = CameraClearFlags.Skybox;
		camera.backgroundColor = new Color(0f, 0f, 0f, 0f);
		Shader shader = null;
		shader = Shader.Find("FX/XRay Special Alpha");
		Debug.Log(shader);
		camera.camera.SetReplacementShader(shader, string.Empty);
		GameObject.Find("Camera: Main Camera").camera.enabled = true;
		Time.timeScale = 0f;
		Camera camera2 = Global_ApplicationData.getTheEnvironment().getDefaultCamera().camera;
		Camera camera3 = GameObject.Find("PPCamera").camera;
		RenderTexture renderTexture = new RenderTexture(2048, 1152, 24);
		RenderTexture renderTexture2 = new RenderTexture(2048, 1152, 24);
		camera2.targetTexture = renderTexture;
		camera2.Render();
		RenderTexture.active = renderTexture;
		Texture2D texture2D = new Texture2D(2048, 1152, TextureFormat.RGB24, mipmap: false);
		texture2D.ReadPixels(new Rect(0f, 0f, 2048f, 1152f), 0, 0);
		texture2D.Apply();
		camera3.targetTexture = renderTexture2;
		camera3.Render();
		RenderTexture.active = renderTexture2;
		Texture2D texture2D2 = new Texture2D(2048, 1152, TextureFormat.ARGB32, mipmap: false);
		texture2D2.ReadPixels(new Rect(0f, 0f, 2048f, 1152f), 0, 0);
		texture2D2.Apply();
		for (int i = 0; i < texture2D2.width; i++)
		{
			for (int j = 0; j < texture2D2.height; j++)
			{
				Color pixel = texture2D2.GetPixel(i, j);
				Color pixel2 = texture2D.GetPixel(i, j);
				float a = pixel.a;
				if (a != 0f)
				{
					pixel /= a;
					pixel.a = a;
					pixel2.a = a + 0.05f;
					texture2D2.SetPixel(i, j, pixel2);
				}
			}
		}
		byte[] bytes = texture2D2.EncodeToPNG();
		File.WriteAllBytes("D:/SavedAlpha_" + theFrame + ".png", bytes);
		UnityEngine.Object.Destroy(texture2D);
		UnityEngine.Object.Destroy(texture2D2);
		camera3.targetTexture = null;
		RenderTexture.active = null;
		UnityEngine.Object.DestroyImmediate(renderTexture2);
		camera2.targetTexture = null;
		RenderTexture.active = null;
		UnityEngine.Object.DestroyImmediate(renderTexture);
		Time.timeScale = 0.05f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	public virtual void Main()
	{
	}
}
