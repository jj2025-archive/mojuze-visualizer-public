using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Door : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnTriggerEnter_002479 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Door _0024self__002480;

			public _0024(Door self_)
			{
				_0024self__002480 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Debug.Log("enter");
					if (_0024self__002480.queue == -1f)
					{
						goto case 2;
					}
					_0024self__002480.queue = 0f;
					goto IL_0080;
				case 2:
					if (_0024self__002480.animation.isPlaying)
					{
						result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
						break;
					}
					_0024self__002480.Open();
					goto IL_0080;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0080:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Door _0024self__002481;

		public _0024OnTriggerEnter_002479(Door self_)
		{
			_0024self__002481 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002481);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnTriggerExit_002482 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Door _0024self__002483;

			public _0024(Door self_)
			{
				_0024self__002483 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002483.queue == -1f)
					{
						goto case 2;
					}
					_0024self__002483.queue = 0.5f;
					goto IL_0079;
				case 2:
					if (_0024self__002483.animation.isPlaying)
					{
						result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
						break;
					}
					_0024self__002483.Close();
					goto IL_0079;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0079:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Door _0024self__002484;

		public _0024OnTriggerExit_002482(Door self_)
		{
			_0024self__002484 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002484);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PlayAnim_002485 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Door _0024self__002486;

			public _0024(Door self_)
			{
				_0024self__002486 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002486.animation[_0024self__002486.animation.clip.name].normalizedTime = _0024self__002486.queue;
					_0024self__002486.Sounds();
					_0024self__002486.animation.Play();
					result = (Yield(2, new WaitForSeconds(_0024self__002486.halftime)) ? 1 : 0);
					break;
				case 2:
					_0024self__002486.animation.Stop();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Door _0024self__002487;

		public _0024PlayAnim_002485(Door self_)
		{
			_0024self__002487 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002487);
		}
	}

	private float queue;

	private float halftime;

	public AudioSource[] audiosources;

	public ParticleEmitter[] emitters;

	public Door()
	{
		queue = -1f;
	}

	public virtual void Start()
	{
		animation[animation.clip.name].normalizedTime = 0.5f;
		halftime = animation[animation.clip.name].time;
	}

	public virtual IEnumerator OnTriggerEnter()
	{
		return new _0024OnTriggerEnter_002479(this).GetEnumerator();
	}

	public virtual IEnumerator OnTriggerExit()
	{
		return new _0024OnTriggerExit_002482(this).GetEnumerator();
	}

	public virtual IEnumerator PlayAnim()
	{
		return new _0024PlayAnim_002485(this).GetEnumerator();
	}

	public virtual void Open()
	{
		queue = 0f;
		StartCoroutine_Auto(PlayAnim());
		if (queue == 0f)
		{
			queue = -1f;
		}
		else
		{
			Close();
		}
	}

	public virtual void Close()
	{
		queue = 0.5f;
		StartCoroutine_Auto(PlayAnim());
		if (queue == 0.5f)
		{
			queue = -1f;
		}
		else
		{
			Open();
		}
	}

	public virtual void Sounds()
	{
		int i = 0;
		AudioSource[] array = audiosources;
		for (int length = array.Length; i < length; i++)
		{
			array[i].Play();
		}
	}

	public virtual void Main()
	{
	}
}
