using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class SubmissionSystem : MonoBehaviour
{
    public GameObject SystemManager;
    public GameObject ShowImage;
    public GameObject Database;
    public GameObject Custom;
    public GameObject Gps;
    public GameObject inpfield;
    public Sprite tick;
    public Sprite ttick;
    public TMP_InputField tambon;
    public TMP_InputField amphoe;
    public TMP_InputField province;
    public bool ck = false;
    public string location = null;
    private string path;
    public void AdditionInfo(){
        SystemManager.GetComponent<SystemScript>().ToPage(transform.parent.name, "Additional");
    }
    public void AddImage(){     
        path = EditorUtility.OpenFilePanel("Overwrite with jpg", "", "jpg");
        if (path.Length != 0)
        {
            var fileContent = File.ReadAllBytes(path);
            //Debug.Log(fileContent.GetType());
            Texture2D texture = new Texture2D(1,1);
            texture.LoadImage(fileContent);
            Sprite tem = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            ShowImage.GetComponent<Image>().sprite = tem;
            Database.GetComponent<DataSystemScript>().photo = fileContent;
        }
    }
    public void GetGPS(){
        ck = false;
        Gps.GetComponent<Image>().sprite = tick;
        Custom.GetComponent<Image>().sprite = ttick;
        inpfield.GetComponent<TMP_InputField>().interactable = false;
    }
    public void GetCustom(){
        ck = true;
        Gps.GetComponent<Image>().sprite = ttick;
        Custom.GetComponent<Image>().sprite = tick;
        inpfield.GetComponent<TMP_InputField>().interactable = true;

    }
    public void Submit(){
        
        //timestamp
        string monthVar = System.DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss");
        //Debug.Log(monthVar);
        Database.GetComponent<DataSystemScript>().timestamp = monthVar;

        //location
        if(ck){
            var inp = Custom.transform.GetChild(1);
            location = inp.GetComponent<TMP_InputField>().text;
        }else{
            //location = 
        }
        if(location == null || location.Length == 0){
            Debug.Log("Fill Address");
            return;
        }else {
            Database.GetComponent<DataSystemScript>().location = location;
        }

        //ImageLocalPath

        
        //submit
        Database.GetComponent<DataSystemScript>().Submit(path);
        SystemManager.GetComponent<SystemScript>().BackPage(transform.parent.name);
    }
    
}
