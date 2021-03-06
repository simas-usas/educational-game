using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class ProcessInformation_Level02 : MonoBehaviour {

	public Text playerText;

	public bool xAxisBox;
    public double playerNumberX;

    public bool yAxisBox;
    public double playerNumberY;

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
        Debug.Log(playerString);

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

                        if (valueName == "boxSize.x")
                        {
                            playerValue = playerValue.Replace(" ", string.Empty);
                            if (double.TryParse(playerValue, out playerNumberX) )
                            {
                                double.TryParse(playerValue, out playerNumberX);

								if (playerNumberX >= 1 && playerNumberX <= 5) {  
                        			xAxisBox = true;
									error.text = "Box size changed.";
								} 
								else 
								{ 
									xAxisBox = false;
									error.text = "Error: Value must be between 1 and 5.";
								}

                            }
                            else
                            {
                                error.text = "Error: Not a correct value.";
                            }
                        }

                        else if (valueName == "boxSize.y")
                        {
                            playerValue = playerValue.Replace(" ", string.Empty);
                            if (double.TryParse(playerValue, out playerNumberY))
                            {
                                double.TryParse(playerValue, out playerNumberY);

								if (playerNumberY >= 1 && playerNumberY <= 5) {
									yAxisBox = true;
									error.text = "Box size changed.";
								}
								else 
								{ 
									yAxisBox = false;
									error.text = "Error: Value must be between 1 and 5.";
								}

						
							}
                            else
                            {
                                error.text = "Error: Not a correct value. Must be between 1 and 5.";
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
