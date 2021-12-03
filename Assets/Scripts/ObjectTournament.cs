using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTournament : MonoBehaviour
{
    public Text textId;
    public Text textDate;


    public void SetText(string id, DateTime date)
    {
        textId.text = id;
        textDate.text = date.ToString(CultureInfo.CurrentCulture);
    }

    public void Clicked()
    {
        var _panelSelected = FindObjectOfType<PanelSelected>();
        _panelSelected.ShowTournament(this);
    }
}
