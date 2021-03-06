using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class ProcessInformation_Level01 : MonoBehaviour {

	public Text playerText;

	public bool tileEnabled;
	public string valueName;
	public Text error;
	public GameObject tile;

    // Use this for initialization
    void Start () {

	}

	void Update(){

	}

	// Update is called once per frame
	public void ButtonPressed () {
		string playerString = playerText.text.ToString ();
		if (playerString.Contains ("=")) 
		{
			string playerValue = playerString.Substring (playerString.LastIndexOf ("=") + 1);
			valueName = playerString.Substring (0, playerString.IndexOf ("="));
			valueName = valueName.Replace (" ", string.Empty);

			if (valueName == "tileEnabled") {
				if (playerValue.Contains (";") ) {
					playerValue = playerValue.Replace (";", string.Empty);


					playerValue = playerValue.Replace (" ", string.Empty);

					if (playerValue == "true" || playerValue == "false") {
						tileEnabled = System.Convert.ToBoolean (playerValue);
						tile = GameObject.Find ("Platforms").transform.Find ("Tile").gameObject;
						tile.SetActive (tileEnabled);

						if (playerValue == "true")
						{							
							error.text = "Tile Enabled.";
						}

						if (playerValue == "false")
						{
							
							error.text = "Tile Disabled.";
						}

					} else {

						error.text = "Error: Not a correct value. Can only be either true or false.";
					}

				} else {

					error.text = "Error: ; expected.";
				}

			} else 
			{

				error.text = "Error: Not a correct variable.";
			}
		} else 
		{

			error.text = "Error: = expected.";
		}

    }
}
