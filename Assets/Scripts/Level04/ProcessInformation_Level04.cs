using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class ProcessInformation_Level04 : MonoBehaviour {

	public Text playerIfText; 
	public Text playerDoText;

	public bool tileEnabled;
	public string valueName;
	public string valueDoName;
	public Text error;
	public GameObject tile;
	public string playerValue;
	public bool triggerButton;

	public Animator buttonAnimator;

    // Use this for initialization
    void Start () {

	}

	void Update(){

	}

	// Update is called once per frame
	public void ButtonPressed () 
	{
		string playerIfString = playerIfText.text.ToString ();
		playerIfString = playerIfString.Replace (" ", string.Empty);
		string lastChar = playerIfString [playerIfString.Length - 1].ToString();

		if (playerIfString.Contains ("if(") && (lastChar == ")")) {
			playerIfString = playerIfString.Replace ("if(", string.Empty);
			playerIfString = playerIfString.Replace (")", string.Empty);
			playerIfString = playerIfString.Replace (" ", string.Empty);

			if (playerIfString.Contains ("==")) {
				playerValue = playerIfString.Substring (playerIfString.LastIndexOf ("==") + 2);
				playerValue = playerValue.Replace (" ", string.Empty);
				valueName = playerIfString.Substring (0, playerIfString.IndexOf ("=="));
				valueName = valueName.Replace (" ", string.Empty);
			} else {
				valueName = playerIfString;
			}

			if ((valueName == "buttonPressed" && playerValue == "true") || (valueName == "buttonPressed" && !playerIfString.Contains ("=="))) {

				string playerDoString = playerDoText.text.ToString ();

				if (playerDoString.Contains ("=")) {
					string playerDoValue = playerDoString.Substring (playerDoString.LastIndexOf ("=") + 1);
					valueDoName = playerDoString.Substring (0, playerDoString.IndexOf ("="));
					valueDoName = valueDoName.Replace (" ", string.Empty);

					if (valueDoName == "doorOpen") {
                        if (playerDoValue.Contains(";")){

                            playerDoValue = playerDoValue.Replace(";", string.Empty);
                            playerDoValue = playerDoValue.Replace(" ", string.Empty);

                            if (playerDoValue == "true" || playerDoValue == "false") {
                                triggerButton = System.Convert.ToBoolean(playerDoValue);

                                if (playerDoValue == "true") {
                                    buttonAnimator.SetInteger("AniState", 1);
                                    error.text = "Button active.";
                                }

                                if (playerDoValue == "false") {
                                    buttonAnimator.SetInteger("AniState", 0);
                                    error.text = "Button inactive.";
                                }

                            } else {
                                error.text = "Error: Wrong value.";
                            }
                        }
                        else
                        {
                            error.text = "Error: ; expected.";
                        }




                    } else {
						error.text = "Error: Wrong value name.";
					}

				} else {
					error.text = "Error: = expected.";
				}

			} else {
				error.text = "Error: Wrong if statement.";
			}
		} else {
			error.text = "Error: 'if' expected.";
		}
	}

    		
}
