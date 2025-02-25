using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Operative : MonoBehaviour
{
    // Variables of an Operative
    public GameObject operative;
    private float movementCharateristic = 6;
    private int initialAPL = 3;
    private int APL = 2;
    private int defDice = 3;
    private int save = 3;
    private int wounds = 12;
    public bool currentActiveOperative = false;
    public bool activate = false;
    public int team;
    public bool EngagedOrder = false;
    public bool ConcealedOrder = false;
    public TeamSelection Turns;
    public bool obscured = false;

    CircleCollider2D EngangementRange;

    public bool shootingUsed = false;
    public bool movingUsed = false;
    public bool dashingUsed = false;
    public bool chargingUsed = false;
    public bool meleeUsed = false;
    public OperativeSelected TurningPointCount;
 


    void Start()
    {

        if (team == 0)
        {
            OperativeSelected.Instance.operativeTeam1.Add(this.gameObject); // Adds the Operatives to the list of operatives on the map
        }
        if (team == 1)
        {
            OperativeSelected.Instance.operativeTeam2.Add(this.gameObject); // Adds the Operatives to the list of operatives on the map
        }

    }
    void Update()
    {
        if(APL == 0)
        {
            OperativeSelected.Instance.ClearAll();
            Turns.TotalAPLUsed += initialAPL;
            APL = initialAPL;
            activate = true;
            Turns.SwitchTurns();
            shootingUsed = false;
            movingUsed = false;
            dashingUsed = false;
            chargingUsed = false;
            meleeUsed = false;
        }
        if(wounds <= 0)
        {
            OnDestroy();
            operative.SetActive(false);
        }
        if (Turns.getTotalAPLUsed() == (initialAPL * (TurningPointCount.operativeTeam1.Count + TurningPointCount.operativeTeam2.Count)))
        {
            for (int i = 0; i < TurningPointCount.operativeTeam1.Count; i++)
            {
                TurningPointCount.operativeTeam1[i].transform.gameObject.GetComponent<Operative>().SetUsed();
            }
            for (int i = 0; i < TurningPointCount.operativeTeam2.Count; i++)
            {
                TurningPointCount.operativeTeam2[i].transform.gameObject.GetComponent<Operative>().SetUsed();
            }
        }
    }
    void OnDestroy()
    {
        if (team == 0)
        {
            OperativeSelected.Instance.operativeTeam1.Remove(this.gameObject); // Removes the Operatives to the list of operatives on the map
        }
        if (team == 1)
        {
            OperativeSelected.Instance.operativeTeam2.Remove(this.gameObject); // Removes the Operatives to the list of operatives on the map
        }
    }


    public void SetUsed()
    {
        activate = !activate;
    }

    public void SetActive(bool active)
    {
        currentActiveOperative=active; // Makes the operative ready to be activated.
    }

    public int GetWounds()
    {
        return wounds;  // Returns wounds
    }

    public void SetWounds(int dmg)
    {
        wounds = wounds - dmg; // Set the wounds
    }
    public int GetDefenceDice()
    {
        return defDice;  // Returns wounds
    }
    public int GetSave()
    {
        return save;  // Returns wounds
    }
    public int GetAPL()
    {
        return APL;
    }
    public void SetAPL(int exhausted)
    {
        APL = APL - exhausted;
    }
    public float GetMovement()
    {
        return movementCharateristic;  // Returns wounds
    }
    public bool GetActive()
    {
        return activate;
    }
    public int GetTeam()
    {
        return team;
    }
    public bool getConcealOrder()
    {
        return ConcealedOrder;
    }
    public bool getEngagedOrder()
    {
        return EngagedOrder;
    }
    public bool getShootingUsed()
    {
        return shootingUsed;
    }
    public bool getMovingUsed()
    {
        return movingUsed;
    }
    public bool getDashingUsed()
    {
        return dashingUsed;
    }
    public bool getChargingUsed()
    {
        return chargingUsed;
    }
    public bool getMeleeUsed()
    {
        return meleeUsed;
    }
    public void setShootingUsed()
    {
        shootingUsed = !shootingUsed;
    }
    public void setMovingUsed()
    {
        movingUsed = !movingUsed;
    }
    public void setDashingUsed()
    {
        dashingUsed = !dashingUsed;
    }
    public void setChargingUsed()
    {
        chargingUsed = !chargingUsed;
    }
    public void setMeleeUsed()
    {
        meleeUsed = !meleeUsed;
    }

}

