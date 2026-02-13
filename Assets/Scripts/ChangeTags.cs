using UnityEngine;
using UnityEngine.UI;

public class ChangeTags : MonoBehaviour
{
    public string newTag;
    //public Text TagText;
    public ScaleOnButton scaleOnButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.tag = "NotInteractable";
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleOnButton.status == 2)
        {
            gameObject.tag = newTag;
            //TagText.text = newTag;
        }
        else
        {
            gameObject.tag = "NotInteractable";
        }
    }
}
