using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelection : MonoBehaviour
{
    public int Roll;
    public int Team1Roll = 0;
    public int Team2Roll = 0;
    public bool Team1Turn = false;
    public bool Team2Turn = false;
    // Start is called before the first frame update
    void Start()
    {
        while (Team1Roll == Team2Roll)
        {
            Roll = Random.Range(1, 7);
            Team1Roll = Roll;
            Roll = Random.Range(1, 7);

            Team2Roll = Roll;
        }
        if (Team1Roll > Team2Roll)
        {
            Team1Turn = true;
            Debug.Log("Team 1 Turn");
        }
        if (Team1Roll < Team2Roll)
        {
            Debug.Log("Team 2 Turn");
            Team2Turn = true;
        }
    }
    public bool GetTeam1()
    {
        return Team1Turn;
    }
    public bool GetTeam2()
    {
        return Team2Turn;
    }
    public void SwitchTurns()
    {
        Team1Turn = !Team1Turn;
        Team2Turn = !Team2Turn;
    }
}
