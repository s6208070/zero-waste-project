using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainmanuScript : MonoBehaviour
{
    public SystemScript SystemManager;
    public DataSystemScript datasys;
    public GameObject history;
    public GameObject notifi;
    public bool ck = true;
    public Sprite acti;
    public Sprite noti;
    void Update(){
        if(ck && datasys.updhis.Count > 0){
            notifi.GetComponent<Image>().sprite = acti;
        }
    }
    public void Report(){
        SystemManager.ToPage(transform.parent.name, "Submission");
    }
    public void History(){
        SystemManager.ToPage(transform.parent.name, "History");
        history.GetComponent<HistorySystemScript>().CreateTable();
        notifi.GetComponent<Image>().sprite = noti;
        ck = false;
    }
    public void LogOut(){
        datasys.LogOut();
        Application.Quit();
    }
}
