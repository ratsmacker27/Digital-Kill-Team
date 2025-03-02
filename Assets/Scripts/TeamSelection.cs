using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamSelection : MonoBehaviour
{
    public int Roll; // Roll variable
    public int Team1Roll = 0; // What roll Team 1 has
    public int Team2Roll = 0; // What roll Team 2 has
    public int TotalAPLUsed = 0; // How many action points have been used in the turn
    public bool Team1Turn = false; // If it is Team 1's turn
    public bool Team2Turn = false; // If it is Team 2's turn
    public GameObject team1Announcement; // The announcement object for Team 1
    public GameObject team2Announcement; // The announcement object for Team 2
    private float timeToDisappear = 3f; // How long it takes for the announcement object to disappear
    public Operative operative; // The object of the particular operative
    public OperativeSelected selected; // The object for the lists of the teams

    // Start is called before the first frame update

    void Start()
    {
        while (Team1Roll == Team2Roll) // Rolls the dice until one roll is higher than the other
        {
            Roll = Random.Range(1, 7); // Team 1 roll
            Team1Roll = Roll;
            Roll = Random.Range(1, 7); // Team 2 roll
            Team2Roll = Roll;
        }
        if (Team1Roll > Team2Roll) // If Team 1 won the roll
        {
            Team1Turn = true; // It is team 1 turn
        }
        if (Team1Roll < Team2Roll) // If Team 2 won the roll
        {
            Team2Turn = true; // It is team 2 turn
        }
    }
    void Update()
    {
        if (Team1Roll > Team2Roll) // If Team 1 won the roll
        {
            team1Announcement.transform.gameObject.SetActive(true); // Show the Team 1 announcement
            if (Time.time >= timeToDisappear) // After 3 seconds
            {
                team1Announcement.transform.gameObject.SetActive(false); // Make the Team 1 announcement disappear
            }

        }
        if (Team1Roll < Team2Roll) // If Team 2 won the roll
        {
            team2Announcement.transform.gameObject.SetActive(true); // Show the Team 2 announcement
            if (Time.time >= timeToDisappear) // After 3 seconds
            {
                team2Announcement.transform.gameObject.SetActive(false);  // Make the Team 2 announcement disappear
            }
        }
        if (getTotalAPLUsed() == (operative.GetInitialAPL() * (selected.operativeTeam1.Count + selected.operativeTeam2.Count)))
        { // If the total action points used is equal to the added action points of both teams
            for (int i = 0; i < selected.operativeTeam1.Count; i++) // For every operative in Team 1
            {
                selected.operativeTeam1[i].transform.gameObject.GetComponent<Operative>().SetActiveOperative(false); // Make them active
                selected.operativeTeam1[i].transform.gameObject.GetComponent<Operative>().SetActiveBool(); 
                selected.operativeTeam1[i].transform.gameObject.GetComponent<Operative>().EngagedOrder = false; // Remove their order
                selected.operativeTeam1[i].transform.gameObject.GetComponent<Operative>().ConcealedOrder = false;
            }
            for (int i = 0; i < selected.operativeTeam2.Count; i++) // For every operative in Team 2
            {
                selected.operativeTeam2[i].transform.gameObject.GetComponent<Operative>().SetActiveOperative(false); // Make them active
                selected.operativeTeam2[i].transform.gameObject.GetComponent<Operative>().SetActiveBool();
                selected.operativeTeam2[i].transform.gameObject.GetComponent<Operative>().EngagedOrder = false; // Remove their order
                selected.operativeTeam2[i].transform.gameObject.GetComponent<Operative>().ConcealedOrder = false;
            }
            TotalAPLUsed = 0; // Reset the total action points used
        }
    }
    public bool GetTeam1() //Getter method
    {
        return Team1Turn;
    }
    public bool GetTeam2() //Getter method
    {
        return Team2Turn;
    }
    public void SwitchTurns() // Switches the turn
    {
        Team1Turn = !Team1Turn; // Turns the boolean from false to true or true to false
        Team2Turn = !Team2Turn; // Turns the boolean from false to true or true to false
    }
    public int getTotalAPLUsed() //Getter method
    {
        return TotalAPLUsed;
    }
}
