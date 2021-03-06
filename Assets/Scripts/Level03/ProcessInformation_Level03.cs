using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class ProcessInformation_Level03 : MonoBehaviour {

	public Text playerText;

	public bool boxHeight_00;
	public int playerNumberY_00;

	public bool boxHeight_01;
	public int playerNumberY_01;

	public bool boxHeight_02;
	public int playerNumberY_02;

	public bool boxHeight_03;
	public int playerNumberY_03;

    public string valueName;
    public Text error;

    // Use this for initialization
    void Start () {

	}

	void Update(){

	}

	// Update is called once per frame
	public void ButtonPressed () {
		string oldString = playerText.text.ToString ();
        string playerString = oldString.Replace("\r", "").Replace("\n", "");


        if (playerString.Contains(";"))
        {
            string[] playerLines = playerString.Split(';');
            int lineAmount = Regex.Matches(playerString, ";").Count - 1;

                for (int i = 0; i <= lineAmount; i++)
                {

                    if (playerLines[i].Contains("="))
                    {
                        string playerValue = playerLines[i].Substring(playerLines[i].LastIndexOf("=") + 1);
                        valueName = playerLines[i].Substring(0, playerLines[i].IndexOf("="));
                        valueName = valueName.Replace(" ", string.Empty);

						if (valueName == "boxHeight[0]")
						{
							playerValue = playerValue.Replace(" ", string.Empty);
							if (Int32.TryParse(playerValue, out playerNumberY_00))
							{
                                Int32.TryParse(playerValue, out playerNumberY_00);
								
								if (playerNumberY_00 >= 1 && playerNumberY_00 <= 2) { 

									boxHeight_00 = true;
									error.text = "Box size changed.";
								}
								else 
								{ 
									boxHeight_00 = false;
									error.text = "Error: Value must be between 1 and 2.";
								}

							}
							else
							{
								error.text = "Error: Not a correct value.";
							}
						}

					else if (valueName == "boxHeight[1]")
					{
						playerValue = playerValue.Replace(" ", string.Empty);
						if (Int32.TryParse(playerValue, out playerNumberY_01))
						{
                            Int32.TryParse(playerValue, out playerNumberY_01);

							if (playerNumberY_01 >= 1 && playerNumberY_01 <= 2) { 

								boxHeight_01 = true;
								error.text = "Box size changed.";
							}
							else 
							{ 
								boxHeight_01 = false;
								error.text = "Error: Value must be between 1 and 2.";
							}

						}
						else
						{
							error.text = "Error: Not a correct value.";
						}
					}




					else if (valueName == "boxHeight[2]")
					{
						playerValue = playerValue.Replace(" ", string.Empty);
						if (Int32.TryParse(playerValue, out playerNumberY_02))
						{
                            Int32.TryParse(playerValue, out playerNumberY_02);

							if (playerNumberY_02 >= 1 && playerNumberY_02 <= 2) { 

								boxHeight_02 = true;
								error.text = "Box size changed.";
							}
							else 
							{ 
								boxHeight_02 = false;
								error.text = "Error: Value must be between 1 and 2.";
							}

						}
						else
						{
							error.text = "Error: Not a correct value.";
						}
					}


					else if (valueName == "boxHeight[3]")
					{
						playerValue = playerValue.Replace(" ", string.Empty);
						if (Int32.TryParse(playerValue, out playerNumberY_03))
						{
                            Int32.TryParse(playerValue, out playerNumberY_03);

							if (playerNumberY_03 >= 1 && playerNumberY_03 <= 2) { 

								boxHeight_03 = true;
								error.text = "Box size changed.";
							}
							else 
							{ 
								boxHeight_03 = false;
								error.text = "Error: Value must be between 1 and 2.";
							}

						}
						else
						{
							error.text = "Error: Not a correct value.";
						}
					}




                        else { error.text = "Error: Not a correct variable."; } 
                        
                    }  
                    else { error.text = "Error: = expected."; }
                }

        }
        else { error.text = "Error: ; expected."; }
		   

    }
}
