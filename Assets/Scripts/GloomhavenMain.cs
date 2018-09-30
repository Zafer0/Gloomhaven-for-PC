using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GloomhavenMain : MonoBehaviour {
    private SaveObject save;
    private Campaign campaign;
    private Party party;

	// Use this for initialization
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/GloomhavenSave.dat"));
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GloomhavenSave.dat", FileMode.Open);
            save = (SaveObject)bf.Deserialize(file);
            file.Close();
        }

        campaign = save.GetCampaign();
        party = save.GetParty();

        gameObject.GetComponentsInChildren<Text>()[0].text = campaign.GetName();
        gameObject.GetComponentsInChildren<Text>()[1].text = party.GetName();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToShop()
    {
        SceneManager.LoadScene(4);
    }
}
