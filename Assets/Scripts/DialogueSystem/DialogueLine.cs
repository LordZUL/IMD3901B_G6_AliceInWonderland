using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;      
    [TextArea(1, 3)]
    public string dialogueText;      
    public Sprite characterSprite;    
}
