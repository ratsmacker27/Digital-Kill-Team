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



    private static OperativeSelected _instance; 
    public static OperativeSelected Instance { get { return _instance; } }

    void Awake()    
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void ClickSelect(GameObject operativeToAdd)
    {
        if (operativeSelected.Count <= 0) // && (unitSelected.Count != Operative.Instance.groupActivation))
        {
            operativeSelected.Add(operativeToAdd);
            OperativeReady=true;
            operativeToAdd.GetComponent<Operative>().SetActive(true);
            operativeToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }

    }
    public void ClearAll()
    {
        foreach (var operative in operativeSelected)
        {
            operative.transform.GetChild(0).gameObject.SetActive(false);
        }
        operativeSelected.Clear();
        OperativeReady = false;
    }

}
