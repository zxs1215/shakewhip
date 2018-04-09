using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudioClip : MonoBehaviour {
	public AudioClip[] clips;
	public Transform parent;
	public GameObject togglePrefab;
	public AudioSource audios;
	List<Toggle> toggles;
	Dictionary<string,AudioClip> dic;
	// Use this for initialization
	void Start () {
		dic = new Dictionary<string ,AudioClip> ();
		toggles = new List<Toggle> ();


		foreach (var clip in clips) {
			dic.Add (clip.name, clip);
			GameObject o = Instantiate (togglePrefab, parent);
			Toggle toggle = o.GetComponent<Toggle> ();
			toggle.GetComponentInChildren<Text> ().text = clip.name;
			toggle.name = clip.name;
			toggle.group = GetComponent<ToggleGroup> ();
			toggle.onValueChanged.AddListener ((ison) => {
				if(ison)
				{
					audios.clip = dic[toggle.name];
				}
			});
			toggles.Add (toggle);
		}
		if (clips.Length != 0) {
			toggles [0].isOn = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
