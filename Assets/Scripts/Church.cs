using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Church : MonoBehaviour {

    public Button char1;
    public Button char2;
    public Button char3;
    public Button char4;
    public Button DonateButton;
    public Text GoldText;
    public Text DonatedText;
    private Character ActiveCharacter;

    // Use this for initialization
    void Start () {
        GoldText.text = "";
        DonatedText.text = "";

        //Load character sprites dpenedant on player count
        if (SaveController.SaveInfo.GetCampaign().GetCharacters().Count == 2)
        {
            char1.gameObject.SetActive(true);
            char1.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[0].GetClass());
            char2.gameObject.SetActive(true);
            char2.image.sprite = Resources.Load<Sprite>(SaveController.SaveInfo.GetCampaign().GetCharacters()[1].GetClass());
        }
        else if (SaveController.SaveInfo.GetCampaign().GetCharacters().Count == 3)
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

    }
	
	// Update is called once per frame
	void Update () {
        //Keep text updated to whatever player is active
        GoldText.text = ""+ActiveCharacter.GetGold();
        DonatedText.text = ""+SaveController.SaveInfo.GetCampaign().GetDonatedGold();
        DonateButton.interactable = !ActiveCharacter.HaveDonated();

    }

    public void loadChar1Info()
    {
        ActiveCharacter = SaveController.SaveInfo.GetCampaign().GetCharacters()[0];
    }

    public void loadChar2Info()
    {
        ActiveCharacter = SaveController.SaveInfo.GetCampaign().GetCharacters()[1];
    }
    public void loadChar3Info()
    {
        ActiveCharacter = SaveController.SaveInfo.GetCampaign().GetCharacters()[2];
    }
    public void loadChar4Info()
    {
        ActiveCharacter = SaveController.SaveInfo.GetCampaign().GetCharacters()[3];
    }

    public void Donate()
    {
        if(ActiveCharacter.GetGold() >= 10)
        {
            ActiveCharacter.changeGold(-10);
            SaveController.SaveInfo.GetCampaign().DonateGold();
            ActiveCharacter.Donate();
        }
    }

    public void ReturnToTown()
    {
        SceneManager.LoadScene(3);
    }
}
