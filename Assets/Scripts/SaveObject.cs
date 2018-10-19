using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveObject{

    //actual object that's used by controller, persistant dta used throughut the game.

    Campaign Campaign;
    Party Party;

    public void SaveGame(Campaign campaign, Party party)
    {
        Campaign = campaign;
        Party = party;
    }

    public Campaign GetCampaign()
    {
        return Campaign;
    }

    public Party GetParty()
    {
        return Party;
    }
}
