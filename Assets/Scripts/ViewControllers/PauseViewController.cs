using System;

namespace ViewControllers
{
    public class PauseViewController : BaseViewController
    {
        public event Action OnMenuClicked;
        public event Action OnRestartClicked;

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