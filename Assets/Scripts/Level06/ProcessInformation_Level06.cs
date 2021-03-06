using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.Linq;

public class ProcessInformation_Level06 : MonoBehaviour {

	public Text playerIfText; 
	public Text playerDoText;

	public bool tileEnabled;
	public string[] valueName = new string[2];
	public string valueDoName;
	public Text error;
	public string[] playerValue = new string[2];
	public bool triggerButtons;
	//public bool triggerBlueButton;


	public bool blueButton;
	public bool redButton;


    // Use this for initialization
    void Start () {
		redButton = false;
		blueButton = false;
	}


	// Update is called once per frame
	public void ButtonPressed ()
	{
		string playerIfString = playerIfText.text.ToString ();
		playerIfString = playerIfString.Replace (" ", string.Empty);
		string lastChar = playerIfString [playerIfString.Length - 1].ToString ();

		if (playerIfString.Contains ("if(") && (lastChar == ")")) {

			playerIfString = playerIfString.Replace ("if(", string.Empty);
			playerIfString = playerIfString.Replace (")", string.Empty);
			playerIfString = playerIfString.Replace (" ", string.Empty);


			if (playerIfString.Contains ("||")) {
				
				string[] playerArgEx = playerIfString.Split ("||".ToCharArray ());

                

                List<String> list = playerArgEx.ToList(); // <- to List which is mutable
                list.RemoveAt(1);           // <- remove 
                string[] playerArg = list.ToArray();
                
				int argAmount = playerIfString.Split( "||".ToCharArray()).Length - 2;
                if (argAmount > 1) { error.text = "Error: Too many arguments."; }

                for (int i = 0; i <= argAmount; i++) {

                    if (playerArg [i].Contains ("==")) {
						playerValue[i] = playerArg [i].Substring (playerArg [i].LastIndexOf ("==") + 2);
						playerValue[i] = playerValue[i].Replace (" ", string.Empty);
						valueName[i] = playerArg [i].Substring (0, playerArg [i].IndexOf ("=="));
						valueName[i] = valueName[i].Replace (" ", string.Empty);
					} else {
						valueName[i] = playerArg [i];
					}

                    if ((valueName[i] == "redButton" && playerValue[i] == "true") || (valueName[i] == "redButton" && !playerArg[i].Contains("==")))
                    {
                        redButton = true;
                        //	buttonAnimator.SetInteger("AniState", 1);
                    }

                    else if ((valueName[i] == "blueButton" && playerValue[i] == "true") || (valueName[i] == "blueButton" && !playerArg[i].Contains("==")))
                    {
                        blueButton = true;
                        //	buttonAnimator.SetInteger("AniState", 0);
                    }
                    else {
                        error.text = "Error: Wrong variable name.";
                    }

				}

				if (redButton && blueButton) {
					string playerDoString = playerDoText.text.ToString ();

					if (playerDoString.Contains ("=")) {
						string playerDoValue = playerDoString.Substring (playerDoString.LastIndexOf ("=") + 1);
						valueDoName = playerDoString.Substring (0, playerDoString.IndexOf ("="));
						valueDoName = valueDoName.Replace (" ", string.Empty);

						if (valueDoName == "doorOpen") {
                            if (playerDoValue.Contains(";"))
                            {



                                playerDoValue = playerDoValue.Replace(";", string.Empty);
                                playerDoValue = playerDoValue.Replace(" ", string.Empty);

                                if (playerDoValue == "true" || playerDoValue == "false")
                                {
                                    triggerButtons = Convert.ToBoolean(playerDoValue);
                                    //triggerBlueButton = Convert.ToBoolean (playerDoValue);

                                    if (playerDoValue == "true")
                                    {
                                        //	buttonAnimator.SetInteger ("AniState", 1);
                                        error.text = "Buttons active.";
                                    }

                                    if (playerDoValue == "false")
                                    {
                                        //	buttonAnimator.SetInteger ("AniState", 0);
                                        error.text = "Buttons inactive.";
                                    }

                                }
                                else
                                {
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
				} 


			} else {
				error.text = "Error: For this level, || is expected.";
			}
		} else {
			error.text = "Error: 'if' expected.";
		}
	}
		
}
	



