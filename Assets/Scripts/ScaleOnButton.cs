using UnityEngine;
using UnityEngine.InputSystem;

public class ScaleOnButton : MonoBehaviour
{
    public float scale = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // in interaction the handheld object gets destroyed, this function also runs on the objects around where it will scale up the objects if handheld object tag is 'grow'

        if (Keyboard.current.fKey.isPressed)
        {
            scale = 0.01f;
            // grab object scale; kinda want to try making player small XD
            transform.localScale = transform.localScale + new Vector3(scale, scale, scale);
            
        }
    }
}
