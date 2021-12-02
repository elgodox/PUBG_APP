using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    public string textForLoading;
    public string textForError;
    
    public Text loadingText;
    public GameObject scrollPanel, scroll;
    private ObjectTournament _objectTournament;

    private void Awake()
    {
        scroll.gameObject.SetActive(false);
        _objectTournament = Resources.Load<ObjectTournament>("Tournament");
    }


    public void ShowLoadingText(bool active)
    {
        loadingText.text = textForLoading;
        loadingText.gameObject.SetActive(active);
        if(!active)
            scroll.gameObject.SetActive(true);
    }

    public void ShowErrorText(bool active)
    {
        loadingText.text = textForError;
        loadingText.gameObject.SetActive(active);
    }

    public void AddItemToScrollPanel<T>(T gameObject)
    {
        Tournament tournament = gameObject as Tournament;
        _objectTournament.SetText(tournament.id , tournament.attributes.createdAt);
        Instantiate(_objectTournament, scrollPanel.transform);
    }
}