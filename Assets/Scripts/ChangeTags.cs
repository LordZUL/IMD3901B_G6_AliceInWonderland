using UnityEngine;
using UnityEngine.UI;
//using static Text;

public class ChangeTags : MonoBehaviour
{
    public Test test;
    public string newTag;
    public Text TagText;
    public ScaleOnButton scaleOnButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.tag = "NotInteractable";
    }

    // Update is called once per frame
    void Update()
    {
        if (test.currentSize == Test.SizeState.Big)
        {
            gameObject.tag = "PickUp";
        }
        else
        {
            gameObject.tag = "NotInteractable";
        }
    }
}
