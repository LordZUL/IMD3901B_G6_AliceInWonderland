using UnityEngine;
using UnityEngine.UI;
//using static Text;

public class ChangeTags : MonoBehaviour
{
    public ObjectGrabbable objectGrabbable;
    public NEWPlayerInteraction player;
    public string newTag;
    public Text TagText;
    public ScaleOnButton scaleOnButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.tag = "NotInteractable";
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.currentSize == NEWPlayerInteraction.SizeState.Big) && (gameObject.tag == "NotInteractable"))
        {
            //gameObject.tag = "PickUp";
            objectGrabbable.enabled = true;

        }
        else
        {
            //gameObject.tag = "NotInteractable";
            objectGrabbable.enabled = false;
        }
    }
}
