using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmanuScript : MonoBehaviour
{
    public GameObject SystemManager;
    public void Report(){
        SystemManager.GetComponent<SystemScript>().ToPage(transform.parent.name, "Submission");
    }
    public void History(){
        SystemManager.GetComponent<SystemScript>().ToPage(transform.parent.name, "History");
    }
}
