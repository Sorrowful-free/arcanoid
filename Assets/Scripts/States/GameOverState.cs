using ViewControllers;

namespace States
{
    public class GameOverState : BaseState<GameOverViewController>
    {
        private int _levelIndex;

        public GameOverState(GameApplication gameApplication, GameOverViewController viewController) : base(
            gameApplication, viewController)
        {
        }

        public override void EnterState(params object[] enterArgs)
        {
            base.EnterState(enterArgs);
            _levelIndex = (int) enterArgs[0];
            ViewController.AvailableRestartButton = (bool) enterArgs[1];
            ViewController.OnMenuClicked += OnMenuClicked;
            ViewController.OnRestartClicked += OnRestartClicked;
        }

        public override void ExitState()
        {
            base.ExitState();
            ViewController.OnMenuClicked -= OnMenuClicked;
            ViewController.OnRestartClicked -= OnRestartClicked;
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