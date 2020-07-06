using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioSource explosion;
    public static AudioSource boom;

	private void Awake()
	{
		AudioSource[] allSources = GetComponentsInChildren<AudioSource> ();

		foreach (var source in allSources) {
			if (source.clip.name.Equals ("explosion2")) {
				explosion = source;
			}
            if (source.clip.name.Equals("boom"))
            {
                boom = source;
            }
        }
	}
}
