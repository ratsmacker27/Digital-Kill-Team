using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public LayerMask ground;
    public LayerMask terrain;
    public LayerMask engagementRange;
    Camera cam; // Camera variable
    public bool movementMode = false; // Movement Switch
    public bool dashMode = false; // Dash Switch
    public bool chargeMode = false; // Charge Switch
    public TMP_Text movementText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; // Initialises the camera variable as the main camera
    }
    public void ToggleMovementMode()
    {
        if (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getMovingUsed() == false)
        {
            movementMode = !movementMode; // Toggles Movement Mode on and off
            Debug.Log("Movement mode=" + movementMode.ToString()); // Writes a message in the console for debugging
        }
    }
    public void ToggleDashMode()
    {
        if (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getDashingUsed() == false)
        { 
        dashMode = !dashMode; // Toggles Dash Mode on and off
        Debug.Log("Dash mode=" + dashMode.ToString()); // Writes a message in the console for debugging
        }
    }
    public void ToggleChargeMode()
    {
        if ((OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getChargingUsed() == false) && (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getDashingUsed() == false) && (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getMovingUsed() == false))
        { 
        chargeMode = !chargeMode; // Toggles Charge Mode on and off
        Debug.Log("Charge mode=" + chargeMode.ToString()); // Writes a message in the console for debugging
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movementMode) // If the movement mode is on
        {

            if (Input.GetMouseButtonDown(0)) // If the user clicks
            {
                RaycastHit hit; // Make a raycast
                Ray ray = cam.ScreenPointToRay(Input.mousePosition); // The raycast is where the user clicked

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) // If the raycast hit something
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrain))
                    {
                        movementMode = false;
                    }
                    // Calculate the distance from the original position to the new position
                    float distance = Vector2.Distance(new Vector2(OperativeSelected.Instance.operativeSelected[0].transform.position.x, OperativeSelected.Instance.operativeSelected[0].transform.position.y), new Vector2(hit.point.x, hit.point.y));
                    movementText.text = ("Distance: " + distance).ToString(); // Writes a message with the distance
                    // If the distance is less or equal than the movement characteristic of the operative
                    if (distance <= OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetMovement())
                    {
                        Move(hit.point); // Move the operative to the new position
                    }
                    else
                    {
                        movementMode = false; //Turns off movement mode if the distance is too great
                    }
                }

            }
        }
        if (dashMode)
        {
            if (Input.GetMouseButtonDown(0)) // If the user clicks
            {
                RaycastHit hit; // Make a raycast
                Ray ray = cam.ScreenPointToRay(Input.mousePosition); // The raycast is where the user clicked

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) // If the raycast hit something
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrain))
                    {
                        dashMode = false;
                    }
                    float distance = Vector2.Distance(new Vector2(OperativeSelected.Instance.operativeSelected[0].transform.position.x, OperativeSelected.Instance.operativeSelected[0].transform.position.y), new Vector2(hit.point.x, hit.point.y)); // Calculate the distance from the original position to the new position
                    movementText.text = ("Distance: " + distance).ToString();// Writes a message with the distance
                    if (distance <= 4) // If the distance is less or equal than the dash (static)
                    {
                        
                        Dash(hit.point); // Move the operative to the new position
                    }
                    else
                    {
                        dashMode = false; // Turn off dash mode if the distance is too great
                    }
                }
            }
        }
        if (chargeMode)
        {
            if (Input.GetMouseButtonDown(0)) // If the user clicks
            {
                RaycastHit hit; // Make a raycast
                Ray ray = cam.ScreenPointToRay(Input.mousePosition); // The raycast is where the user clicked

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, engagementRange)) // If the raycast hit something
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrain))
                    {
                        chargeMode = false;
                    }
                    float distance = Vector2.Distance(new Vector2(OperativeSelected.Instance.operativeSelected[0].transform.position.x, OperativeSelected.Instance.operativeSelected[0].transform.position.y), new Vector2(hit.point.x, hit.point.y)); // Calculate the distance from the original position to the new position
                    movementText.text = ("Distance: " + distance).ToString();// Writes a message with the distance
                    if ((distance <= (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetMovement() + 2))) // && (OperativeSelected.Instance.operativeSelected[0]))
                    {// If the distance is less or equal than the movement characteristic of the operative plus 2 units AND the charge ends near 1 unit within an enemy
                        Charge(hit.point); // Move the operative to the new position
                    }
                    else
                    {
                        chargeMode = false; // Turn off charge mode if the distance is too great
                    }
                }
            }
        }
    }

    void Move(Vector2 Location) 
    {
        OperativeSelected.Instance.operativeSelected[0].transform.position = Location; //Location of the operative
        movementMode = false; // Disables movement mode
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().SetAPL(1);
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().setMovingUsed();
    }
    void Dash(Vector2 Location)
    {
        OperativeSelected.Instance.operativeSelected[0].transform.position = Location; //Location of the operative
        dashMode = false; // Disables dash mode
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().SetAPL(1);
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().setDashingUsed();
    }
    void Charge(Vector2 Location)
    {
        OperativeSelected.Instance.operativeSelected[0].transform.position = Location; //Location of the operative
        chargeMode = false; // Disables charge mode
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().SetAPL(1);
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().setChargingUsed();
    }
}
