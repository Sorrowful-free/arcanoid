using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Extensions;
using GamePlayFramework;
using UnityEngine;

namespace States.Main
{
    public partial class MainState
    {
        private List<Ball> _balls = new List<Ball>();

        private void InitializeBalls()
        {
            var ball = SpawnBall(Vector2.zero);
            var ballTransform = ball.transform;
            ballTransform.SetParent(_racket.transform, false);
            ballTransform.position += Vector3.up * Configs.RACKET_SIZE_HEIGHT;
        }

        private void DeinitializeBalls()
        {
            while (_balls.Count > 0)
            {
                DestroyBall(_balls.First());
            }
        }

        private Ball SpawnBall(Vector2 position)
        {
            var ball = Object.Instantiate(
                    Resources.Load<GameObject>(
                        ResourcesNames.PrefabsNames.BALL
                    )
                )
                .GetComponent<Ball>();
            _balls.Add(ball);
            ball.transform.position = position;
            ball.OnCollisionEnter2DEvent += OnBallCollisionEnter2D;
            return ball;
        }

        private Ball CloneBall(Ball originalBall)
        {
            var cloneBall = Object.Instantiate(originalBall.gameObject).GetComponent<Ball>();
            _balls.Add(cloneBall);
            cloneBall.OnCollisionEnter2DEvent += OnBallCollisionEnter2D;
            return cloneBall;
        }

        private void OnBallCollisionEnter2D(Collision2D collision2D)
        {
            var block = collision2D.gameObject.GetComponent<Block>();
            var wall = collision2D.gameObject.GetComponent<Wall>();


            if (block != null && --block.CurrentLives <= 0)
            {
                if (block.Data.IsSpawnBooster)
                    SpawnBooster(block.transform.position, _levelBoosterDatas.GetRandomElement());
                DestroyBlock(block);
                if (_blocks.Count <= 0)
                {
                    if(_levelIndex < GameApplication.LevelsDataBase.Levels.Length-1)
                        GameApplication.SetState(GameApplicationStateType.Transition, GameApplicationStateType.Main,
                            new object[] {_levelIndex+1});
                    else
                        GameApplication.SetState(GameApplicationStateType.Transition, GameApplicationStateType.GameOver,
                            new object[] {_levelIndex, false});
                }
            }

            if (!Configs.CHEAT_NEWER_LOSE && wall != null && wall == _bottomWall)
            {
                GameApplication.SetState(GameApplicationStateType.Transition, GameApplicationStateType.GameOver,
                    new object[] {_levelIndex, true});
            }
            
            var ball = collision2D.otherCollider.GetComponent<Ball>();
            if (ball != null)
            {
                ball.ApplySimpleRandom();   
                Debug.Log("random");
            }
            
        }

        private void DestroyBall(Ball ball)
        {
            if (_balls.Remove(ball))
            {
                ball.OnCollisionEnter2DEvent -= OnBallCollisionEnter2D;
                Object.Destroy(ball.gameObject);
            }
        }
    }
}