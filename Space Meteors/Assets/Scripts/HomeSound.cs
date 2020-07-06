using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSound : MonoBehaviour {

    public AudioSource homeSound;

	void Start ()
    {
        homeSound.Play();
	}
}
