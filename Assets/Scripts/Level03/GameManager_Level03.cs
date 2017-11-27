using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Level03 : MonoBehaviour {

	public static bool GameIsOver;
	//public GameObject gameOverUI;
	public string nextLevel;
	public int levelToUnlock;
	public SceneFader fader;

	public DoorOpen_Level03 door;



	// Use this for initialization
	void Start () {
		GameIsOver = false;
	//	door = GetComponent<DoorOpen> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (door.finish) {
			EndGame ();
		}

	}

	void EndGame ()
	{
		GameIsOver = true;
	}

	public void WinLevel ()
	{
		int currLevelReached = PlayerPrefs.GetInt ("levelReached");
		if (currLevelReached < 5) {	
			PlayerPrefs.SetInt ("levelReached", levelToUnlock);
		}
		fader.FadeTo (nextLevel);
	}

}
