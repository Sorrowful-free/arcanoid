using System;
using DataBases;
using DefaultNamespace;
using GamePlayFramework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace States.Main
{
    public partial class MainState
    {
        private Racket _racket;
        private void InitializeRacket(Vector2 position)
        {
            _racket = Object.Instantiate(
                    Resources.Load<GameObject>(
                        ResourcesNames.PrefabsNames.RACKET))
                .GetComponent<Racket>();
            _racket.OnCollisionEnter2DEvent += OnRacketCollisionEnter;
            _racket.transform.position = position;
        }

        private void OnRacketCollisionEnter(Collision2D collision2D)
        {
            var booster = collision2D.gameObject.GetComponent<Booster>();
            if(booster == null)
                return;

            foreach (var boosterEffect in booster.Data.Effects)
            {
                switch (boosterEffect.Type)
                {
                    case BoosterType.MakeCloneOfBall:
                        foreach (var ball in _balls.ToArray()) //make copy of balls
                        {
                            MakeBallsClone(ball,boosterEffect.Amount);
                        }
                        break;
                    case BoosterType.ChangeBallSpeed:
                        foreach (var ball in _balls.ToArray())//make copy of balls
                        {
                            ball.ApplyBoosterEffect(boosterEffect);
                        }
                        break;
                    
                    case BoosterType.ChangeRacketSize:
                        _racket.ApplyBoosterEffect(boosterEffect);
                        break;
                    
                    default:
                        break;
                }
            }
            DestroyBooster(booster);
        }

        private void MakeBallsClone(Ball original, int amount)
        {
            var balls = new Ball[amount + 1];
            balls[0] = original;
            for (int i = 0; i < amount; i++)
            {
                var cloneBall = CloneBall(original);
                balls[i + 1] = cloneBall;
            }

            for (int i = 0; i < amount+1; i++)
            {
                var alpha = ((float)i / (float)(amount + 1));
                var directionX = Mathf.Cos(Mathf.PI * alpha);
                var directionY = Mathf.Sin(Mathf.PI * alpha);
                balls[i].Throw(new Vector2(directionX,directionY));
            }
        }

        private void DeinitializeRacket()
        {
            _racket.OnCollisionEnter2DEvent -= OnRacketCollisionEnter;
            Object.Destroy(_racket.gameObject);
        }
    }
}