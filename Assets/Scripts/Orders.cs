using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{


    public void ToggleEngagedOrder()
    {
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().EngagedOrder = true;
        if (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().ConcealedOrder == true)
        {
            OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().ConcealedOrder = false;
        }
    }
    public void ToggleConcealedOrder()
    {
        OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().ConcealedOrder = true;
        if (OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().EngagedOrder == true)
        {
            OperativeSelected.Instance.operativeSelected[0].transform.gameObject.GetComponent<Operative>().EngagedOrder = false;
        }
    }
}
