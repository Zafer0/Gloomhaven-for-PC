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
    private bool DoneCityEvent;
    private List<int> RoadEvents;
    private int DonatedGold;
    private List<ItemStock> Shop; //reference gloomhaven; Boots of Striding are 0. values are inventory left.
    private int Prosperity;
    private List<int> Scenarios; //reference gloomhaven; follows scenario book exactly.

    public void newCampaign(string name, Character first, Character second) //create new campaign for 2 players
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

        FinishCampaignCreation();
    }

    public void newCampaign(string name, Character first, Character second, Character third) //create new campaign for 3 players
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

        FinishCampaignCreation();
    }

    public void newCampaign(string name, Character first, Character second, Character third, Character fourth) //create new campaign for 4 players
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

        FinishCampaignCreation();
    }

    public void FinishCampaignCreation() //finish campaign creation that is player independant
    {

        CityEvents = createEventDeck();
        DoneCityEvent = false;
        RoadEvents = createEventDeck();
        DonatedGold = 0;
        Prosperity = 0;
        Scenarios = new List<int>() { 1 };
        Shop = new List<ItemStock>
        {
            new ItemStock{ Stock = 2, Name = "Boots of Striding", Price = 20},
            new ItemStock{ Stock = 2, Name = "Winged Shoes", Price = 20},
            new ItemStock{ Stock = 2, Name = "Hide Armor", Price = 10},
            new ItemStock{ Stock = 2, Name = "Leather Armor", Price = 20},
            new ItemStock{ Stock = 2, Name = "Cloak of Invisibility", Price = 20},
            new ItemStock{ Stock = 2, Name = "Eagle-Eye Goggles", Price = 30},
            new ItemStock{ Stock = 2, Name = "Iron Helmet", Price = 10},
            new ItemStock{ Stock = 2, Name = "Heater Shield", Price = 20},
            new ItemStock{ Stock = 2, Name = "Piercing Bow", Price = 30},
            new ItemStock{ Stock = 2, Name = "War Hammer", Price = 30},
            new ItemStock{ Stock = 2, Name = "Poison Dagger", Price = 20},
            new ItemStock{ Stock = 4, Name = "Minor Healing Potion", Price = 10},
            new ItemStock{ Stock = 4, Name = "Minor Stamina Potion", Price = 10},
            new ItemStock{ Stock = 4, Name = "Minor Power Potion", Price = 10},
        };

    }

    // start get and set functions

    public string GetName()
    {
        return Name;
    }

    public List<Character> GetCharacters()
    {
        return Characters;
    }

    public List<ItemStock> GetShop()
    {
        return Shop;
    }

    public int getPriceOfItem(string item)
    {
        bool found = false;
        int i = -1;
        while (!found && i < Shop.Count)
        {
            i++;
            if (Shop[i].Name.Equals(item))
            {
                found = true;
            }
        }

        return Shop[i].Price;
    }

    public int GetDonatedGold()
    {
        return DonatedGold;
    }

    public bool HaveDoneCityEvent()
    {
        return DoneCityEvent;
    }

    public void DoCityEvent()
    {
        DoneCityEvent = true;
    }

    public void DonateGold()
    {
        DonatedGold += 10;
    }

    public void RemoveItemInShop(string item)
    {
        bool found = false;
        int i = -1;
        while(!found && i < Shop.Count)
        {
            i++;
            if(Shop[i].Name.Equals(item))
            {
                found = true;
                Shop[i].Stock -= 1;
            }
        }
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

    [System.Serializable]
    public class ItemStock //temp object as placeholder for item class
    {
        public int Stock { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

}
