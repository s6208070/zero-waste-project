using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginScript : MonoBehaviour
{
    public GameObject input_name;
    public GameObject input_pass;
    [SerializeField]
    public GameObject Error_message;
    [SerializeField]
    public GameObject SystemManager;
    private string username;
    private string password;
   public void Login(){
       //input
       username = input_name.GetComponent<InputField>().text;
       password = input_pass.GetComponent<InputField>().text;
       //database


        //respond
       if(username == "waste" && password == "5"){
           SystemManager.GetComponent<SystemScript>().ToPage(transform.parent.name,"Mainmanu");
       }else {
           if(username != "waste"){
               Error_message.GetComponent<TextMeshProUGUI>().text = "Invalid Username";
           }else{
               Error_message.GetComponent<TextMeshProUGUI>().text = "Invalid Password";
           }
       }
   }
}
