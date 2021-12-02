using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class RestManager : MonoBehaviour
{
    public Action<bool> OnObtainingData;
    public Action<bool> OnObtainError;
    public Action<Tournament> OnObtainTournament;


    public void OnButtonPressed()
    {
        StartCoroutine(GetData());
    }

    public IEnumerator GetData()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("accept", "application/vnd.api+json");
        headers.Add("Authorization",
            "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI1MGQzZWJhMC0zNDVmLTAxM2EtNzE1ZC0wOWQzZTk3ZDU4YzYiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjM4MzEzMjYzLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InB1Ymd0cyJ9.L9NPkJa5RaSFCDfRF3bxtVvfoRTL1UMEBEF01O9KFZI");

        UnityWebRequest www = UnityWebRequest.Get("https://api.pubg.com/tournaments");

        foreach (var item in headers)
        {
            www.SetRequestHeader(item.Key, item.Value);
        }
        OnObtainingData.Invoke(true);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            OnObtainError.Invoke(true);
        }
        else
        {
            OnObtainingData.Invoke(false);
            var counter = 0;
            var deserializer = new TournamentJsonDeserializer();
            var rData =deserializer.Deserialize(www.downloadHandler.text);
            foreach (var item in rData.data)
            {
                OnObtainTournament.Invoke(item);
            }
        }
    }
}



