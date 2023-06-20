using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class PlayerToken // info returned by the request
{
    public int player_id;
    public string username;
}

[System.Serializable]
public class PlayerCredentials
{
    public string username;
    public string password;
}


public class ValidatePlayerCredentials : MonoBehaviour
{
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] string url;
    [SerializeField] string loginEndpoint;
    [SerializeField] string playerItemsEP;
    [SerializeField] string playerWeaponsEP;
    [SerializeField] Message notification;

    public PlayerToken player; // player_id and username will be extracted to an instance of class PlayerToken
    public PlayerItems items; // player items will be extracted to an instance of PlayerItems.
    public void QueryPlayer()
    {
        StartCoroutine(ValidateCredentials());
    }


    IEnumerator ValidateCredentials()
    {
        /*
        // This should work with an API that does NOT expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        PlayerCredentials credentials = new PlayerCredentials();

        credentials.username = username.text;
        credentials.password = password.text;

        string playerCredentials = JsonUtility.ToJson(credentials);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body

        using (UnityWebRequest www = UnityWebRequest.Put(url + loginEndpoint, playerCredentials))
        {

            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + www.downloadHandler.text);

                player = JsonUtility.FromJson<PlayerToken>(www.downloadHandler.text); // player info

                // notify the player
                notification.Send($"Welcome {player.username}!");

                // save player info to PlayerPrefs

                PlayerPrefs.SetInt("player_id", player.player_id);

                // Fetch player information

                // QueryPlayerStatus(playerCredentials);

                // Fetch player items

                QueryPlayerItems(player.player_id);

                // Fetch player weapons 

                QueryPlayerWeapons(player.player_id);

                // load game scene

                yield return new WaitForSeconds(4);

                SceneManager.LoadScene("Main_menu");
            }
            else
            {
                Debug.Log("Error: " + www.error);
                string errorMessage = www.downloadHandler.text;
                notification.Send(errorMessage);
            }
        }
    }

    //private void QueryPlayerStatus(string playerCredentials)
    //{
    //    StartCoroutine(FetchPlayerInformation(playerCredentials));
    //}


    //IEnumerator FetchPlayerInformation(string playerCredentials)
    //{

    //}

    public void QueryPlayerItems(int player_id)
    {
        StartCoroutine(FetchPlayerItems(player_id));
    }

    IEnumerator FetchPlayerItems(int id)
    {

        using (UnityWebRequest www = UnityWebRequest.Get($"{url}{playerItemsEP}/{id}"))
        {

            www.method = "GET";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(UnityWebRequest.Result.Success);
                string jsonItems = "{\"playerItems\":" + www.downloadHandler.text + "}";

                Debug.Log(jsonItems);

                PlayerPrefs.SetString("items", jsonItems);
                
            }
            else
            {
                Debug.Log("Error: " + www.error);
                string errorMessage = www.downloadHandler.text;
                //notification.Send(errorMessage);
            }
        }
    }

    public void QueryPlayerWeapons(int player_id)
    {
        StartCoroutine(FetchPlayerWeapons(player_id));
    }

    IEnumerator FetchPlayerWeapons(int id)
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{url}{playerWeaponsEP}/{id}"))
        {

            www.method = "GET";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(UnityWebRequest.Result.Success);
                string jsonWeapons = "{\"playerWeapons\":" + www.downloadHandler.text + "}";

                Debug.Log("weapons here: " + jsonWeapons);

                PlayerPrefs.SetString("weapons", jsonWeapons);

            }
            else
            {
                Debug.Log("Error: " + www.error);
                string errorMessage = www.downloadHandler.text;
                //notification.Send(errorMessage);
            }
        }
    }
}
