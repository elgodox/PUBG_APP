using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTournament : MonoBehaviour
{
    public Text textId;
    public Text textDate;

    public void SetText(string id, DateTime date)
    {
        textId.text = id;
        textDate.text = date.ToString();
    }
}
