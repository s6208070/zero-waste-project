using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SystemScript : MonoBehaviour
{
    public string username;

    [SerializeField]
    List<GameObject> Allpage = new List<GameObject>();
    [SerializeField]
    private List<string> PageMem = new List<string>();
    private Dictionary<string, GameObject> page = new Dictionary<string, GameObject>();
    void Awake(){
        foreach(GameObject gob in Allpage){
            page.Add(gob.name,gob);
        }
    }
    public void ToPage(string now,string nex){
        int size = PageMem.Count;
        if(size > 1 && PageMem[size-2] == nex){
            PageMem.RemoveAt(size-1);
        }else{
            PageMem.Add(nex);
        }
        page[now].SetActive(false);
        page[nex].SetActive(true);
    }
    public void BackPage(string now){
        int size = PageMem.Count;
        if(size > 1){
            ToPage(now,PageMem[size-2]);
        }
    }
}
