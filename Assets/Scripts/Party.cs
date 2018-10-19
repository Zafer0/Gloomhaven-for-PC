using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Party{

    private string Name;
    private string Location;
    private List<string> Achievements = new List<string>() { };
    private int Reputation;

    public void NewParty(string name)
    {
        Name = name;
        Location = "Gloomhaven";
        Reputation = 0;
    }

    //get/set functions

    public void SetLocation(string location)
    {
        Location = location;
    }

    public void ChangeReputation(int reputationChange)
    {
        Reputation += reputationChange;
    }

    public void AddAchievement(string achievement)
    {
        Achievements.Add(achievement);
    }

    public string GetName()
    {
        return Name;
    }

    public string GetLocation()
    {
        return Location;
    }

    public bool HasAchievement(string achievement)
    {
        return Achievements.Contains(achievement);
    }

    public int GetReputation()
    {
        return Reputation;
    }
}
