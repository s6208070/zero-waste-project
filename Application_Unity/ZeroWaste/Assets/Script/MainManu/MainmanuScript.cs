using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmanuScript : MonoBehaviour
{
    public SystemScript SystemManager;
    public DataSystemScript datasys;
    public GameObject history;
    public GameObject notifi;
    public bool ck = true;
    void Start(){
        notifi.SetActive(false);
    }
    void Update(){
        if(ck && datasys.updhis.Count > 0){
            notifi.SetActive(true);
        }
    }
    public void Report(){
        SystemManager.ToPage(transform.parent.name, "Submission");
    }
    public void History(){
        SystemManager.ToPage(transform.parent.name, "History");
        history.GetComponent<HistorySystemScript>().CreateTable();
        notifi.SetActive(false);
        ck = false;
    }
    public void LogOut(){
        datasys.LogOut();
        Application.Quit();
    }
}
