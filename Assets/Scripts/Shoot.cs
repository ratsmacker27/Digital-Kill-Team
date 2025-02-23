using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Camera cam;
    //public GameObject unit;
    public bool shootingMode = false; // Shooting mode activates when button is pressed
    public int normalHits; // Makes a list for success normal hit
    public int criticalHits; // Makes a list for success critical hits
    public int randomInt; // Dice for hitting and wounding
    public int normalSave; // Save against normal hits
    public int criticalSave; // Save against critical hits
    public LayerMask clickable; // Only the layer with clickable areas
    public LayerMask Terrain; // Layer for terrain
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; // Initialises the camera as the main camera
    }
    public void ToggleShootingMode() 
    {
        shootingMode = !shootingMode; // Changes the shooting mode 
    }
    // Update is called once per frame
    void Update()
    {
        if ((shootingMode == true) && (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getShootingUsed() == false) && (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getEngagedOrder() == true) && (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<Weapon>().GetRangedWeapon() == true))
        { // If in shooting mode and operative has an engage order and action hasn't been used with the operative and the operative's weapon is ranged

            if (Input.GetMouseButtonDown(0)) //User presses down the left click
            {
                RaycastHit hit; //Initialises a raycast as hit
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))  // Clicked on a clickable item (Operative)
                {
                    if (hit.transform.gameObject.GetComponent<Operative>().GetTeam() != OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetTeam())
                    //Hit operative isn't in the same team as operative selected
                    {
                        Debug.Log(hit.transform.gameObject.ToString()); // Debug Line to show hit operative
                        Debug.Log("Wounds: " + hit.transform.gameObject.GetComponent<Operative>().GetWounds().ToString()); // Debug Line to show wounds of hit operative
                        Vector3 fromPosition = OperativeSelected.Instance.operativeSelected[0].transform.position; // From the Operative that is shooting
                        Vector3 toPosition = hit.transform.position; // To the Operative hit
                        if (Physics.Linecast(fromPosition, toPosition, out RaycastHit hitInfo, Terrain)) // If there is a terrain inbetween the operative shooting and the operative hit
                        {
                            if (Mathf.Abs((fromPosition.magnitude - toPosition.magnitude)-hitInfo.distance) <= 1) //Cover Rule, hitInfo.distance is the distance from the Terrain Piece
                            {
                                Debug.Log("Blocked");
                                normalHits -= 1; 
                            }
                        }
                        for (var i = 0; i < OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<Weapon>().GetAttacks(); i++) // For loop for each attack of the weapon
                        {

                            int randomInt = Random.Range(1, 7); // Rolls a dice
                            Debug.Log(randomInt.ToString()); //Line for debugging rolls
                            if (randomInt >= OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<Weapon>().GetAttackRoll() && randomInt < 6) // If the dice is more or equal to Attack Roll but less than six
                            {
                                normalHits += 1; // Add to the normal damage count
                            }
                            if (randomInt == 6) // If the dice is equal to six
                            {
                                criticalHits += 1; // Add to the critical damage count
                            }
                        }
                        for (var x = 0; x < hit.transform.gameObject.GetComponent<Operative>().GetDefenceDice(); x++) // For how many defence dice the enemy operative has
                        {
                            int randomInt = Random.Range(1, 7); //Rolls a dice
                            Debug.Log(randomInt.ToString()); // Line for debugging rolls
                            if (randomInt >= hit.transform.gameObject.GetComponent<Operative>().GetSave() && randomInt < 6) // If the dice number is more or equal to the save of the enemy operative
                            {
                                normalSave += 1; // Add to the normal save count
                            }
                            if (randomInt == 6) // If the dice is equal to six
                            {
                                criticalSave += 1; // Add to the critical save count
                            }
                        }
                        for (var x = 0; x < criticalHits; x++) // For how many critical hits, deal damage equal to the value of the critical hits
                        {
                            if (criticalSave > 0) // If there are critical saves
                            {
                                criticalSave -= 1; //Reduce 1 critical save
                                //criticalHits -= 1; //Block 1 critical hit
                            }
                            else
                            {
                                if (normalSave >= 2 && criticalSave <= 0) // If there are more than 2 normal saves
                                {
                                    normalSave -= 2; //Reduce 2 normal saves
                                                     //criticalHits -= 1; //Block 1 critical hit
                                }
                                else //No saves
                                {
                                    //Deal damage to the operative
                                    hit.transform.gameObject.GetComponent<Operative>().SetWounds(OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<Weapon>().GetCriticalDamage());
                                }

                            }

                        }
                        for (var x = 0; x < normalHits; x++) // For how many normal hits, deal damage equal to the value of the normal hits
                        {
                            if (normalSave > 0) // If there are normal saves
                            {
                                normalSave -= 1; //Reduce 1 normal save
                                //normalHits -= 1; //Block 1 normal hit
                            }
                            else
                            {
                                if (criticalSave > 0 && normalSave <= 0) // If there are critical saves
                                {
                                    criticalSave -= 1; //Reduce 1 critical save
                                                       //normalHits -= 1; //Block 1 normal hit
                                }
                                else
                                {
                                    //Deal damage to the operative
                                    hit.transform.gameObject.GetComponent<Operative>().SetWounds(OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<Weapon>().GetNormalDamage());
                                }
                            }
                        }
                        Debug.Log("Wounds: " + hit.transform.gameObject.GetComponent<Operative>().GetWounds().ToString()); // Debug Line to show wounds of hit operative after the attack
                        shootingMode = false; //Disables shooting mode
                        criticalHits = 0; // Resets critical hits count
                        normalHits = 0; // Resets normal hits count
                        normalSave = 0; //Resets normal save count
                        criticalSave = 0; //Resets critical save count
                        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().SetAPL(1); //Reduce user operative APL by 1
                        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().setShootingUsed(); //Makes it so the actions can't be used again
                    }
                    else
                    {
                        shootingMode = false;//Disables shooting mode
                    }
                }
            }
        }
    }
}