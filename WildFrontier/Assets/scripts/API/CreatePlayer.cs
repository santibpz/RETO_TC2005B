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

public class CreatePlayer : MonoBehaviour
{

    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] string url;
    [SerializeField] string endpoint;
    [SerializeField] Message notification;

    public void InsertNewPlayer()
    {
        StartCoroutine(AddPlayer());
    }


    IEnumerator AddPlayer()
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
        string jsonData = JsonUtility.ToJson(newPlayer);

        Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body

        using (UnityWebRequest www = UnityWebRequest.Put(url + endpoint, jsonData))
        {
          
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + www.downloadHandler.text);
                string succesMessage = www.downloadHandler.text;
                notification.Send(succesMessage);
            }
            else
            {
                Debug.Log("Error: " + www.error);
                string errorMessage = www.downloadHandler.text;
                notification.Send(errorMessage);
            }
        }
    }

}
