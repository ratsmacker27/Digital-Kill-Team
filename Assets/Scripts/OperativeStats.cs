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
    public Shoot shootScript;
    public Melee meleeScript;
    public TMP_Text attacksText; // Movement Characteristic Text
    public TMP_Text attackRollText; // APL Text
    public TMP_Text normalDamageText; // Defence Dice Text
    public TMP_Text criticalDamageText; // Save Characteristic Text

    // Update is called once per frame
    void Update()
    {
        if (OperativeSelected.Instance.OperativeReady == true)
        {
            movementCharText.text = ("Movement Characteristic: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetMovement()).ToString();
            APLText.text = ("APL: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetAPL()).ToString();
            defenceDiceText.text = ("Defence Dice: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetDefenceDice()).ToString();
            saveCharText.text = ("Save Characteristic: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetSave() + "+").ToString();
            woundsText.text = ("Wounds: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetWounds()).ToString();
            if (meleeScript.getMeleeMode() == true)
            {
                attacksText.text = ("Number of Attacks: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetAttacks()).ToString();
                attackRollText.text = ("Attack Roll: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetAttackRoll() + "+").ToString();
                normalDamageText.text = ("Normal Damage: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetNormalDamage()).ToString();
                criticalDamageText.text = ("Critical Damage: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<MeleeWeapon>().GetCriticalDamage()).ToString();
            }
            if (shootScript.getShootingMode() == true)
            {
                attacksText.text = ("Number of Attacks: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<RangedWeapon>().GetAttacks()).ToString();
                attackRollText.text = ("Attack Roll: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<RangedWeapon>().GetAttackRoll() + "+").ToString();
                normalDamageText.text = ("Normal Damage: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<RangedWeapon>().GetNormalDamage()).ToString();
                criticalDamageText.text = ("Critical Damage: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponentInChildren<RangedWeapon>().GetCriticalDamage()).ToString();
            }
        }
        
    }
}
