using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public List<DialogueSystem> dialogueSystems;
    public TMP_Text dialogueBox;

    private int dialogueIndex = 0;
    private int systemIndex = 0;

    public void PlayDialogue()
    {
        int maxSystem = dialogueSystems.Count;
        int maxDialogue = dialogueSystems[systemIndex].dialogues.Count - 1;
        Debug.Log("Max System " + maxSystem);
        Debug.Log("Max Dialogue " + maxDialogue);
        Debug.Log("dialogueIndex " + dialogueIndex);
        Debug.Log("sys index " + systemIndex);
        if(systemIndex >= maxSystem || dialogueIndex >= maxDialogue) { return; }
        dialogueBox.text = dialogueSystems[systemIndex].dialogues[dialogueIndex].text;
    }
    public void PlayDialogueSystemByIndex(int index)
    {
        int maxSystem = dialogueSystems.Count;
        Debug.Log(maxSystem);
        if(index >= maxSystem) { return; }

        Debug.Log(index + " " + maxSystem);
        dialogueIndex = 0;
        systemIndex = index;
        dialogueBox.text = dialogueSystems[systemIndex].dialogues[dialogueIndex].text;
    }

    public void PlayNextDialogue()
    {
        Debug.Log("Next Dialogue");
        int indexMax = dialogueSystems[systemIndex].dialogues.Count - 1;
        if (dialogueIndex < indexMax)
        {
            Debug.Log("Next Dialogue Inside : " + dialogueIndex);
            Debug.Log("System Inde + " + systemIndex);
            dialogueIndex++;
            dialogueBox.text = dialogueSystems[systemIndex].dialogues[dialogueIndex].text;
        }
    }

    public void ChangeSystemByIndex(int index)
    {
        Debug.Log("Change System ");
        systemIndex = index;
        dialogueIndex = 0;
    }

    public void PlayDialogueSystem()
    {
        Debug.Log("Play DS");
        systemIndex = 0;
        dialogueIndex = 0;
        dialogueBox.text = dialogueSystems[systemIndex].dialogues[dialogueIndex].text;
    }
}
