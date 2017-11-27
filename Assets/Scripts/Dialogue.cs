using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour {

    private Text textComponent;

    public string[] DialogueStrings;

    public float secondsBetween = 0.05f;
    public float CharacterRateMultiplier = 0.05f;

    public KeyCode DialogueInput = KeyCode.Space;

    private bool isStringBeingRevealed = false;
    private bool isDialoguePlaying = false;
    private bool isEndOfDialogue = false;

    public GameObject dialPanel;

    public GameObject player;
    public GameObject gameManager;



    // Use this for initialization
    void Start() {


        textComponent = GetComponent<Text>();
        textComponent.text = "";

    }

    void Update()
    {


        if (!isDialoguePlaying)
            {
                isDialoguePlaying = true;

                StartCoroutine(StartDialogue());
        }



        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerMain>().enabled = false;
        gameManager.GetComponent<PauseMenu>().enabled = false;

        if (isEndOfDialogue)
        {
            dialPanel.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<PlayerMain>().enabled = true;
            gameManager.GetComponent<PauseMenu>().enabled = true;

        }
    }
        
    
    private IEnumerator StartDialogue()
    {



        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength || !isStringBeingRevealed)
        {
            if (!isStringBeingRevealed)
            {
                isStringBeingRevealed = true;
                StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength )
                {
                    isEndOfDialogue = true;
                }
            }

            yield return 0;
        }

        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }

            yield return 0;
        }

        isEndOfDialogue = false;
        isDialoguePlaying = false;
    }



    private IEnumerator DisplayString(string stringToDisplay) {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;



        textComponent.text = "";

        while (currentCharacterIndex < stringLength) {
            textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(secondsBetween * CharacterRateMultiplier);
                }
                else
                {
                    yield return new WaitForSeconds(secondsBetween);
                }

                
            }
            else
            {
                break;
            }            
        }


        while(true){
            if (Input.GetKeyDown(DialogueInput)) {
                break;
            }

            yield return 0;
        }
        

        isStringBeingRevealed = false;
        textComponent.text = "";


    }
    
}
