using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAction : MonoBehaviour {
	public Shake shake;
	public AudioSource audios;
	void Start(){
		shake.act += () => {
			if(!audios.isPlaying)
				audios.Play ();
		};
	}
}
