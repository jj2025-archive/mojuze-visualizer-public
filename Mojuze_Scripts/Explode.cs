using System;
using UnityEngine;

[Serializable]
public class Explode : MonoBehaviour
{
	public virtual void Start()
	{
		Physics.gravity = new Vector3(0f, -5f, 0f);
		float num = UnityEngine.Random.Range(800f, 1000f);
		float explosionForce = UnityEngine.Random.Range(1200f, 1800f);
		Vector3 position = transform.position;
		Collider[] array = Physics.OverlapSphere(position, num);
		int i = 0;
		Collider[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if ((bool)array2[i] && (bool)array2[i].rigidbody)
			{
				array2[i].rigidbody.AddExplosionForce(explosionForce, position, num, 3f);
			}
		}
	}

	public virtual void Update()
	{
	}

	public virtual void Main()
	{
	}
}
