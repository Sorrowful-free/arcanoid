using ViewControllers;

namespace States
{
    public abstract class BaseState
    {
        public virtual void EnterState(params object[] enterArgs)
        {
        }

        public virtual void ExitState()
        {
        }
        
        public virtual void Update()
        {
            
        }
    }

    public abstract class BaseState<TViewController> : BaseState where TViewController : BaseViewController
    {
        public GameApplication GameApplication { get; }
        public TViewController ViewController { get; }

        protected BaseState(GameApplication gameApplication, TViewController viewController)
        {
            GameApplication = gameApplication;
            ViewController = viewController;
        }

        public override void EnterState(params object[] enterArgs)
        {
            base.EnterState(enterArgs);
            ViewController.Show();
        }

        public override void ExitState()
        {
            base.ExitState();
            ViewController.Hide();
        }

        
    }
}