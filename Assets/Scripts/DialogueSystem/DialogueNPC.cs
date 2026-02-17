using UnityEngine;

public class DialogueNPC3D : MonoBehaviour
{
    [Header("Dialogue")]
    public DialogueLine[] dialogueLines;  // Assign NPC's dialogue in Inspector

    [Header("Interaction")]
    public float interactRange = 5f;      // Distance at which player can interact

    private bool dialogueStarted = false;

    void Update()
    {
        // Reset dialogueStarted when dialogue finishes
        if (dialogueStarted && DialogueManager.instance.dialogueFinished)
        {
            dialogueStarted = false;
        }

        // Optional: trigger dialogue by player pressing 'E' when in range
        if (!dialogueStarted && PlayerInRange() && Input.GetKeyDown(KeyCode.E))
        {
            TryStartDialogue();
        }
    }



    // Check if player is within interaction range
    bool PlayerInRange()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return false;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= interactRange;
    }

    // Start dialogue
    public void TryStartDialogue()
    {
        if (dialogueStarted || dialogueLines.Length == 0) return;

        DialogueManager.instance.StartDialogue(dialogueLines);
        dialogueStarted = true;
    }
}
