using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XREat : MonoBehaviour
{
    public XRDirectInteractor directInteractor;
    public InputActionReference triggerAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        triggerAction.action.Enable();
    }
    private void Update()
    {
        // If trigger pressed
        if (triggerAction.action.WasPressedThisFrame())
        {
            if (directInteractor.hasSelection)
            {
                var interactable = directInteractor.firstInteractableSelected;

                if (interactable != null)
                {
                    GameObject obj = interactable.transform.gameObject;

                    ObjectGrabbable grabbable = obj.GetComponent<ObjectGrabbable>();

                    if (grabbable != null)
                    {
                        Eat(grabbable);
                    }
                }
            }
        }
    }

    void Eat(ObjectGrabbable obj)
    {
        if (obj.CompareTag("Mushroom") || obj.CompareTag("Carrot"))
        {
            obj.OnConsumed(); // spawner respawn

            Destroy(obj.gameObject);
        }
    }
}
