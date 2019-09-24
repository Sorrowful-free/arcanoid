namespace States.Main
{
    public partial class MainState
    {
        private void BindPauseViewController()
        {
            ViewController.PauseViewController.OnMenuClicked += OnMenuClicked;
            ViewController.PauseViewController.OnRestartClicked += OnRestartClicked;
        }

        private void UnbindPauseViewController()
        {
            ViewController.PauseViewController.OnMenuClicked -= OnMenuClicked;
            ViewController.PauseViewController.OnRestartClicked -= OnRestartClicked;
        }
        private void OnRestartClicked()
        {
            GameApplication.SetState(GameApplicationStateType.Transition, GameApplicationStateType.Main, new object[] {_levelIndex});
        }

        private void OnMenuClicked()
        {
            GameApplication.SetState(GameApplicationStateType.Transition, GameApplicationStateType.Menu);
        }
    }
}