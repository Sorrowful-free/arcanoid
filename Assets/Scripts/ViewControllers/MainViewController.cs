using UnityEngine;
using UnityEngine.UI;

namespace ViewControllers
{
    public class MainViewController : BaseViewController
    {
        [SerializeField] private Text _timeText;
        public float Time { get; set; }
        
        [SerializeField] private PauseViewController _pauseViewController;
        public PauseViewController PauseViewController => _pauseViewController;

        public override void Hide()
        {
            base.Hide();
            PauseViewController.Hide();
        }
    }
}