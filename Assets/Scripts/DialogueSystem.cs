using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialgoue System", menuName = "DialogueScript/Dialogue System")]
public class DialogueSystem : ScriptableObject
{
    public List<Dialogue> dialogues;
}
