using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdditionalSystemScript : MonoBehaviour
{
    public GameObject SystemManager;
    public GameObject SizeText;
    public GameObject OdorText;
    public GameObject VisualText;
    public string[] SizeCaption;
    public string[] OdorCaption;
    public string[] VisualCaption;
    public int InfoSize;
    public int InfoVisual;
    public int InfoOdor;
    public void Apply(){
        //information

        //
        SystemManager.GetComponent<SystemScript>().BackPage(transform.parent.name);
    }
    public void SlideUpd(Slider inp){
        if(inp.name == "SizeSlider"){
            InfoSize = (int)inp.value;
            SizeText.GetComponent<TextMeshProUGUI>().text = "[" + SizeCaption[(int)inp.value] + "]";

        }else if(inp.name == "OdorSlider"){
            InfoOdor = (int)inp.value;
            OdorText.GetComponent<TextMeshProUGUI>().text = "[" + OdorCaption[(int)inp.value] + "]";

        }else if(inp.name == "VisualSlider"){
            InfoVisual = (int)inp.value;
            VisualText.GetComponent<TextMeshProUGUI>().text = "[" + VisualCaption[(int)inp.value] + "]";
        }
    }
}
