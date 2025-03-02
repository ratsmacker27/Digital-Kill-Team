using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OperativeSelected : MonoBehaviour
{
    public bool OperativeReady = false; // Makes the operative ready
    public List<GameObject> operativeTeam1 = new List<GameObject>(); // Makes a list for Operatives in the battleground
    public List<GameObject> operativeTeam2 = new List<GameObject>(); // Makes a list for Operatives in the battleground
    public List<GameObject> operativeSelected = new List<GameObject>(); // Makes a list for Operatives selected



    private static OperativeSelected _instance; //Make the OperativeSelected an instance
    public static OperativeSelected Instance { get { return _instance; } } // The OperativeSelected Instance is now the _instance

    void Awake()    
    {
        if (_instance != null && _instance != this) // If this instance isn't empty and it isn't this instance
        {
            Destroy(this.gameObject); // The game object is destroyed
        }
        else
        {
            _instance = this; // Make the instance that particular instance
        }
    }
    public void ClickSelect(GameObject operativeToAdd)
    {
        if (operativeSelected.Count <= 0) // If there isn't any operative selected
        {
            operativeSelected.Add(operativeToAdd); // Add the operative to the selected list
            OperativeReady=true; // Make the operative ready to do actions
            operativeToAdd.GetComponent<Operative>().SetActiveOperative(true); // Set that the operative is activated
            operativeToAdd.transform.GetChild(0).gameObject.SetActive(true); // Set that the operative is in the activation phase
        }

    }
    public void ClearAll()
    {
        foreach (var operative in operativeSelected) // For every operative in the operativeSelected list
        {
            operative.transform.GetChild(0).gameObject.SetActive(false); // Set the operative isn't in the activation phase 
        }
        operativeSelected.Clear(); // Clear the operativeSelected list
        OperativeReady = false; // The operative cannot do actions
    }

}
