using System;

namespace ViewControllers
{
    public class MenuViewController : BaseViewController
    {
        public event Action OnPlayClicked;
        public event Action OnExitClicked;
        
        public void OnPlayClick()
        {
            OnPlayClicked?.Invoke();
        }

        public void OnExitClick()
        {
            OnExitClicked?.Invoke();
        }
    }
}