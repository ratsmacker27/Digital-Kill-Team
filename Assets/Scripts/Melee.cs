using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Melee : MonoBehaviour
{
    Camera cam;
    //public GameObject unit;
    public bool meleeMode = false; // Melee mode activates when button is pressed
    public int normalHits; // Makes a list for success normal hits
    public int criticalHits; // Makes a list for success critical hits
    private int randomInt; // Dice for hitting and wounding
    public int normalSave; // Save against normal hits
    public int criticalSave; // Save against critical hits
    public LayerMask clickable; // Only the layer with clickable areas

    public TMP_Text initialHealthText; // Text for the Initial Wounds textbox
    public TMP_Text hitsText; // Text for the Normal Hits and Critical Hits textbox
    public TMP_Text savesText; // Text for the Normal Saves and Critical Saves textbox
    public TMP_Text finalHealthText; // Text for the Final Wounds textbox
                                    
    void Start() // Start is called before the first frame update
    {
        cam = Camera.main; // Initialises the camera as the main camera
    }
    public void ToggleMeleeMode() 
    {
        meleeMode = !meleeMode; // Changes the melee mode 
    }
    public bool getMeleeMode() //Getter method
    {
        return meleeMode; // Returns boolean
    }
    // Update is called once per frame
    void Update()
    {
        if ((meleeMode) && (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getEngagedOrder() == true))
        { // If in melee mode and operative has an engage order and action hasn't been used with the operative
            if (Input.GetMouseButtonDown(0)) //User presses down the left click
            {
                RaycastHit hit; //Initialises a raycast as hit
                Ray ray = cam.ScreenPointToRay(Input.mousePosition); //On the mouses input position

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))  // Clicked on a clickable item (Operative)
                {
                    float distance = Vector2.Distance(new Vector2(OperativeSelected.Instance.operativeSelected[0].transform.position.x, OperativeSelected.Instance.operativeSelected[0].transform.position.y), new Vector2(hit.point.x, hit.point.y)); // Calculates the distance between the selected operative and the hit operative
                    if (distance <= 1) // If the distance is less than 1 unit
                    {
                        initialHealthText.text = ("Initial Wounds: " + hit.transform.gameObject.GetComponent<Operative>().GetWounds().ToString()); // Debug Line to show wounds of hit operative
                        for (var i = 0; i < OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetAttacks(); i++) // For loop for each attack of the weapon
                        {
                            int randomInt = Random.Range(1, 7); // Rolls a dice
                            Debug.Log(randomInt.ToString()); //Line for debugging rolls
                            if (randomInt >= OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetAttackRoll() && randomInt < 6) // If the dice is more or equal to Attack Roll but less than six
                            {
                                normalHits += 1; // Add to the normal damage list
                            }
                            if (randomInt == 6) // If the dice is equal to six
                            {
                                criticalHits += 1; // Add to the critical damage list
                            }

                        }
                        hitsText.text = ("Normal Hits and Critical Hits: " + normalHits + ", " + criticalHits); //Updates textbox with values
                        for (var x = 0; x < hit.transform.gameObject.GetComponent<Operative>().GetDefenceDice(); x++)
                        {
                            int randomInt = Random.Range(1, 7);
                            Debug.Log(randomInt.ToString());
                            if (randomInt >= hit.transform.gameObject.GetComponent<Operative>().GetSave() && randomInt < 6)
                            {
                                normalSave += 1;
                            }
                            if (randomInt == 6) // If the dice is equal to six
                            {
                                criticalSave += 1; // Add to the critical damage list
                            }
                        }
                        savesText.text = ("Normal Saves and Critical Saves: " + normalSave + ", " + criticalSave); //Updates textbox with values
                        for (var x = 0; x < criticalHits; x++) // For how many critical hits, deal damage equal to the value of the critical hits
                        {
                            if (criticalSave > 0) // If there are critical saves
                            {
                                criticalSave -= 1; //Reduce 1 critical save
                            }
                            else
                            {
                                if (normalSave >= 2 && criticalSave <= 0) // If there are more than 2 normal saves
                                {
                                    normalSave -= 2; //Reduce 2 normal saves
                                }
                                else //No saves
                                {
                                    //Deal damage to the operative
                                    hit.transform.gameObject.GetComponent<Operative>().SetWounds(OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetCriticalDamage());
                                }

                            }

                        }
                        for (var x = 0; x < normalHits; x++) // For how many normal hits, deal damage equal to the value of the normal hits
                        {
                            if (normalSave > 0) // If there are normal saves
                            {
                                normalSave -= 1; //Reduce 1 normal save
                            }
                            else
                            {
                                if (criticalSave > 0 && normalSave <= 0) // If there are critical saves
                                {
                                    criticalSave -= 1; //Reduce 1 critical save
                                }
                                else
                                {
                                    //Deal damage to the operative
                                    hit.transform.gameObject.GetComponent<Operative>().SetWounds(OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetNormalDamage());
                                }
                            }
                            finalHealthText.text = ("Wounds: " + hit.transform.gameObject.GetComponent<Operative>().GetWounds().ToString()); // Debug Line to show wounds of hit operative after the attack
                            meleeMode = false; //Disables shooting mode
                            criticalHits = 0; // Resets critical hits count
                            normalHits = 0; // Resets normal hits count
                            normalSave = 0; // Resets normal saves count
                            criticalSave = 0; // Resets critical saves count
                            OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().SetAPL(1); //Reduce user operative APL by 1
                            OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().setMeleeUsed(); //Makes it so the actions can't be used again
                        }
                    }
                    else
                    {
                        meleeMode = false; //Disables melee mode
                    }
                }
            }
        }
        else
        {
            meleeMode = false; //Disables melee mode
        }
    }
}