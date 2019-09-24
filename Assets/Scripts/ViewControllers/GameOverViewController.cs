using System;
using UnityEngine;
using UnityEngine.UI;

namespace ViewControllers
{
    
    public class GameOverViewController : BaseViewController
    {
        [SerializeField] private Button _restartButton;
        public event Action OnMenuClicked;
        public event Action OnRestartClicked;

        public bool AvailableRestartButton
        {
            get => _restartButton.gameObject.activeSelf;
            set => _restartButton.gameObject.SetActive(value);
        }
        
        public void OnMenuClick()
        {
            OnMenuClicked?.Invoke();
        }

        public void OnRestartClick()
        {
            OnRestartClicked?.Invoke();
        }
    }
}