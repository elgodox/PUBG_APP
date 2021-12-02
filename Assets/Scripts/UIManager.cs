using System;
using UnityEngine;

    public class UIManager: MonoBehaviour
    {
        private RestManager _restManager;
        private PanelControl _panel;
        private void Awake()
        {
            _restManager = FindObjectOfType<RestManager>();
            _panel = FindObjectOfType<PanelControl>();

            if (_restManager)
            {
                _restManager.OnObtainingData += _panel.ShowLoadingText;
                _restManager.OnObtainError += _panel.ShowErrorText;
                _restManager.OnObtainTournament += _panel.AddItemToScrollPanel;
            }
        }

    }
