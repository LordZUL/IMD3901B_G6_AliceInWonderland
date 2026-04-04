using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XREat : MonoBehaviour
{
    public XRDirectInteractor directInteractor;
    public NearFarInteractor nearFarInteractor;
    //public XRRayInteractor rayInteractor;
    //public InputActionReference triggerAction;
    public InputActionReference secondaryButton;
    // to see what size is player -> small, average, giant
    public enum SizeState { Normal, Small, Big }
    public SizeState currentSize = SizeState.Normal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        //triggerAction.action.Enable();
        secondaryButton.action.Enable();
    }
    private void Update()
    {
        // If trigger pressed
        if (secondaryButton.action.WasPressedThisFrame())
        {
            Debug.Log("TRIGGER PRESSED");
            if (nearFarInteractor.hasSelection)
            {
                Debug.Log("Has Selection: " + nearFarInteractor.hasSelection);

                var interactable = nearFarInteractor.firstInteractableSelected;
                Debug.Log("Interactable: " + interactable);


                if (interactable != null)
                {
                    //GameObject obj = interactable.transform.gameObject;


                    //ObjectGrabbable grabbable = obj.GetComponent<ObjectGrabbable>();

                    //ObjectGrabbable grabbable = interactable.transform.GetComponentInParent<ObjectGrabbable>();

                    ObjectGrabbable grabbable = null;

                    var mb = interactable as MonoBehaviour;
                    if (mb != null)
                    {
                        grabbable = mb.GetComponentInParent<ObjectGrabbable>();
                    }

                    if (grabbable != null)
                    {
                        Eat(grabbable);
                        Debug.Log("Its eating: " + grabbable);
                    }
                }
            }

            else if (directInteractor.hasSelection)
            {
                Debug.Log("Has Selection: " + directInteractor.hasSelection);

                var interactable = directInteractor.firstInteractableSelected;
                Debug.Log("Interactable: " + interactable);


                if (interactable != null)
                {
                    //GameObject obj = interactable.transform.gameObject;


                    //ObjectGrabbable grabbable = obj.GetComponent<ObjectGrabbable>();

                    //ObjectGrabbable grabbable = interactable.transform.GetComponentInParent<ObjectGrabbable>();

                    ObjectGrabbable grabbable = null;

                    GameObject obj = interactable.transform.gameObject;

                    ObjectGrabbable grabbable2 = obj.GetComponent<ObjectGrabbable>();

                    if (grabbable2 != null)
                    {
                        Eat(grabbable2);
                        Debug.Log("Its eating: " + grabbable2);
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
            // from playernewineractions
            if (obj.CompareTag("Mushroom"))
            {
                // if your size is small when u eat it, grow to normal
                if (currentSize == SizeState.Small)
                {
                    currentSize = SizeState.Normal;
                }
                //if normal or large
                else
                {
                    currentSize = SizeState.Big;
                }

            }
            else if (obj.CompareTag("Carrot"))
            {
                if (currentSize == SizeState.Big)
                {
                    currentSize = SizeState.Normal;
                }
                else
                {
                    currentSize = SizeState.Small;
                }
                //spawn.SpawnCarrot(objectGrabbable.gameObject);
            }

            // Play audio clip
            //ac.PlayOneShot(eatSound);

            //Destroy(objectGrabbable.gameObject);

            //objectGrabbable = null;

            Destroy(obj.gameObject);
        }
    }
}
