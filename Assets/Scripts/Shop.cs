using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public Button char1;
    public Button char2;
    public Button char3;
    public Button char4;
    public Text goldText;
    public Text itemsText;
    private Character shoppingCharacter;
    private string itemsString;
    private Button[] Items;

    // Use this for initialization
    void Start () {
        goldText.text = "";
        itemsText.text = "";
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

        Items = gameObject.transform.GetChild(6).GetComponentsInChildren<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        goldText.text = "" + shoppingCharacter.GetGold();
        itemsString = "";
        for (int i = 0; i < shoppingCharacter.getItems().Count; i++)
        {
            itemsString += shoppingCharacter.getItems()[i] + "\n";
        }
        itemsText.text = itemsString;

        for(int i = 0; i < Items.Length-1; i++)
        {
            if(SaveController.SaveInfo.GetCampaign().GetShop()[i].Stock <= 0)
            {
                Items[i].interactable = false;
            }
        }

        
		
	}

    public void PurchaseItem()
    {
        string itemName = EventSystem.current.currentSelectedGameObject.name;
        if (shoppingCharacter.GetGold() >= SaveController.SaveInfo.GetCampaign().getPriceOfItem(itemName))
        {
            shoppingCharacter.addItem(itemName);
            shoppingCharacter.changeGold(SaveController.SaveInfo.GetCampaign().getPriceOfItem(itemName) * -1);
            SaveController.SaveInfo.GetCampaign().RemoveItemInShop(itemName);
        }
        
    }

    public void loadChar1Info()
    {
        shoppingCharacter = SaveController.SaveInfo.GetCampaign().GetCharacters()[0];
    }

    public void loadChar2Info()
    {
        shoppingCharacter = SaveController.SaveInfo.GetCampaign().GetCharacters()[1];
    }
    public void loadChar3Info()
    {
        shoppingCharacter = SaveController.SaveInfo.GetCampaign().GetCharacters()[2];
    }
    public void loadChar4Info()
    {
        shoppingCharacter = SaveController.SaveInfo.GetCampaign().GetCharacters()[3];
    }
    public void ReturnToTown()
    {
        SceneManager.LoadScene(3);
    }
}
