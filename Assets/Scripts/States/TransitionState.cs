using ViewControllers;

namespace States
{
    public class TransitionState : BaseState<TransitionViewController>
    {
        public TransitionState(GameApplication gameApplication, TransitionViewController viewController) : base(
            gameApplication, viewController)
        {
        }

        public override void EnterState(params object[] enterArgs)
        {
            base.EnterState(enterArgs);
            var nextState = (GameApplicationStateType) enterArgs[0];
            var nextStateEnterArgs = enterArgs.Length>1?(object[]) enterArgs[1]:new object[]{};
            ViewController.FadeIn(() =>
            {
                GameApplication.SetState(nextState, nextStateEnterArgs);
                ViewController.FadeOut(()=> ViewController.Hide());
            });
        }

        public override void ExitState()
        {
            //base.ExitState(); it is need for disable auto hiding of view controller 
        }
    }
}