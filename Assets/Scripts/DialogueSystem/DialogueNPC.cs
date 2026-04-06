using UnityEngine;

public class DialogueNPC3D : MonoBehaviour
{
    [Header("Dialogue")]
    public DialogueLine[] dialogueLines;  

    [Header("Interaction")]
    public float interactRange = 5f;      

    private bool dialogueStarted = false;

    void Update()
    {
   
        if (dialogueStarted && DialogueManager.instance.dialogueFinished)
        {
            dialogueStarted = false;
        }

   
        if (!dialogueStarted && PlayerInRange() && Input.GetKeyDown(KeyCode.E))
        {
            TryStartDialogue();
        }
    }



    bool PlayerInRange()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return false;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= interactRange;
    }

    
    public void TryStartDialogue()
    {
        if (dialogueStarted || dialogueLines.Length == 0) return;

        DialogueManager.instance.StartDialogue(dialogueLines);
        dialogueStarted = true;
    }
}
