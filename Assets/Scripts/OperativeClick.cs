using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperativeClick : MonoBehaviour
{
    private Camera cam; // Camera variable

    public LayerMask clickable; // Only the layer with clickable areas
    public LayerMask ground; // Only the layer with the ground
    public TeamSelection Turns;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; ;// Initialises the camera
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // If the mouse is clicked
        {
            if (Turns.GetTeam1() == true) // If it is Team 1's turn
            {
                RaycastHit hit; // Make a raycast
                Ray ray = cam.ScreenPointToRay(Input.mousePosition); // Put the raycast at the mouse position

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable)) // If it clicks a clickable object
                {
                    if (hit.transform.gameObject.GetComponent<Operative>().GetActive() == false && hit.transform.gameObject.GetComponent<Operative>().GetTeam() == 0) // If the operative hasn't been activated and is in Team 1
                    {
                        OperativeSelected.Instance.ClickSelect(hit.collider.gameObject); // Puts the Operative in the selected operative list
                    }
                }
            }
            if (Turns.GetTeam2() == true) // If it is Team 2's turn
            {
                RaycastHit hit; // Make a raycast
                Ray ray = cam.ScreenPointToRay(Input.mousePosition); // Put the raycast at the mouse position

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable)) // If it clicks a clickable object
                {
                    if (hit.transform.gameObject.GetComponent<Operative>().GetActive() == false && hit.transform.gameObject.GetComponent<Operative>().GetTeam() == 1) // If the operative hasn't been activated and is in Team 2
                    {
                        OperativeSelected.Instance.ClickSelect(hit.collider.gameObject); // Puts the Operative in the selected operative list
                    }
                }
            }
        }
    }
}
