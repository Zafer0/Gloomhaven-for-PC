using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item{

    private string Name;
    private int Cost;
    private string Ability;
	// Use this for initialization
	public void NewItem(string name, int cost, string ability)
    {
        Name = name;
        Cost = cost;
        Ability = ability;
    }
	
    //start get/set functions

	public string GetName()
    {
        return Name;
    }

    public int GetCost()
    {
        return Cost;
    }

    public string GetAbility()
    {
        return Ability;
    }
}
