using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ObjectHover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Renderer rend;
    public Color hoverColor = Color.white;
    private Color originalColor;

    void Start()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();

        originalColor = rend.material.GetColor("_Color");
    }

    public void OnHoverEnter()
    {
        //rend.material.SetColor("_Color", hoverColor);
        var mats = rend.materials;
        mats[1].SetColor("_Color", hoverColor);
    }

    public void OnHoverExit()
    {
        var mats = rend.materials;
        mats[1].SetColor("_Color", originalColor);
        //rend.material.SetColor("_Color", originalColor);
    }
}
