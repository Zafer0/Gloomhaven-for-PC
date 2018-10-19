using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour {

    //persistant data that's used throughout the game.

    public static SaveController SaveInfo;

    public SaveObject CampaignSave;

	// Use this for initialization
    void Awake () {
        if(SaveInfo == null)
        {
            DontDestroyOnLoad(gameObject);
            SaveInfo = this;
        }
        else if(SaveInfo != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Campaign GetCampaign()
    {
        return CampaignSave.GetCampaign();
    }

    public Party GetParty()
    {
        return CampaignSave.GetParty();
    }
}
