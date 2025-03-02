using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public void ToggleEngagedOrder()
    {
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().EngagedOrder = true; // Toggle the engage order
        if (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().ConcealedOrder == true) // If the operative has a conceal order
        {
            OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().ConcealedOrder = false; // Turn the conceal order off
        }
    }
    public void ToggleConcealedOrder()
    {
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().ConcealedOrder = true; // Toggle the conceal order
        if (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().EngagedOrder == true) // If the operative has a engage order
        {
            OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().EngagedOrder = false; // Turn the engage order off
        }
    }
}
