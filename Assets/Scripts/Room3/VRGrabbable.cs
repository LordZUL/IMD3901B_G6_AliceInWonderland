using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRGrabbable : MonoBehaviour
{
    private Rigidbody rb;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    // In VR when grabbed the paint can just despawns
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        gameObject.SetActive(false);
    }
}