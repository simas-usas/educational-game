using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.Linq;

public class ProcessInformation_Level07 : MonoBehaviour {

	public Text playerIfText; 
	public Text playerDoText;

	public string valueForName;
	public string forVariable;

	public string valueDoName;

	//for the tile
	public int playerForValue;

	public Text error;
	public bool triggerTile = false;
    public bool triggerTilePlat = false;

    public int triggerSpeed;
	//public bool triggerBlueButton;


	// Update is called once per frame
	public void ButtonPressed ()
	{
		string playerIfString = playerIfText.text.ToString ();
		playerIfString = playerIfString.Replace (" ", string.Empty);
		string lastChar = playerIfString [playerIfString.Length - 1].ToString ();

		if (playerIfString.Contains ("for(") && (lastChar == ")")) {

			playerIfString = playerIfString.Replace ("for(", string.Empty);
			playerIfString = playerIfString.Replace (")", string.Empty);
			playerIfString = playerIfString.Replace (" ", string.Empty);

            if (playerIfString.Contains(";"))
            {

                string[] playerArg = playerIfString.Split(';');

                int argAmount = playerIfString.Split(';').Length - 1;

                if (argAmount > 2) { error.text = "Error: Too many cycle conditions."; }




                // first condition
                bool firstLine = false;
                playerArg[0] = playerArg[0].Replace(" ", string.Empty);

                string lastFirstChar = playerArg[0].Substring(playerArg[0].LastIndexOf("=") + 1);


                if (playerArg[0].Contains("int") && (lastFirstChar == "0"))
                {

                    playerArg[0] = playerArg[0].Replace("int", string.Empty);
                    playerArg[0] = playerArg[0].Replace("=0", string.Empty);
                    playerArg[0] = playerArg[0].Replace(" ", string.Empty);

                    if (playerArg[0] != string.Empty)
                    {
                        forVariable = playerArg[0];
                    }
                    else
                    {
                        error.text = "Error: First cycle condition is missing variable name.";
                    }

                    firstLine = true;
                }
                else
                {
                    error.text = "Error: Incorrect first cycle conditions.";
                }



                //second condition
                bool secondLine = false;

                if (playerArg[1].Contains('<'))
                {
                    string playerForString = playerArg[1].Substring(playerArg[1].LastIndexOf("<") + 1);
                    valueForName = playerArg[1].Substring(0, playerArg[1].IndexOf("<"));
                    valueForName = valueForName.Replace(" ", string.Empty);

                    if (valueForName == forVariable)
                    {
                        string playerForStringEx = playerForString.Replace(" ", string.Empty);
                        int triggerPlat = Convert.ToInt32(playerForStringEx);

                        if (triggerPlat >= 1 && triggerPlat <= 4)
                        {
                            playerForValue = Convert.ToInt32(playerForStringEx);
                            secondLine = true;
                        }
                        else
                        {
                            error.text = "Error: Value must be between 1 and 4.";
                            secondLine = false;
                        }


                    }
                    else
                    {
                        error.text = "Error: Second cycle condition value name must be the same.";
                    }
                }
                else
                {
                    error.text = "Error: Second cycle condition must contain = .";
                }


                //third condition
                bool thirdLine = false;
                playerArg[2] = playerArg[2].Replace(" ", string.Empty);
                if (playerArg[2] == (forVariable + "++"))
                {
                    thirdLine = true;
                }

                if (firstLine && secondLine && thirdLine)
                {




                    string oldPlayerDoString = playerDoText.text.ToString();
                    string playerLines = oldPlayerDoString.Replace("\r", "").Replace("\n", "");

                    if (playerLines.Contains(";"))
                    {

                        string[] playerDoString = playerLines.Split(';');
                        int lineAmount = Regex.Matches(playerLines, ";").Count - 1;

                        for (int i = 0; i <= lineAmount; i++)
                        {

                            if (playerDoString[i].Contains("="))
                            {
                                string playerValue = playerDoString[i].Substring(playerDoString[i].LastIndexOf("=") + 1);
                                valueDoName = playerDoString[i].Substring(0, playerDoString[i].IndexOf("="));
                                valueDoName = valueDoName.Replace(" ", string.Empty);

                                if (valueDoName == "platformSpeed")
                                {
                                    playerValue = playerValue.Replace(" ", string.Empty);
                                    playerValue = playerValue.Replace(";", string.Empty);
                                    if (Int32.TryParse(playerValue, out triggerSpeed))
                                    {
                                        Int32.TryParse(playerValue, out triggerSpeed);

                                        if (triggerSpeed >= 1 && triggerSpeed <= 5)
                                        {
                                            triggerTile = true;
                                            error.text = "Platform moving.";
                                        }
                                        else
                                        {
                                            triggerTile = false;
                                            error.text = "Error: Value must be between 1 and 5.";
                                        }

                                    }
                                    else
                                    {
                                        error.text = "Error: Not a correct value.";
                                    }
                                }

                                if (valueDoName == "platformDistance")
                                {
                                    playerValue = playerValue.Replace(" ", string.Empty);
                                    playerValue = playerValue.Replace(";", string.Empty);
                                    if (playerValue == forVariable)
                                    {
                                        triggerTilePlat = true;
                                        error.text = "Platform distance set.";
                                    }
                                    else
                                    {
                                        triggerTilePlat = false;
                                        error.text = "Error: Platfrom distance must match cycle variable.";
                                    }

                                }
                                else
                                {
                                    error.text = "Error: Not a correct value.";
                                }
                            }





                        }

                    }
                    else
                    {
                        error.text = "Error: ; expected.";
                    }




                }
                else
                {
                    error.text = "Error: Wrong for conditions.";
                }
            }
            else
            {
                error.text = "Error: ; expected in for statement.";
            }



        } else {
			error.text = "Error: 'for' expected.";
		}
	}
		
}
	



