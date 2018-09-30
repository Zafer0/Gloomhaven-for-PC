using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class newCampaignScript : MonoBehaviour {

    public Dropdown dropdown;
    public Button startButton;
    public InputField campaignName;
    public InputField partyName;
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;
    public GameObject char4;
    public Texture bruteSprite;
    public Texture tinkererSprite;
    public Texture spellweaverSprite;
    public Texture scoundrelSprite;
    public Texture cragheartSprite;
    public Texture mindthiefSprite;
    List<string> allClasses = new List<string>() { "Select a class", "Brute", "Tinkerer", "Spellweaver", "Scoundrel", "Cragheart", "Mindtheif" };
    List<string> usedClasses = new List<string>() { };
    List<string> lifeGoals = new List<string>() { "Seeker of Xorn", "Merchant Class", "Greed is Good", "Finding the Cure", "A Study of Anatomy", "Lawbringer", "Pounds of Flesh", "Trophy Hunt",
                                                    "Eternal Wanderer", "Battle Legend", "Implement of Light", "Take Back the Trees", "The Thin Places", "Aberrant Slayer", "Fearless Stand",
                                                    "Piety in All Things", "Vengeance", "Zealot of the Blood God", "Goliath Toppler", "The Fall of Man", "Augmented Abilities", "Elemental Samples",
                                                    "A Helping Hand", "The Perfect Poison"}; //24 total, 0 to 23
    private bool charFinished = true;
    private bool partyFinished = false;
    private RawImage charSprite;
    private Text charClass;
    private Button[] lifeGoalButtons;

    void Start()
	{
        dropdown.AddOptions(allClasses);
    }

    private void Update()
    {
        if(!campaignName.GetComponentsInChildren<Text>()[1].text.Equals("") && !partyName.GetComponentsInChildren<Text>()[1].text.Equals(""))
        {
            if(charFinished && char4.activeSelf && !char4.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals("") && !char3.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals("") && !char2.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals("") && !char1.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals(""))
            {
                partyFinished = true;
            }
            else if(charFinished && char3.activeSelf && !char3.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals("") && !char2.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals("") && !char1.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals(""))
            {
                partyFinished = true;
            }
            else if(charFinished && char2.activeSelf && !char2.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals("") && !char1.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text.Equals(""))
            {
                partyFinished = true;
            }
            else
                partyFinished = false;
        }
        else
        {
            partyFinished = false;
        }

        startButton.interactable = partyFinished;
        dropdown.interactable = charFinished;
    }

    public void Dropdown_IndexChanged(int index)
    {
        if (index != 0 && usedClasses.Count <= 3)
        {
            if(!usedClasses.Contains(allClasses[index]))
            {
                charFinished = false;
                usedClasses.Add(allClasses[index]);
                string lifeGoal1 = lifeGoals[Random.Range(0,lifeGoals.Count-1)];
                lifeGoals.Remove(lifeGoal1);
                string lifeGoal2 = lifeGoals[Random.Range(0, lifeGoals.Count - 1)];
                lifeGoals.Remove(lifeGoal2);

                if (!char1.activeSelf)
                {
                    charSprite = char1.transform.GetChild(0).GetComponent<RawImage>();
                    charClass = char1.transform.GetChild(1).GetComponent<Text>();
                    lifeGoalButtons = char1.GetComponentsInChildren<Button>();
                    char1.SetActive(true);
                }
                else if(!char2.activeSelf)
                {
                    charSprite = char2.transform.GetChild(0).GetComponent<RawImage>();
                    charClass = char2.transform.GetChild(1).GetComponent<Text>();
                    lifeGoalButtons = char2.GetComponentsInChildren<Button>();
                    char2.SetActive(true);
                }
                else if (!char3.activeSelf)
                {
                    charSprite = char3.transform.GetChild(0).GetComponent<RawImage>();
                    charClass = char3.transform.GetChild(1).GetComponent<Text>();
                    lifeGoalButtons = char3.GetComponentsInChildren<Button>();
                    char3.SetActive(true);
                }
                else
                {
                    charSprite = char4.transform.GetChild(0).GetComponent<RawImage>();
                    charClass = char4.transform.GetChild(1).GetComponent<Text>();
                    lifeGoalButtons = char4.GetComponentsInChildren<Button>();
                    char4.SetActive(true);
                }

                switch (index)
                {
                    case 1:
                        charSprite.texture = bruteSprite;
                        charClass.text = "Brute";
                        break;
                    case 2:
                        charSprite.texture = tinkererSprite;
                        charClass.text = "Tinkerer";
                        break;
                    case 3:
                        charSprite.texture = spellweaverSprite;
                        charClass.text = "Spellweaver";
                        break;
                    case 4:
                        charSprite.texture = scoundrelSprite;
                        charClass.text = "Scoundrel";
                        break;
                    case 5:
                        charSprite.texture = cragheartSprite;
                        charClass.text = "Cragheart";
                        break;
                    default:
                        charSprite.texture = mindthiefSprite;
                        charClass.text = "Mindthief";
                        break;
                }

                lifeGoalButtons[0].GetComponentInChildren<Text>().text = lifeGoal1;
                lifeGoalButtons[1].GetComponentInChildren<Text>().text = lifeGoal2;
            }
        }
    }

    public void goToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void startGame()
    {
        Campaign thisCampaign = new Campaign();
        Character firstCharacter = new Character();
        firstCharacter.newChar(char1.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text, char1.GetComponentInChildren<Text>().text, char1.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);

        if (char4.activeSelf)
        {
            Character secondCharacter = new Character();
            secondCharacter.newChar(char2.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text, char2.GetComponentInChildren<Text>().text, char2.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);
            Character thirdCharacter = new Character();
            thirdCharacter.newChar(char3.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text, char3.GetComponentInChildren<Text>().text, char3.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);
            Character fourthCharacter = new Character();
            fourthCharacter.newChar(char4.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text, char4.GetComponentInChildren<Text>().text, char4.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);

            thisCampaign.newCampaign(campaignName.GetComponentsInChildren<Text>()[1].text, firstCharacter, secondCharacter, thirdCharacter, fourthCharacter);
        }
        else if (char3.activeSelf)
        {
            Character secondCharacter = new Character();
            secondCharacter.newChar(char2.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text, char2.GetComponentInChildren<Text>().text, char2.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);
            Character thirdCharacter = new Character();
            thirdCharacter.newChar(char3.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text, char3.GetComponentInChildren<Text>().text, char3.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);

            thisCampaign.newCampaign(campaignName.GetComponentsInChildren<Text>()[1].text, firstCharacter, secondCharacter, thirdCharacter);
        }
        else if (char2.activeSelf)
        {
            Character secondCharacter = new Character();
            secondCharacter.newChar(char2.GetComponentInChildren<InputField>().GetComponentsInChildren<Text>()[1].text, char2.GetComponentInChildren<Text>().text, char2.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text);

            thisCampaign.newCampaign(campaignName.GetComponentsInChildren<Text>()[1].text, firstCharacter, secondCharacter);
        }

        Party party = new Party();
        party.NewParty(partyName.GetComponentsInChildren<Text>()[1].text);

        SaveObject saveGame = new SaveObject();
        saveGame.SaveGame(thisCampaign, party);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GloomhavenSave.dat");
        bf.Serialize(file, saveGame);
        file.Close();

        SceneManager.LoadScene(3);
    }

    public void selectLifeGoal1()
    {
        if (char4.activeSelf)
        {
            lifeGoalButtons = transform.GetChild(10).GetComponentsInChildren<Button>();
        }
        else if(char3.activeSelf)
        {
            lifeGoalButtons = transform.GetChild(9).GetComponentsInChildren<Button>();
        }
        else if(char2.activeSelf)
        {
            lifeGoalButtons = transform.GetChild(8).GetComponentsInChildren<Button>();
        }
        else
        {
            lifeGoalButtons = transform.GetChild(7).GetComponentsInChildren<Button>();
        }

        charFinished = true;
        Destroy(lifeGoalButtons[1].gameObject);
        lifeGoals.Add(lifeGoalButtons[1].GetComponentInChildren<Text>().text);
    }

    public void selectLifeGoal2()
    {
        if (char4.activeSelf)
        {
            lifeGoalButtons = transform.GetChild(10).GetComponentsInChildren<Button>();
        }
        else if (char3.activeSelf)
        {
            lifeGoalButtons = transform.GetChild(9).GetComponentsInChildren<Button>();
        }
        else if (char2.activeSelf)
        {
            lifeGoalButtons = transform.GetChild(8).GetComponentsInChildren<Button>();
        }
        else
        {
            lifeGoalButtons = transform.GetChild(7).GetComponentsInChildren<Button>();
        }

        charFinished = true;
        Destroy(lifeGoalButtons[0].gameObject);
        lifeGoals.Add(lifeGoalButtons[0].GetComponentInChildren<Text>().text);
    }
    
}
