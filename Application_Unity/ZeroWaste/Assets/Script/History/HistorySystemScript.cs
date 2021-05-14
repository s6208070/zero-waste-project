using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistorySystemScript : MonoBehaviour
{
    public float Offset;
    public float ElementSize;
    public Sprite Sred;
    public Sprite Syellow;
    public Sprite Sgreen;
    public GameObject content;
    public GameObject gob;
    // Start is called before the first frame update
    void Start()
    {
        //data

        //create
        int siz = 6;//inp.Count;
        var rt = content.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, siz*ElementSize+Offset);
        for(int i = 0;i<siz;i++){
            //instantiate
            var obj = Instantiate(gob, new Vector3(0, 0, 0), Quaternion.identity, content.transform);
            var lr = obj.GetComponent<RectTransform>();
            lr.localPosition = new Vector3(400,-Offset*2-i*ElementSize,0);
            obj.SetActive(true);
            var image = obj.transform.GetChild(2).gameObject;
            var status = obj.transform.GetChild(3).gameObject;

            //data
            int ck = 3;
            if(ck == 0){
                status.GetComponent<Image>().sprite = Sred;
            }else if(ck == 1){
                status.GetComponent<Image>().sprite = Syellow;
            }else{
                status.GetComponent<Image>().sprite = Sgreen;
                //Debug.Log("Done");
            }
        }
    }
}
