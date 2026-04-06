using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class VRPlayerInteraction : MonoBehaviour
{
    // Door and scene switching
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable doorInteractable;
    public ScreenFade screenFade;
    public AudioClip nextScene;

    // Rabbit hint
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable rabbitInteractable;
    public DialogueNPC3D npcDialogue;

    // Rose
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable[] roseInteractable;
    public AudioClip paintSound;

    private AudioSource ac;

    bool doorTriggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ac = GetComponent<AudioSource>();

        doorInteractable.selectEntered.AddListener(OnDoorPoked);
        rabbitInteractable.selectEntered.AddListener(OnRabbitPoked);

        // Roses
        foreach (UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable rose in roseInteractable)
        {
            rose.selectEntered.AddListener(OnRosePoked);
        }
    }

    // Update is called once per frame
    void OnDoorPoked(SelectEnterEventArgs args)
    {
        if (doorTriggered)
        {
            return;
        }
        
        Debug.Log("Loading next room...");
        doorTriggered = true;
        StartCoroutine(LoadNextScene());
    }

    void OnRosePoked(SelectEnterEventArgs args)
    {
        ac.PlayOneShot(paintSound);
        Rose rose = args.interactableObject.transform.GetComponent<Rose>();
        rose.Paint();
    }

    IEnumerator LoadNextScene()
    {
        ac.PlayOneShot(nextScene);
        
        // Calls the FadeToBlack IEnumerator from the ScreenFade script 
        yield return StartCoroutine(screenFade.FadeToBlack());

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnRabbitPoked(SelectEnterEventArgs args)
    {
        npcDialogue.TryStartDialogue();
        Debug.Log("Rabbit poked");
    }
}
