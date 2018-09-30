using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GloomhavenMain : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponentsInChildren<Text>()[0].text = SaveController.SaveInfo.GetCampaign().GetName();
        gameObject.GetComponentsInChildren<Text>()[1].text = SaveController.SaveInfo.GetParty().GetName();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToShop()
    {
        SceneManager.LoadScene(4);
    }
}
