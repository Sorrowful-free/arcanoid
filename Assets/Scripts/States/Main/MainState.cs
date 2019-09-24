using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using GamePlayFramework;
using UnityEngine;
using ViewControllers;

namespace States.Main
{
    public partial class MainState : BaseState<MainViewController>
    {
        private bool _isPause;


        public MainState(GameApplication gameApplication, MainViewController viewController) : base(gameApplication,
            viewController)
        {
        }

        public override void EnterState(params object[] enterArgs)
        {
            base.EnterState(enterArgs);

            BindPauseViewController();

            InitializeRacket(new Vector2(0, -Configs.LEVEL_WALLS_HEIGHT / 2 + Configs.RACKET_SIZE_HEIGHT));
            InitializeBalls();
            InitializeLevel((int) enterArgs[0]);
            InitializeBlocks();
        }

        public override void ExitState()
        {
            base.ExitState();
            UnbindPauseViewController();
            DeinitializeBlocks();
            DeinitializeLevel();
            DeinitializeBalls();
            DeinitializeRacket();
        }

        public override void Update()
        {
            base.Update();
            if (Input.GetButtonDown("Pause"))
            {
                _isPause = !_isPause;
                if (_isPause)
                    ViewController.PauseViewController.Show();
                else
                    ViewController.PauseViewController.Hide();
            }

            if (Input.GetButtonDown("ThrowBall"))
            {
                foreach (var ball in _balls.Where(e => !e.IsThrown))
                {
                    ball.Throw(new Vector2(Random.Range(-1, 1), 1).normalized);
                }
            }

            if (Input.GetButtonDown("ReThrowBall"))
            {
                foreach (var ball in _balls.Where(e => e.IsThrown))
                {
                    ball.Throw(new Vector2(Random.Range(-1.0f, 1.0f), 1.0f).normalized);
                }
            }

            var horizontal = Input.GetAxis("Horizontal");
            var racketTransform = _racket.transform;
            var racketPosition = racketTransform.position;
            var racketSize = _racket.Size;
            racketPosition.x = Mathf.Clamp(racketPosition.x + horizontal * Configs.RACKET_SPEED * Time.deltaTime,
                -Configs.LEVEL_WALLS_WIDTH / 2 + racketSize.x / 2,
                Configs.LEVEL_WALLS_WIDTH / 2 - racketSize.x / 2);
            racketTransform.position = racketPosition;
        }
    }
}