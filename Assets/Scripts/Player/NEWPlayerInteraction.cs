using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class NEWPlayerInteraction : MonoBehaviour
{
    // Interactions: hold e for more control during puzzel solve. Press E to have it locked. WASD, jump, climb (stamina)
    // Player vaulting: https://www.youtube.com/watch?v=9k7iBucBV7s -> basically done
    // Player grab (press): inventory?? Not sure if going to apply it for beta.. we'll see
    // Hold: grab items with finer control; perfect for the first rabbit puzzel! https://www.youtube.com/watch?v=2IhzPTS4av4&t=361s
    // Jumping advanced: not doing it right now https://www.youtube.com/watch?v=h2r3_KjChf4

    //public Camera playerCamera;
    public Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    public Transform puzzleGrabPointTransform;
    public Transform inventoryGrabPointTransform;

    public CrosshairUI crosshairUIScript;
    public ScreenFade screenFade;

    // Audio
    public AudioClip nextScene;
    public AudioClip eatSound;
    private AudioSource ac;

    // to track if hands empty rn
    private ObjectGrabbable objectGrabbable;

    // to see what size is player -> small, average, giant
    public enum SizeState { Normal, Small, Big }
    public SizeState currentSize = SizeState.Normal;

    Spawner spawn;

    void Start()
    {
        // make heldobject defy gravityyy -> make object kinematic
        //heldObject.GetComponent<Rigidbody>().isKinematic = true;
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        //if (Input.GetKeyDown(KeyCode.E))
        {
            // if hands empty, grab object
            if (objectGrabbable == null)
            {
                float pickupDistance = 5f;
                if (currentSize == SizeState.Big)
                {
                    pickupDistance = 100f;
                }
                // raycast will hit everything infront of player camera within distance and not on playerLayer
                //if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))

                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance))
                {


                    //Debug.Log(raycastHit.transform);
                    // if object under ray has that script
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        //objectGrabbable.Grab(inventoryGrabPointTransform);
                        //crosshairUIScript.SetInteract(true);
                        if ((objectGrabbable.gameObject.tag == "Mushroom") || (objectGrabbable.gameObject.tag == "Carrot"))
                        {
                            objectGrabbable.Grab(inventoryGrabPointTransform);
                        }
                        else
                        {
                            objectGrabbable.Grab(puzzleGrabPointTransform);

                        }
                    }


                }

            }
            //currently holding something -> drop
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }

            /*if (heldObject == null)
            {
                PickUpObject(hit.collider.gameObject);
            }*/
        }

        // SCENE LOADING STUFF
        // If player is near door, then when they interact with it by pressing e it loads the next scene in the build profile
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit doorHit, 5f))
        {


            //  RABBIT HINT SYSTEM
            DialogueNPC3D npc = doorHit.collider.GetComponent<DialogueNPC3D>();

            if (npc != null)
            {
                crosshairUIScript.SetInteract(true, doorHit.collider.gameObject);

                if (Keyboard.current.hKey.wasPressedThisFrame)
                {
                    npc.TryStartDialogue();
                }

                return; // end
            }
            
            // DOOR SCENE SWITCH
            // Show UI
            crosshairUIScript.SetInteract(true, doorHit.collider.gameObject);

            if (doorHit.collider.CompareTag("Door"))
            {
                //changed so size must be small to get through
                if (Keyboard.current.eKey.wasPressedThisFrame && currentSize == SizeState.Normal)
                {
                    Debug.Log("Loading next room...");
                    StartCoroutine(LoadNextScene());
                     // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                 }
            }
            }
            else
            {
                // Hide UI
                crosshairUIScript.SetInteract(false, null);
            }

        // if Q is pressed when currently holding something -> eat object
        // need to check if object is mushroom or carrot
        if ((objectGrabbable.gameObject.tag == "Mushroom") || (objectGrabbable.gameObject.tag == "Carrot"))
        {
            if (Keyboard.current.qKey.wasPressedThisFrame && objectGrabbable != null)
            {
                //destoy object holding -> consume. If object tag == small, etc
                // if you ate the mushrooom -> object around you turn small
                if (objectGrabbable.gameObject.tag == "Mushroom")
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
                else if (objectGrabbable.gameObject.tag == "Carrot")
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
                objectGrabbable.OnConsumed();

                // Play audio clip
                ac.PlayOneShot(eatSound);

                Destroy(objectGrabbable.gameObject);
                
                objectGrabbable = null;
            }
        }
            
        //crosshairUIScript.SetInteract(false);
    }

    IEnumerator LoadNextScene()
    {
        ac.PlayOneShot(nextScene);
        
        // Calls the FadeToBlack IEnumerator from the ScreenFade script 
        yield return StartCoroutine(screenFade.FadeToBlack());

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
