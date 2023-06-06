using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    [SerializeField] TMP_Text notificationText;

    public void Send(string message)
    {
        gameObject.SetActive(true);
        notificationText.text = message;
        Invoke("DisableNotification", 4);
    }

    private void DisableNotification()
    {
        gameObject.SetActive(false);
        notificationText.text = null;
    }
}
