// script for connecting to the api and creating a user in the databas

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;


// Create classes that correspond to the data that will be sent/received
// via the API



// Allow the class to be extracted from Unity
// https://stackoverflow.com/questions/40633388/show-members-of-a-class-in-unity3d-inspector
[System.Serializable]
public class Player
{
    public string username;
    public string password;
    public string email;
}

// Allow the class to be extracted from Unity
//[System.Serializable]
//public class UserList
//{
//    public List<User> users;
//}

public class CreatePlayer : MonoBehaviour
{

    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] string url;
    [SerializeField] string endpoint;

    //[SerializeField] Text errorText;

    // This is where the information from the api will be extracted
    //public UserList allUsers;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space)) {
            QueryUsers();
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            InsertNewUser();
        }
        */
    }

    // Show the results of the Query in the Unity UI elements,
    // via another script that fills a scrollview
    //void DisplayUsers()
    //{
    //    TMPro_Test texter = GetComponent<TMPro_Test>();
    //    texter.LoadNames(allUsers);
    //}

    // These are the functions that must be called to interact with the API

    //public void QueryUsers()
    //{
    //    StartCoroutine(GetUsers());
    //}

    public void InsertNewUser()
    {
        StartCoroutine(AddUser());
    }

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    //IEnumerator GetUsers()
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.Success)
    //        {
    //            //Debug.Log("Response: " + www.downloadHandler.text);
    //            // Compose the response to look like the object we want to extract
    //            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
    //            string jsonString = "{\"users\":" + www.downloadHandler.text + "}";
    //            allUsers = JsonUtility.FromJson<UserList>(jsonString);
    //            DisplayUsers();
    //            if (errorText != null) errorText.text = "";
    //        }
    //        else
    //        {
    //            Debug.Log("Error: " + www.error);
    //            if (errorText != null) errorText.text = "Error: " + www.error;
    //        }
    //    }
    //}

    IEnumerator AddUser()
    {
        /*
        // This should work with an API that does NOT expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        Player newPlayer = new Player();

        newPlayer.username = username.text;
        newPlayer.password = password.text;
        newPlayer.email = email.text;

        Debug.Log($"username is : {newPlayer.username}");
        Debug.Log($"password is : {newPlayer.password}");
        Debug.Log($"email is : {newPlayer.email}");
        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(newPlayer);

        Debug.Log("BODY: " + jsonData);
        //yield return jsonData;
        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + endpoint, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + www.downloadHandler.text);
                //if (errorText != null) errorText.text = "";
            }
            else
            {
                Debug.Log("Error: " + www.error);
                //if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }


    ////////////////////////////////////////////////////
    // These functions allow making a callback after the API request finishes
    ////////////////////////////////////////////////////

    // Test function to get a response and act accordingly
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html
    //public void GetResults()
    //{
    //    UserList localUsers;
    //    // Call the IEnumerator and pass a lambda function to be called
    //    StartCoroutine(GetUsersString((reply) => {
    //        localUsers = JsonUtility.FromJson<UserList>(reply);
    //        DisplayUsers();
    //    }));
    //}

    // Sending the data back to the caller of the Coroutine, using a callback
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html
    //IEnumerator GetUsersString(System.Action<string> callback)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Get(url + getUsersEP))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.Success)
    //        {
    //            //Debug.Log("Response: " + www.downloadHandler.text);
    //            // Compose the response to look like the object we want to extract
    //            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
    //            string jsonString = "{\"users\":" + www.downloadHandler.text + "}";
    //            callback(jsonString);
    //            if (errorText != null) errorText.text = "";
    //        }
    //        else
    //        {
    //            Debug.Log("Error: " + www.error);
    //            if (errorText != null) errorText.text = "Error: " + www.error;
    //        }
    //    }
    //}
}
