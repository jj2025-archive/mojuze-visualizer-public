using System;
using UnityEngine;

[Serializable]
public class SpriteEffect : MonoBehaviour
{
	public bool keepMeshSize;

	public Vector3 size;

	public float speedGrowing;

	public CameraFacingMode billboarding;

	public bool randomRotation;

	public int uvAnimationTileX;

	public int uvAnimationTileY;

	public float framesPerSecond;

	public bool oneShot;

	public bool addLightEffect;

	public float lightRange;

	public Color lightColor;

	public float lightFadSpeed;

	private AudioSource soundEffect;

	private GameObject mainCam;

	private bool effectEnd;

	private float randomZAngle;

	private float startTime;

	public SpriteEffect()
	{
		keepMeshSize = true;
		size = new Vector3(1f, 1f, 1f);
		uvAnimationTileX = 8;
		uvAnimationTileY = 8;
		framesPerSecond = 26f;
		lightFadSpeed = 1f;
	}

	public virtual void Awake()
	{
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
	}

	public virtual void Start()
	{
		soundEffect = GetComponent("AudioSource") as AudioSource;
		if (!keepMeshSize)
		{
			transform.localScale = size;
		}
		if (addLightEffect)
		{
			gameObject.AddComponent("Light");
			gameObject.light.color = lightColor;
			gameObject.light.range = lightRange;
		}
		if (randomRotation)
		{
			randomZAngle = UnityEngine.Random.Range(-180f, 180f);
		}
		else
		{
			randomZAngle = 0f;
		}
		startTime = Time.time;
		renderer.enabled = false;
	}

	public virtual void Update()
	{
		Camera_BillboardingMode();
		Update_Animation();
	}

	public virtual void Update_Animation()
	{
		bool flag = false;
		int num = (int)((Time.time - startTime) * framesPerSecond);
		if ((num < uvAnimationTileX * uvAnimationTileY || !oneShot) && !effectEnd)
		{
			num %= uvAnimationTileX * uvAnimationTileY;
			Vector2 scale = new Vector2(1f / (float)uvAnimationTileX, 1f / (float)uvAnimationTileY);
			int num2 = num % uvAnimationTileX;
			int num3 = num / uvAnimationTileX;
			Vector2 offset = new Vector2((float)num2 * scale.x, 1f - scale.y - (float)num3 * scale.y);
			renderer.material.SetTextureOffset("_MainTex", offset);
			renderer.material.SetTextureScale("_MainTex", scale);
			transform.localScale += new Vector3(speedGrowing, speedGrowing, speedGrowing) * Time.deltaTime;
			renderer.enabled = true;
		}
		else
		{
			effectEnd = true;
			flag = true;
			if ((bool)soundEffect && soundEffect.isPlaying)
			{
				flag = false;
			}
			if (addLightEffect && flag && !(gameObject.light.intensity <= 0f))
			{
				flag = false;
			}
			if (flag)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		if (addLightEffect && lightFadSpeed != 0f)
		{
			gameObject.light.intensity = gameObject.light.intensity - lightFadSpeed * Time.deltaTime;
		}
	}

	public virtual void Camera_BillboardingMode()
	{
		switch (billboarding)
		{
		case CameraFacingMode.Always:
		{
			float z3 = randomZAngle;
			Vector3 eulerAngles5 = transform.eulerAngles;
			float num5 = (eulerAngles5.z = z3);
			Vector3 vector9 = (transform.eulerAngles = eulerAngles5);
			float x2 = mainCam.transform.eulerAngles.x;
			Vector3 eulerAngles6 = transform.eulerAngles;
			float num6 = (eulerAngles6.x = x2);
			Vector3 vector11 = (transform.eulerAngles = eulerAngles6);
			float y2 = mainCam.transform.eulerAngles.y;
			Vector3 eulerAngles7 = transform.eulerAngles;
			float num7 = (eulerAngles7.y = y2);
			Vector3 vector13 = (transform.eulerAngles = eulerAngles7);
			break;
		}
		case CameraFacingMode.Horizontal:
		{
			float y = mainCam.transform.eulerAngles.y;
			Vector3 eulerAngles3 = transform.eulerAngles;
			float num3 = (eulerAngles3.y = y);
			Vector3 vector5 = (transform.eulerAngles = eulerAngles3);
			float z2 = mainCam.transform.eulerAngles.z;
			Vector3 eulerAngles4 = transform.eulerAngles;
			float num4 = (eulerAngles4.z = z2);
			Vector3 vector7 = (transform.eulerAngles = eulerAngles4);
			break;
		}
		case CameraFacingMode.Vertical:
		{
			float x = mainCam.transform.eulerAngles.x;
			Vector3 eulerAngles = transform.eulerAngles;
			float num = (eulerAngles.x = x);
			Vector3 vector = (transform.eulerAngles = eulerAngles);
			float z = mainCam.transform.eulerAngles.z;
			Vector3 eulerAngles2 = transform.eulerAngles;
			float num2 = (eulerAngles2.z = z);
			Vector3 vector3 = (transform.eulerAngles = eulerAngles2);
			break;
		}
		}
	}

	public virtual void Main()
	{
	}
}
