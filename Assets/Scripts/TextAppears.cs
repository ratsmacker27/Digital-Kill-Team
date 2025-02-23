using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppears : MonoBehaviour
{
    public GameObject Actions; //Getting the Actions game object
    public Movement movement; // From movement class
    public Shoot shoot; // From shoot class
    public Melee melee; // From melee class

    // Update is called once per frame
    void Update()
    {
        if (OperativeSelected.Instance.OperativeReady == true) //&& ((OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getEngagedOrder() == true) || (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getConcealOrder() == true))) // If Operative is selected
        {
            for (var i = 0; i < 2; i++) // For each child of the actions game object
            {
                Actions.transform.GetChild(i).gameObject.SetActive(true); //Set the objects to be seen and clickable
            }
            if ((OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getEngagedOrder() == true) || (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().getConcealOrder() == true))
            {
                for (var i = 2; i < Actions.transform.childCount; i++) // For each child of the actions game object
                {
                    Actions.transform.GetChild(i).gameObject.SetActive(true); //Set the objects to be seen and clickable
                }
                for (var i = 0; i < 2; i++) // For each child of the actions game object
                {
                    Actions.transform.GetChild(i).gameObject.SetActive(false); //Set the objects to be seen and clickable
                }
            }
            if ((movement.transform.gameObject.GetComponent<Movement>().movementMode == true) || (movement.transform.gameObject.GetComponent<Movement>().chargeMode == true) || (movement.transform.gameObject.GetComponent<Movement>().dashMode == true) || (shoot.transform.gameObject.GetComponent<Shoot>().shootingMode == true) || (melee.transform.gameObject.GetComponent<Melee>().meleeMode == true))
            {
                for (var i = 0; i < Actions.transform.childCount; i++) // For each child of the actions game object
                {
                    Actions.transform.GetChild(i).gameObject.SetActive(false); //Set the objects to not be seen and clickable
                }
            }
        }
        else
        {
            for (var i = 0; i < Actions.transform.childCount; i++) // For each child of the actions game object
            {
                Actions.transform.GetChild(i).gameObject.SetActive(false); //Set the objects to not be seen and clickable
            }
        }
    }
}
