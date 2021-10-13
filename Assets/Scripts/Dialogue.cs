using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialgoue", menuName ="DialogueScript/Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea(3,3)]
    public string text;
}
