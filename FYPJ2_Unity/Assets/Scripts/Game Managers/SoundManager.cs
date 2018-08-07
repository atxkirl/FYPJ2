using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMono<SoundManager>
{
	[SerializeField]
	private AudioSource soundSource;
	[SerializeField]
	private float minVolume = 0.5f;
	[SerializeField]
	private float maxVolume = 1.0f;

	private void Awake()
	{
		//Set SoundManager to not be destroyed when loading new scenes
		DontDestroyOnLoad(Instance);
	}

	//Play single audio clips
	public void PlayOnce(AudioClip _audioClip)
	{
		soundSource.PlayOneShot(_audioClip);
	}

	//Play single audio clips with volume
	public void PlayOnce(AudioClip _audioClip, float _volume)
	{
		soundSource.PlayOneShot(_audioClip, _volume);
	}

	//Play single audio clips without overlap
	public void PlayOnceNoOverlap(AudioClip _audioClip)
	{
		if (!soundSource.isPlaying)
			soundSource.PlayOneShot(_audioClip);
	}

	//Play single audio clips without overlap with volume
	public void PlayOnceNoOverlap(AudioClip _audioClip, float _volume)
	{
		if (!soundSource.isPlaying)
			soundSource.PlayOneShot(_audioClip, _volume);
	}
}
