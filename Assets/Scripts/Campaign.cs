using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Campaign{

    private string Name;
    private List<string> AvailableClasses;
    private List<Character> Characters;
    private List<string> lifeGoals;
    private List<int> CityEvents;
    private List<int> RoadEvents;
    private int DonatedGold;
    private List<int> Shop; //reference gloomhaven; Boots of Striding are 0. values are inventory left.
    private int Prosperity;
    private List<int> Scenarios; //reference gloomhaven; follows scenario book exactly.

    public void newCampaign(string name, Character first, Character second)
    {
        Name = name;

        AvailableClasses = new List<string>() { "Brute", "Tinkerer", "Spellweaver", "Scoundrel", "Cragheart", "Mindtheif" };
        Characters = new List<Character>() { first, second};
        AvailableClasses.Remove(first.GetClass());
        AvailableClasses.Remove(second.GetClass());

        lifeGoals = new List<string>() { "Seeker of Xorn", "Merchant Class", "Greed is Good", "Finding the Cure", "A Study of Anatomy", "Lawbringer", "Pounds of Flesh", "Trophy Hunt",
                                         "Eternal Wanderer", "Battle Legend", "Implement of Light", "Take Back the Trees", "The Thin Places", "Aberrant Slayer", "Fearless Stand",
                                         "Piety in All Things", "Vengeance", "Zealot of the Blood God", "Goliath Toppler", "The Fall of Man", "Augmented Abilities", "Elemental Samples",
                                         "A Helping Hand", "The Perfect Poison"};
        lifeGoals.Remove(first.GetLifeGoal());
        lifeGoals.Remove(second.GetLifeGoal());

        CityEvents = createEventDeck();
        RoadEvents = createEventDeck();
        DonatedGold = 0;
        Shop = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4 };
        Prosperity = 0;
        Scenarios = new List<int>() { 1 };

    }

    public void newCampaign(string name, Character first, Character second, Character third)
    {
        Name = name;

        AvailableClasses = new List<string>() { "Brute", "Tinkerer", "Spellweaver", "Scoundrel", "Cragheart", "Mindtheif" };
        Characters = new List<Character>() { first, second };
        AvailableClasses.Remove(first.GetClass());
        AvailableClasses.Remove(second.GetClass());
        AvailableClasses.Remove(third.GetClass());

        lifeGoals = new List<string>() { "Seeker of Xorn", "Merchant Class", "Greed is Good", "Finding the Cure", "A Study of Anatomy", "Lawbringer", "Pounds of Flesh", "Trophy Hunt",
                                         "Eternal Wanderer", "Battle Legend", "Implement of Light", "Take Back the Trees", "The Thin Places", "Aberrant Slayer", "Fearless Stand",
                                         "Piety in All Things", "Vengeance", "Zealot of the Blood God", "Goliath Toppler", "The Fall of Man", "Augmented Abilities", "Elemental Samples",
                                         "A Helping Hand", "The Perfect Poison"};
        lifeGoals.Remove(first.GetLifeGoal());
        lifeGoals.Remove(second.GetLifeGoal());
        lifeGoals.Remove(third.GetLifeGoal());

        CityEvents = createEventDeck();
        RoadEvents = createEventDeck();
        DonatedGold = 0;
        Shop = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4 };
        Prosperity = 0;
        Scenarios = new List<int>() { 1 };
    }

    public void newCampaign(string name, Character first, Character second, Character third, Character fourth)
    {
        Name = name;

        AvailableClasses = new List<string>() { "Brute", "Tinkerer", "Spellweaver", "Scoundrel", "Cragheart", "Mindtheif" };
        Characters = new List<Character>() { first, second };
        AvailableClasses.Remove(first.GetClass());
        AvailableClasses.Remove(second.GetClass());
        AvailableClasses.Remove(third.GetClass());
        AvailableClasses.Remove(fourth.GetClass());

        lifeGoals = new List<string>() { "Seeker of Xorn", "Merchant Class", "Greed is Good", "Finding the Cure", "A Study of Anatomy", "Lawbringer", "Pounds of Flesh", "Trophy Hunt",
                                         "Eternal Wanderer", "Battle Legend", "Implement of Light", "Take Back the Trees", "The Thin Places", "Aberrant Slayer", "Fearless Stand",
                                         "Piety in All Things", "Vengeance", "Zealot of the Blood God", "Goliath Toppler", "The Fall of Man", "Augmented Abilities", "Elemental Samples",
                                         "A Helping Hand", "The Perfect Poison"};
        lifeGoals.Remove(first.GetLifeGoal());
        lifeGoals.Remove(second.GetLifeGoal());
        lifeGoals.Remove(third.GetLifeGoal());
        lifeGoals.Remove(fourth.GetLifeGoal());

        CityEvents = createEventDeck();
        RoadEvents = createEventDeck();
        DonatedGold = 0;
        Shop = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4 };
        Prosperity = 0;
        Scenarios = new List<int>() { 1 };
    }

    public string GetName()
    {
        return Name;
    }

    public List<Character> GetCharacters()
    {
        return Characters;
    }

    private List<int> createEventDeck()
    {
        int randIndex;
        List<int> sortedDeck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        List<int> randomizedDeck = new List<int>() { };

        for (int i = 0; i < 30; i++)
        {
            randIndex = Random.Range(0, sortedDeck.Count);
            randomizedDeck.Add(sortedDeck[randIndex]);
            sortedDeck.RemoveAt(randIndex);
        }

        return randomizedDeck;
    }

}
