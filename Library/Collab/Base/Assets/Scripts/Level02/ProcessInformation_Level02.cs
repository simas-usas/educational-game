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
                                xAxisBox = true;
                                error.text = "Box size changed.";
                            }
                            else
                            {
                                error.text = "Error: Not a correct value. Must be between 1 and 5.";
                            }
                        }

                        else if (valueName == "boxSize.y")
                        {
                            playerValue = playerValue.Replace(" ", string.Empty);
                            if (double.TryParse(playerValue, out playerNumberY))
                            {
                                double.TryParse(playerValue, out playerNumberY);
                                yAxisBox = true;
                                error.text = "Error: Box size changed.";
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



        //old code






        /*


        if (playerString.Contains ("=")) 
		{
			string playerValue = playerString.Substring (playerString.LastIndexOf ("=") + 1);
			valueName = playerString.Substring (0, playerString.IndexOf ("="));
			valueName = valueName.Replace (" ", string.Empty);

			if (valueName == "boxSize") {
				if (playerValue.Contains (";")) {
					playerValue = playerValue.Replace (";", string.Empty);
					//	}

					playerValue = playerValue.Replace (" ", string.Empty);


					//bool isNumeric = int.TryParse(playerValue, out playerNumber);
					if (double.TryParse (playerValue, out playerNumber)) {
						double.TryParse (playerValue, out playerNumber);
                        XAxisBox = true;
					} else 
					{ 
						Debug.Log("not an int");
					}
                
					
					if (playerValue == "true" || playerValue == "false") {
						triggerDoor = System.Convert.ToBoolean (playerValue);
					} else {
						Debug.Log ("not a correct value");
					}
					


				} else {
					Debug.Log ("Does not contain ; ");
				}
			} else 
			{
				Debug.Log ("wrong value name");
			}

		} else 
		{
			Debug.Log ("Does not contain = ");
		}

        */


    }
}
