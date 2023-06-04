using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class UpdateResources : MonoBehaviour
{

    [SerializeField] string url;
    [SerializeField] string endpoint;

    public void QueryUpdate(string data)
    {
        StartCoroutine(UpdateResource(data));
    }

    IEnumerator UpdateResource(string data)
    {
        using (UnityWebRequest www = UnityWebRequest.Put(url + endpoint, data))
        {

            www.method = "PUT";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(UnityWebRequest.Result.Success);
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

