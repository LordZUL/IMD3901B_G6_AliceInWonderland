using UnityEngine;

public class catVisibility : MonoBehaviour
{
    //public GameObject catObject;
    public void ShowCat()
    {
        gameObject.SetActive(true);
    }

    public void HideCat()
    {
        gameObject.SetActive(false);
    }
}
