using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionSystem : MonoBehaviour
{
    public GameObject SystemManager;
    public void AdditionInfo(){
        SystemManager.GetComponent<SystemScript>().ToPage(transform.parent.name, "Additional");
    }
}
