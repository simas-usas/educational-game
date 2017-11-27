using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class ProcessInformation : MonoBehaviour {

	public Text playerText;

	public bool triggerDoor;
	public string valueName;
    public Text error;
    public Animator doorAnimator;

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

			if (valueName == "doorOpen") {
				if (playerValue.Contains (";") ) {
					playerValue = playerValue.Replace (";", string.Empty);
					

					playerValue = playerValue.Replace (" ", string.Empty);

					if (playerValue == "true" || playerValue == "false") {
						triggerDoor = System.Convert.ToBoolean (playerValue);

                        if (playerValue == "true")
                        {
                            doorAnimator.SetInteger("AnimState", 1);
                            error.text = "Door open.";
                        }

                        if (playerValue == "false")
                        {
                            doorAnimator.SetInteger("AnimState", 3);
                            error.text = "Door closed.";
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
