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
    public TMP_InputField tambon;
    public TMP_InputField amphoe;
    public TMP_InputField province;
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
    public void Submit(){
        
        //timestamp
        string monthVar = System.DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss");
        //Debug.Log(monthVar);
        Database.GetComponent<DataSystemScript>().timestamp = monthVar;

        //location
        if(Custom.GetComponent<Toggle>().isOn == true){
            var inp = Custom.transform.GetChild(2);
            location = inp.GetComponent<TMP_InputField>().text;
        }else{
            //location = 
        }
        if(location == null || location.Length == 0){
            Debug.Log("Fill Address");
            return;
        }

        //ImageLocalPath

        
        //submit
        Database.GetComponent<DataSystemScript>().Submit(path);
    }
    
}
