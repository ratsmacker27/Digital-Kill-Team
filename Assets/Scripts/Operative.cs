using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Operative : MonoBehaviour
{
    // Variables of an Operative
    public GameObject operative; // The gameObject of the operative
    private float movementCharateristic = 6; // Movement characteristic of an operative
    private int initialAPL = 2; // Initial action points of an operative
    public int APL = 2; // Action points of an operative
    private int defDice = 3; // Defence dice of an operative
    private int save = 3; // Save roll of an operative
    private int wounds = 12; // Wounds (Health) of an operative
    public bool currentActiveOperative = false; //If it is the current operative
    public bool activate = false; // If the operative has been activated
    public int team; // The team of the operative
    public bool EngagedOrder = false; // If the operative has an engage order
    public bool ConcealedOrder = false; // If the operative has an conceal order
    public TeamSelection Turns; // Using the TeamSelection class



    public bool shootingUsed = false; // If the Shoot action has been used
    public bool movingUsed = false; // If the Normal Movement action has been used
    public bool dashingUsed = false; // If the Dashing action has been used
    public bool chargingUsed = false; // If the Charging action has been used
    public bool meleeUsed = false; // If the Melee action has been used
    public OperativeSelected TurningPointCount; // Using the OperativeSelected class
 


    void Start()
    {

        if (team == 0) // If operative is in Team 1
        {
            OperativeSelected.Instance.operativeTeam1.Add(this.gameObject); // Adds the Operatives to the list of operatives on the map
        }
        if (team == 1) // If operative is in Team 2
        {
            OperativeSelected.Instance.operativeTeam2.Add(this.gameObject); // Adds the Operatives to the list of operatives on the map
        }

    }
    void Update()
    {
        if(APL == 0) // If operative has no action points
        {
            OperativeSelected.Instance.ClearAll(); // Make the operative unable to activate
            Turns.TotalAPLUsed += initialAPL; // Add the action points to the action points used
            APL = initialAPL; // Give all of the action points back
            activate = true; // Make the operative activated
            Turns.SwitchTurns(); // Switch the turn to the other team
            shootingUsed = false; // Make the activated operative be able to use the Shooting action
            movingUsed = false; // Make the activated operative be able to use the Normal Movement action
            dashingUsed = false; // Make the activated operative be able to use the Dashing action
            chargingUsed = false; // Make the activated operative be able to use the Charging action
            meleeUsed = false; // Make the activated operative be able to use the Melee action
        }
        if(wounds <= 0) // If the operative has no wounds
        {
            OnDestroy(); // Destroy the operative object
            operative.SetActive(false); // Set the operative activation false
        }
    }
    void OnDestroy()
    {
        if (team == 0) // If operative is in Team 1
        {
            OperativeSelected.Instance.operativeTeam1.Remove(this.gameObject); // Removes the Operatives to the list of operatives on the map
        }
        if (team == 1) // If operative is in Team 2
        {
            OperativeSelected.Instance.operativeTeam2.Remove(this.gameObject); // Removes the Operatives to the list of operatives on the map
        }
    }


    public void SetActiveOperative(bool active) //Setter method
    {
        currentActiveOperative=active; // Makes the operative ready to be activated.
    }
    public void SetActiveBool() //Setter method
    {
        activate = false; // Set activate off
    }

    public int GetWounds() //Getter method
    {
        return wounds;  // Returns wounds
    }

    public void SetWounds(int dmg) //Setter method
    {
        wounds = wounds - dmg; // Set the wounds
    }
    public int GetDefenceDice() //Getter method
    {
        return defDice;  // Returns defence dice
    }
    public int GetSave() //Getter method
    {
        return save;  // Returns saves
    }
    public int GetAPL() //Getter method
    {
        return APL;
    }
    public void SetAPL(int exhausted) //Setter method
    {
        APL = APL - exhausted;
    }
    public int GetInitialAPL() //Getter method
    {
        return initialAPL;
    }
    public float GetMovement() //Getter method
    {
        return movementCharateristic;  // Returns wounds
    }
    public bool GetActive() //Getter method
    {
        return activate;
    }
    public int GetTeam() //Getter method
    {
        return team;
    }
    public bool getConcealOrder() //Getter method
    {
        return ConcealedOrder;
    }
    public bool getEngagedOrder() //Getter method
    {
        return EngagedOrder;
    }
    public bool getShootingUsed() //Getter method
    {
        return shootingUsed;
    }
    public bool getMovingUsed() //Getter method
    {
        return movingUsed;
    }
    public bool getDashingUsed() //Getter method
    {
        return dashingUsed;
    }
    public bool getChargingUsed() //Getter method
    {
        return chargingUsed;
    }
    public bool getMeleeUsed() //Getter method
    {
        return meleeUsed;
    }
    public void setShootingUsed() //Setter method
    {
        shootingUsed = !shootingUsed;
    }
    public void setMovingUsed() //Setter method
    {
        movingUsed = !movingUsed;
    }
    public void setDashingUsed() //Setter method
    {
        dashingUsed = !dashingUsed;
    }
    public void setChargingUsed() //Setter method
    {
        chargingUsed = !chargingUsed;
    }
    public void setMeleeUsed() //Setter method
    {
        meleeUsed = !meleeUsed;
    }

}

