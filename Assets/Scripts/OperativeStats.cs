using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OperativeStats : MonoBehaviour
{
    public TMP_Text movementCharText; // Movement Characteristic Text
    public TMP_Text APLText; // APL Text
    public TMP_Text defenceDiceText; // Defence Dice Text
    public TMP_Text saveCharText; // Save Characteristic Text
    public TMP_Text woundsText; // Wounds Text
    public Shoot shootScript; // Using the Shoot class
    public Melee meleeScript; // Using the Melee class
    public TMP_Text attacksText; // Movement Characteristic Text
    public TMP_Text attackRollText; // APL Text
    public TMP_Text normalDamageText; // Defence Dice Text
    public TMP_Text criticalDamageText; // Save Characteristic Text

    // Update is called once per frame
    void Update()
    {
        if (OperativeSelected.Instance.OperativeReady == true) // If an operative is selected
        {
            movementCharText.text = ("Movement Characteristic: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetMovement()).ToString(); // Display operative movement
            APLText.text = ("APL: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetAPL()).ToString(); // Display operative action points
            defenceDiceText.text = ("Defence Dice: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetDefenceDice()).ToString(); // Display operative defence dice
            saveCharText.text = ("Save Characteristic: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetSave() + "+").ToString(); // Display operative save roll needed
            woundsText.text = ("Wounds: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetWounds()).ToString(); // Display operative wounds
            if (meleeScript.getMeleeMode() == true) // If the operative does a Melee action
            {
                attacksText.text = ("Number of Attacks: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetAttacks()).ToString(); // Display number of attacks
                attackRollText.text = ("Attack Roll: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetAttackRoll() + "+").ToString(); // Display attack roll needed
                normalDamageText.text = ("Normal Damage: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetNormalDamage()).ToString(); // Display normal damage 
                criticalDamageText.text = ("Critical Damage: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetCriticalDamage()).ToString(); // Display critical damage
            }
            if (shootScript.getShootingMode() == true) // If the operative does a Shooting action
            {
                attacksText.text = ("Number of Attacks: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<RangedWeapon>().GetAttacks()).ToString(); // Display number of attacks
                attackRollText.text = ("Attack Roll: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<RangedWeapon>().GetAttackRoll() + "+").ToString(); // Display attack roll needed
                normalDamageText.text = ("Normal Damage: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<RangedWeapon>().GetNormalDamage()).ToString(); // Display normal damage 
                criticalDamageText.text = ("Critical Damage: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<RangedWeapon>().GetCriticalDamage()).ToString(); // Display critical damage
            }
        }
        
    }
}
