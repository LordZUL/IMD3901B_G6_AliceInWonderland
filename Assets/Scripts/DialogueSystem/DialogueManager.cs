using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class DialogueManager : MonoBehaviour
{
    // SINGLETON
    public static DialogueManager instance;

    [Header("Linked Components")]
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI textBox;
    public Image speakerImage;
    public GameObject dialogueGameObject;

    [Header("Text Configuration")]
    public float typingSpeed = 0.05f;

    [Header("Dialogue Status")]
    public bool isTyping = false;
    public bool dialogueFinished = true;

    [Header("Dialogue")]
    public DialogueLine[] dialogueLines;

    private int currentIndex = 0;
    private Coroutine typingCoroutine;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        dialogueGameObject.SetActive(false);
    }

    void Update()
    {
        if (dialogueGameObject.activeSelf && Keyboard.current.eKey.wasPressedThisFrame)
        {
            NextLine();
        }
    }
    public void StartDialogue(DialogueLine[] lines)
    {
        dialogueLines = lines;           // assign the NPC's dialogue
        dialogueGameObject.SetActive(true);
        dialogueFinished = false;
        currentIndex = 0;
        ShowLine();
    }


    void ShowLine()
    {
        DialogueLine line = dialogueLines[currentIndex];

        nameBox.text = line.characterName;
        speakerImage.sprite = line.characterSprite;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(line.dialogueText));
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        textBox.text = "";

        foreach (char letter in text)
        {
            textBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void NextLine()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            textBox.text = dialogueLines[currentIndex].dialogueText;
            isTyping = false;
            return;
        }

        currentIndex++;

        if (currentIndex >= dialogueLines.Length)
        {
            EndDialogue();
        }
        else
        {
            ShowLine();
        }
    }

    void EndDialogue()
    {
        dialogueGameObject.SetActive(false);
        dialogueFinished = true;

    }
}
