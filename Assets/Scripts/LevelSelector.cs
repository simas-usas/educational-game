using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public SceneFader fader;
	public int levelReached;

	public Button[] levelButtons;

	void Start (){
		levelReached = PlayerPrefs.GetInt("levelReached", 1);

			for (int i = 0; i < levelButtons.Length; i++) {
				if (i + 1 > levelReached)
					levelButtons [i].interactable = false;

			}

	}


	// Use this for initialization
	public void Select (string levelName){
		fader.FadeTo (levelName);

	}
}
