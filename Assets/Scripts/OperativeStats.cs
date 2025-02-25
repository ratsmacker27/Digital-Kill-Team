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
    // Update is called once per frame
    void Update()
    {
        if (OperativeSelected.Instance.OperativeReady == true)
        {
            movementCharText.text = ("Movement Characteristic: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetMovement()).ToString();
            APLText.text = ("APL: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetAPL()).ToString();
            defenceDiceText.text = ("Defence Dice: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetDefenceDice()).ToString();
            saveCharText.text = ("Save Characteristic: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetSave()).ToString();
            woundsText.text = ("Wounds: " + OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().GetWounds()).ToString();
        }
    }
}
