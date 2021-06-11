using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistorySystemScript : MonoBehaviour
{
    public float Offset;
    public float ElementSize;
    public Sprite Sred;
    public Sprite Syellow;
    public Sprite Sgreen;
    public GameObject content;
    public GameObject gob;
    public DataSystemScript datasys;
    public List<WastePack> ws;
    public Dictionary<string, Sprite> lsp = new Dictionary<string, Sprite>();

    public void CreateTable()
    {
        Debug.Log("Create table");
        //data

        //clear data
        if(content.transform.childCount > 0){
            foreach (Transform child in content.transform){
                Destroy(child.gameObject);
            }
        }
        //create
        Debug.Log("Table Count " + ws.Count + " : Sprite Count " + lsp.Count);
        int siz = ws.Count;
        var rt = content.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, siz*ElementSize+Offset);
        for(int i = 0;i<siz;i++){
            string key = ws[i].timestamp;
            Debug.Log("Create element "+i.ToString());
            //instantiate
            var obj = Instantiate(gob, new Vector3(0, 0, 0), Quaternion.identity, content.transform);
            var lr = obj.GetComponent<RectTransform>();
            lr.localPosition = new Vector3(400,-Offset*2-i*ElementSize,0);
            obj.SetActive(true);
            var image = obj.transform.GetChild(2).gameObject;
            var status = obj.transform.GetChild(3).gameObject;
            var timestamp = obj.transform.GetChild(0).gameObject;
            var location = obj.transform.GetChild(1).gameObject;
            //data
            var tem = ws[i].timestamp.Split('T');
            timestamp.GetComponent<TextMeshProUGUI>().text = tem[0] + "\n" + tem[1];
            location.GetComponent<TextMeshProUGUI>().text = ws[i].location;
            image.GetComponent<Image>().sprite = lsp[key];
            if(ws[i].status == "Not collected"){
                status.GetComponent<Image>().sprite = Sred;
            }else if(ws[i].status == "In process"){
                status.GetComponent<Image>().sprite = Syellow;
            }else if(ws[i].status == "Successfully collected"){
                status.GetComponent<Image>().sprite = Sgreen;
                //Debug.Log("Done");
            }
        }
        datasys.UpdateHistory();
    }

}
