﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character{

    private string Name;
    private string Class;
    private int Level;
    private int Xp;
    private int Gold;
    private int Checks;
    private string LifeGoal;
    List<string> Items;
    List<string> Perks;
    List<string> Cards;

    public void newChar(string name, string Class, string lifeGoal)
    {
        Name = name;
        this.Class = Class;
        LifeGoal = lifeGoal;
        Level = 1;
        Xp = 0;
        Gold = 30;
        Checks = 0;
        Items = new List<string>() { };
        Perks = new List<string>() { };
        Cards = new List<string>() { };
    }

    public void newChar(string name, string Class, int level, int gold, string perks, string cards) //if starting from lvl 2+
    {

    }

    public void setLevel(int level)
    {
        Level = level;
    }
    public void setXp(int xp)
    {
        Xp = xp;
    }
    public void setGold(int gold)
    {
        Gold = gold;
    }

    public void setChecks(int checks)
    {
        Checks = checks;
    }

    public void addItem(string item)
    {
        Items.Add(item);
    }
    public void addPerk(string perk)
    {
        Perks.Add(perk);
    }

    public void addCard(string card)
    {
        Cards.Add(card);
    }

    public string GetClass()
    {
        return Class;
    }

    public string GetLifeGoal()
    {
        return LifeGoal;
    }


}
