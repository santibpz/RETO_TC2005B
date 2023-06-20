using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InsertWeaponUpgrade : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string endpoint;

    public void QueryUpgrade(string data)
    {
        StartCoroutine(AddUpgrade(data));
    }


    IEnumerator AddUpgrade(string data)
    {
        Debug.Log("death type info being sent: " + data);

        using (UnityWebRequest www = UnityWebRequest.Put(url + endpoint, data))
        {

            www.method = "POST";
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
