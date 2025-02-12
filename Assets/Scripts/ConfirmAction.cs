using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmAction : MonoBehaviour
{
    bool confirmation = false;
    public void confirmAction()
    {
        confirmation = !confirmation;
        OperativeSelected.Instance.ClearAll(); // Clears the operatives in the selection list
    }
}

