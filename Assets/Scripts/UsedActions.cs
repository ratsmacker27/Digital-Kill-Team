using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsedActions : MonoBehaviour
{
    public bool used = false;
    public GameObject Actions;
    public LayerMask UI;
    Camera cam;
    Button button;
    void Start()
    {
        cam = Camera.main; // Initialises the camera variable as the main camera
        Button button = gameObject.GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // If the user clicks
        {
            RaycastHit hit; // Make a raycast
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // The raycast is where the user clicked
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, UI)) // If the raycast hit something
            {
                used = true;

                if (used == true)
                {
                    button.enabled = !button.enabled;
                }
            }
        }
    }
}
