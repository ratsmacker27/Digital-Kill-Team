using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Melee : MonoBehaviour
{
    Camera cam;
    //public GameObject unit;
    public bool meleeMode = false;
    public int normalHits; // Makes a list for success normal hits
    public int criticalHits; // Makes a list for success critical hits
    private int randomInt;
    public int normalSave;
    public int criticalSave;
    public LayerMask clickable; // Only the layer with clickable areas
                                // Start is called before the first frame update
    public TMP_Text initialHealthText;
    public TMP_Text hitsText;
    public TMP_Text savesText;
    public TMP_Text finalHealthText;
    void Start()
    {
        cam = Camera.main;
    }
    public void ToggleMeleeMode()
    {
        meleeMode = !meleeMode;
    }
    public bool getMeleeMode()
    {
        return meleeMode; 
    }
    // Update is called once per frame
    void Update()
    {
        if ((meleeMode) && (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getEngagedOrder() == true))
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
                {
                    float distance = Vector2.Distance(new Vector2(OperativeSelected.Instance.operativeSelected[0].transform.position.x, OperativeSelected.Instance.operativeSelected[0].transform.position.y), new Vector2(hit.point.x, hit.point.y));
                    if (distance <= 1)
                    {
                        initialHealthText.text = ("Initial Wounds: " + hit.transform.gameObject.GetComponent<Operative>().GetWounds().ToString()); // Debug Line to show wounds of hit operative
                        for (var i = 0; i < OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetAttacks(); i++) // For loop for each attack of the weapon
                        {
                            int randomInt = Random.Range(1, 7); // Rolls a dice
                            Debug.Log(randomInt.ToString());
                            if (randomInt >= OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetAttackRoll() && randomInt < 6) // If the dice is more or equal to Attack Roll but less than six
                            {
                                normalHits += 1; // Add to the normal damage list
                            }
                            if (randomInt == 6) // If the dice is equal to six
                            {
                                criticalHits += 1; // Add to the critical damage list
                            }

                        }
                        hitsText.text = ("Normal Hits and Critical Hits: " + normalHits + ", " + criticalHits);
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
                        savesText.text = ("Normal Saves and Critical Saves: " + normalSave + ", " + criticalSave);
                        for (var x = 0; x < criticalHits; x++) // For how many critical hits, deal damage equal to the value of the critical hits
                        {
                            if (criticalSave > 0)
                            {
                                criticalSave -= 1;
                            }
                            if (normalSave >= 2)
                            {
                                normalSave -= 2;
                            }
                            else
                            {
                                hit.transform.gameObject.GetComponent<Operative>().SetWounds(OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetCriticalDamage());
                            }

                        }
                        for (var x = 0; x < normalHits; x++) // For how many normal hits, deal damage equal to the value of the normal hits
                        {
                            if (normalSave > 0)
                            {
                                normalSave -= 1;
                            }
                            else
                            {
                                hit.transform.gameObject.GetComponent<Operative>().SetWounds(OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetNormalDamage());
                            }
                        }
                        finalHealthText.text = ("Wounds: " + hit.transform.gameObject.GetComponent<Operative>().GetWounds().ToString()); // Debug Line to show wounds of hit operative after the attack
                        meleeMode = false; //Disables shooting mode
                        criticalHits = 0; // Resets critical hits count
                        normalHits = 0; // Resets normal hits count
                        normalSave = 0;
                        criticalSave = 0;
                        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().SetAPL(1);
                        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().setMeleeUsed();
                    }
                    else
                    {
                        meleeMode = false;
                    }
                }
            }
        }
    }
}