using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Audio : MonoBehaviour {

	private static Audio instance = null;
	public static Audio Instance {
		get { return instance; }
	}

	public AudioMixer mixer;
	public float fadeInterval = 1f;

	// Volume settings
	private float minVolume = -20f;
	private float maxVolume = 0f;
	private float waitTimeBeforeFade = 1f;

	private IEnumerator fadeInCoroutine;
	private IEnumerator fadeOutCoroutine;

	// Instantiate once (singleton)
	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Most complicated way to fade in and out channels ever
	public void PlayNano() {
		if (fadeOutCoroutine != null) {
			StopCoroutine(fadeOutCoroutine);
		}
		if (fadeInCoroutine != null) {
			StopCoroutine(fadeInCoroutine);
		}

		fadeInCoroutine = FadeInChannel("NanoVolume");
		fadeOutCoroutine = FadeOutChannel("PicoVolume");
		StartCoroutine(fadeInCoroutine);
		StartCoroutine(fadeOutCoroutine);
	}

	public void PlayPico() {
		if (fadeOutCoroutine != null) {
			StopCoroutine(fadeOutCoroutine);
		}
		if (fadeInCoroutine != null) {
			StopCoroutine(fadeInCoroutine);
		}

		fadeInCoroutine = FadeInChannel("PicoVolume");
		fadeOutCoroutine = FadeOutChannel("NanoVolume");
		StartCoroutine(fadeInCoroutine);
		StartCoroutine(fadeOutCoroutine);
	}

	// Coroutines for fading in and out
	IEnumerator FadeInChannel(string channel) {
		float volume;
		for (mixer.GetFloat(channel, out volume); volume <= maxVolume; volume += fadeInterval) {
			mixer.SetFloat(channel, volume);
			yield return null;
		}
	}

	IEnumerator FadeOutChannel(string channel) {
		yield return new WaitForSeconds(waitTimeBeforeFade);
		float volume;
		for (mixer.GetFloat(channel, out volume); volume >= minVolume; volume -= fadeInterval) {
			mixer.SetFloat(channel, volume);
			yield return null;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
