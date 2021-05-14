using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSystemScript : MonoBehaviour
{
    public byte[] photo;
    public string location;
    public string NearDetail;
    public string OtherDetail;
    public string TimeStamp;
    public int OdorLevel;
    public int VisualLevel;
    public int SizeLevel;
    void Start(){
        StartCoroutine(GPS());
    }
    public void Submit(){
        
        return;
    }
    public IEnumerator GPS(){
        Debug.Log("Bug");
        if (!Input.location.isEnabledByUser){
            Debug.Log("GPS isEnabledByUser");
            yield break;
        }
        Input.location.Start();
        int maxWait = 5;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            Debug.Log("Wait "+maxWait.ToString());
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            location = Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
        }
        Input.location.Stop();
    }
}
