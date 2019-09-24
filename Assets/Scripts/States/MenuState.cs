#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using ViewControllers;

namespace States
{
    public class MenuState : BaseState<MenuViewController>
    {
        public MenuState(GameApplication gameApplication, MenuViewController viewController) : base(gameApplication,
            viewController)
        {
        }

        public override void EnterState(params object[] enterArgs)
        {
            base.EnterState(enterArgs);
            ViewController.OnPlayClicked += OnPlayClicked;
            ViewController.OnExitClicked += OnExitClicked;
        }

        public override void ExitState()
        {
            base.ExitState();
            ViewController.OnPlayClicked -= OnPlayClicked;
            ViewController.OnExitClicked -= OnExitClicked;
        }

        private void OnPlayClicked()
        {
            GameApplication.SetState(GameApplicationStateType.Transition, 
                GameApplicationStateType.Main,
                new object[] {Configs.CHEAT_STASRT_LEVEL_INDEX});
        }

        private void OnExitClicked()
        {
            Application.Quit(0);
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}