using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GloomhavenMain : MonoBehaviour {

    public Button char1;
    public Button char2;
    public Button char3;
    public Button char4;
    public Button CityEvent;

    // Use this for initialization
    void Start () {
        //heading text
        gameObject.GetComponentsInChildren<Text>()[0].text = SaveController.SaveInfo.GetCampaign().GetName();
        gameObject.GetComponentsInChildren<Text>()[1].text = SaveController.SaveInfo.GetParty().GetName();

        if(SaveController.SaveInfo.GetCampaign().GetCharacters().Count == 2) //load character sprites
        {
            char1.gameObject.SetActive(true);
            char1.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[0].GetClass());
            char2.gameObject.SetActive(true);
            char2.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[1].GetClass());
        }
        else if(SaveController.SaveInfo.GetCampaign().GetCharacters().Count == 3)
        {
            char1.gameObject.SetActive(true);
            char1.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[0].GetClass());
            char2.gameObject.SetActive(true);
            char2.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[1].GetClass());
            char3.gameObject.SetActive(true);
            char3.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[2].GetClass());
        }
        else
        {
            char1.gameObject.SetActive(true);
            char1.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[0].GetClass());
            char2.gameObject.SetActive(true);
            char2.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[1].GetClass());
            char3.gameObject.SetActive(true);
            char3.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[2].GetClass());
            char4.gameObject.SetActive(true);
            char4.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[3].GetClass());
        }

        if(SaveController.SaveInfo.GetCampaign().HaveDoneCityEvent()) //enable/disable actions
        {
            CityEvent.interactable = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    //scene changes

    public void GoToShop()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToChurch()
    {
        SceneManager.LoadScene(5);
    }

    public void DoCityEvent()
    {
        SceneManager.LoadScene(6);
    }
}
