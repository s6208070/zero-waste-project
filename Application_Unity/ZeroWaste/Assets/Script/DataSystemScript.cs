using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Proyecto26;
using Firebase;
using Firebase.Auth;
using Firebase.Storage;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Database;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

public class DataSystemScript : MonoBehaviour
{
    //send report
    [Header("Report data")]
    public byte[] photo;
    public string location;
    public string cox;
    public string coy;
    public string NearDetail;
    public string description;
    public string timestamp;
    public int OdorLevel;
    public int VisualLevel;
    public int SizeLevel;
    public string tambon;
    public string amphoe;
    public string province;
    public string userid;
    public string imageURL;
    [Header("Application script")]
    public LoginScript loginscript;
    public HistorySystemScript history;
    private List<DataSnapshot> listsnap = new List<DataSnapshot>();
    private List<WasteLink> listlink = new List<WasteLink>();
    public List<string> updhis = new List<string>();
    public MainmanuScript mainmanu;
    [Header("Firebase")]
    private DependencyStatus dependencyStatus;
    public FirebaseAuth auth;    
    public FirebaseUser User;
    private FirebaseStorage storage;
    private StorageReference PathRef;
    private DatabaseReference DBref;
    private List<Task<DataSnapshot> > listtask = new List<Task<DataSnapshot> >();

    void Start(){
        StartCoroutine(GPS());
    }
    public void Submit(string imagepath){
        UploadImage(imagepath);
        //Debug.Log(PathRef.ToString());
        return;
    }
    public void LogOut(){
        auth.SignOut();
    }
    public WastePack CreateWastePack(){
        WastePack ret = new WastePack();
        ret.userid = userid;
        ret.tambon = tambon;
        ret.amphoe = amphoe;
        ret.province = province;
        ret.cox = cox;
        ret.coy = coy;
        ret.description = description;
        ret.nearby = NearDetail;
        ret.location = location;
        ret.odor = OdorLevel.ToString();
        ret.visual = VisualLevel.ToString();
        ret.size = SizeLevel.ToString();
        ret.timestamp = timestamp;
        ret.status = "Not collected";
        ret.imageURL = imageURL;

        return ret;
    }
    public WasteLink CreateWasteLink(string link){
        WasteLink ret = new WasteLink();
        ret.seen = false;
        ret.submission = link;
        return ret;
    }
    public IEnumerator GPS(){
        //Debug.Log("Bug");
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
            coy = Input.location.lastData.latitude.ToString();
            cox = Input.location.lastData.longitude.ToString();
        }
        Input.location.Stop();
    }
    private void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
    private void InitializeFirebase()
    {
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        storage = FirebaseStorage.DefaultInstance;
        DBref = FirebaseDatabase.DefaultInstance.RootReference;
        if(auth == null)Debug.Log("auth is null");
        loginscript.auth = auth;
        Debug.Log("Setting up Firebase Auth");
    }
    public string GetUserID(){
        return DBref.Child("Users").Push().Key;
    }
    private void SendData(){
        //submission
        var json = JsonUtility.ToJson(CreateWastePack());
        string key = DBref.Child("garbages").Push().Key;
        Debug.Log("Sending data");
        DBref.Child("garbages").Child(key).SetRawJsonValueAsync(json)
            .ContinueWith((Task task) => {
                if (task.IsFaulted || task.IsCanceled) {
                    Debug.Log("Bug");
                    Debug.Log(task.Exception.ToString());
                    // Uh-oh, an error occurred!
                }
                else {
                    Debug.Log("Send data");
                }
            });;

        //user link
        var linkjson = JsonUtility.ToJson(CreateWasteLink(key));
        DBref.Child("users").Child(userid).Child(timestamp).SetRawJsonValueAsync(linkjson)
            .ContinueWith((Task task) => {
                if (task.IsFaulted || task.IsCanceled) {
                    Debug.Log("Bug");
                    Debug.Log(task.Exception.ToString());
                    // Uh-oh, an error occurred!
                }
                else {
                    Debug.Log("Send pointer");
                }
            });;
    }
    private void UploadImage(string localFile){
        StorageReference storageRef = storage.RootReference;
        // Create a reference to the file you want to upload
        PathRef = storageRef.Child("garbage_images/" + userid + "_" + timestamp + ".jpg");
        // Create file metadata including the content type
        var newMetadata = new MetadataChange();
        newMetadata.ContentType = "image/jpeg";
        PathRef.PutBytesAsync(photo, newMetadata, null, CancellationToken.None)
            .ContinueWith((Task<StorageMetadata> task) => {
                if (task.IsFaulted || task.IsCanceled) {
                    Debug.Log(task.Exception.ToString());
                    // Uh-oh, an error occurred!
                }
                else {
                    // Metadata contains file metadata such as size, content-type, and download URL.
                    StorageMetadata metadata = task.Result;
                    string md5Hash = metadata.Md5Hash;
                    Debug.Log("Finished uploading...");
                    Debug.Log("md5 hash = " + md5Hash);
                    GetImageURL();
                }
            });
    }
    private void GetImageURL(){
        PathRef.GetDownloadUrlAsync().ContinueWithOnMainThread(task => {
            if (!task.IsFaulted && !task.IsCanceled) {
                Debug.Log("Download URL: " + task.Result);
                // ... now download the file via WWW or UnityWebRequest.
                imageURL = task.Result.ToString();
                SendData();
            }else {
                Debug.Log("Bug Url");
            }
        });
    }
    public void LoadHistory(){
        history.ws.Clear();
        listlink.Clear();
        listsnap.Clear();
        Debug.Log("LoadHistory");
        DBref.Child("users").Child(userid).GetValueAsync()
            .ContinueWith(task => {
                if (task.IsFaulted) {
                    // Handle the error...
                    Debug.Log("LoadHistory Error");
                }
                else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    Debug.Log(task.Result.ToString());
                    foreach (DataSnapshot childSnapshot in snapshot.Children)
                    {   
                        var json = childSnapshot.GetRawJsonValue();
                        var submission =  JsonUtility.FromJson<WasteLink>(json);
                        listlink.Add(submission);
                        string sub = submission.submission;
                        bool vIn = submission.seen;
                        string seen = (vIn == true ? "True" : "False");
                        Debug.Log(sub + " " + seen);
                        //LoadSubmission(sub);
                    }
                    LoadSubmission();
                    //history.CreateTable();
                }
        });
    }
    async void LoadSubmission(){
        Debug.Log("LoadSubmission "+ listlink.Count);
        foreach(WasteLink wl in listlink){
            string key = wl.submission;
            var task = DBref.Child("garbages").Child(key).GetValueAsync();
            //Debug.Log("send "+key);
            listtask.Add(task);
        }
        await Task.WhenAll<DataSnapshot>(listtask);
        Debug.Log("Work");
        HistoryTransform();
    }
    private void LoadImage(string key){
        const long maxAllowedSize = 1 * 1024 * 1024;
        PathRef = storage.RootReference.Child("garbage_images/" + userid + "_" + key + ".jpg");
        PathRef.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled) {
                Debug.LogException(task.Exception);
                // Uh-oh, an error occurred!
            }
            else {
                byte[] fileContent = task.Result;
                Debug.Log("download image "+key);
                Texture2D texture = new Texture2D(1,1);
                texture.LoadImage(fileContent);
                Sprite tem = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                history.lsp.Add(key,tem);
            }
        }); 
    }
    public void UpdateHistory(){
        foreach(string key in updhis){
            Debug.Log("Update "+key);
            DBref.Child("users").Child(userid).Child(key).Child("seen").SetValueAsync(true);
        }
    }
    private void HistoryTransform(){
        foreach(var task in listtask){
            if(task.IsCompleted){
                //Debug.Log("LoadSubmission" + task.ToString());
                var snapshot = task.Result;
                listsnap.Add(snapshot);
            }
        }
        Debug.Log("History transform");

        foreach(DataSnapshot snapshot in listsnap){
            Debug.Log(snapshot.ToString());
            if(snapshot.Value == null){
                Debug.Log("Bug");
                continue;
            }
            var json = snapshot.GetRawJsonValue();
            //Debug.Log("Transform "+ json.ToString());
            var sub =  JsonUtility.FromJson<WastePack>(json);
            history.ws.Add(sub);
            LoadImage(sub.timestamp);            
        }
        history.ws.Sort(SortByTime);
        history.ws.Reverse();
        int siz = history.ws.Count;
        for(int i=0;i<siz;i++){
            if(history.ws[i].status == "Successfully collected" && listlink[siz-1-i].seen == false){
                updhis.Add(history.ws[i].timestamp);
            }
        }
        if(updhis.Count > 0){
            Debug.Log("Update " + updhis.Count);
        }
        Debug.Log("Transform Complete");
    }
    static int SortByTime(WastePack a, WastePack b){
        return a.timestamp.CompareTo(b.timestamp);
    }
}
