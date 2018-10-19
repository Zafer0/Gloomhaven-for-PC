using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{
    private string FrontText;
    private bool[] AReqs;
    private string OptionA;
    private bool[] BReqs;
    private string OptionB;
    private string ResultA;
    private string ResultB;
    private int[] Effects;

    // Use this for initialization
    void NewEventObject(string frontText, string optionA, string optionB, string resultA, string resultB, int[] effects)
    {
        FrontText = frontText;
        OptionA = optionA;
        OptionB = optionB;
        ResultA = resultA;
        ResultB = resultB;
        Effects = effects;
    }
}
	
