using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;      // Name of the speaker
    [TextArea(1, 3)]
    public string dialogueText;       // Text to display
    public Sprite characterSprite;    // Image of the speaker
}
