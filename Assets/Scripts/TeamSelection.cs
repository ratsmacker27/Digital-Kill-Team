using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamSelection : MonoBehaviour
{
    public int Roll;
    public int Team1Roll = 0;
    public int Team2Roll = 0;
    public int TotalAPLUsed = 0;
    public bool Team1Turn = false;
    public bool Team2Turn = false;
    public GameObject team1Announcement;
    public GameObject team2Announcement;
    private float timeToDisappear = 3f;
    public Operative operative;
    public OperativeSelected selected;

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
            team1Announcement.transform.gameObject.SetActive(true);
            if (Time.time >= timeToDisappear)
            {
                team1Announcement.transform.gameObject.SetActive(false);
            }

        }
        if (Team1Roll < Team2Roll)
        {
            Team2Turn = true;
            team2Announcement.transform.gameObject.SetActive(true);
            if (Time.time >= timeToDisappear)
            {
                team2Announcement.transform.gameObject.SetActive(false);
            }
        }
    }
    void Update()
    {
        if (Team1Roll > Team2Roll)
        {
            team1Announcement.transform.gameObject.SetActive(true);
            if (Time.time >= timeToDisappear)
            {
                team1Announcement.transform.gameObject.SetActive(false);
            }

        }
        if (Team1Roll < Team2Roll)
        {
            team2Announcement.transform.gameObject.SetActive(true);
            if (Time.time >= timeToDisappear)
            {
                team2Announcement.transform.gameObject.SetActive(false);
            }
        }
        if (getTotalAPLUsed() == (operative.GetInitialAPL() * (selected.operativeTeam1.Count + selected.operativeTeam2.Count)))
        {
            for (int i = 0; i < selected.operativeTeam1.Count; i++)
            {
                selected.operativeTeam1[i].transform.gameObject.GetComponent<Operative>().SetActiveOperative(false);
                selected.operativeTeam2[i].transform.gameObject.GetComponent<Operative>().SetActiveBool();
            }
            for (int i = 0; i < selected.operativeTeam2.Count; i++)
            {
                selected.operativeTeam2[i].transform.gameObject.GetComponent<Operative>().SetActiveOperative(false);
                selected.operativeTeam2[i].transform.gameObject.GetComponent<Operative>().SetActiveBool();
            }
            TotalAPLUsed = 0;
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
    public int getTotalAPLUsed()
    {
        return TotalAPLUsed;
    }
}
