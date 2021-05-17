using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Proyecto26;
using Firebase;
using Firebase.Auth;
using Firebase.Storage;
using Firebase.Firestore;
using System.Threading;
using System.Threading.Tasks;

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
    [Header("Login script")]
    public LoginScript loginscript;
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;    
    public FirebaseUser User;
    public FirebaseStorage storage;
    private StorageReference PathRef;

    void Start(){
        StartCoroutine(GPS());
    }
    public void Submit(string imagepath){
        UploadImage(imagepath);
        //Debug.Log(PathRef.Path);
        return;
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
        ret.odor = OdorLevel.ToString();
        ret.visual = VisualLevel.ToString();
        ret.size = SizeLevel.ToString();
        ret.timestamp = timestamp;
        ret.status = "red";
        ret.imageURL = imageURL;

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
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        storage = FirebaseStorage.DefaultInstance;
        if(auth == null)Debug.Log("auth is null");
        loginscript.auth = auth;
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
                }
            });
    }
}
