using System;
using DataBases;
using UnityEngine;
using Random = System.Random;

namespace GamePlayFramework
{
    public class Ball : CollidableAndBoostable
    {
        public override void ApplyBoosterEffect(BoosterEffect boosterEffect)
        {
            switch (boosterEffect.Type)
            {
                case BoosterType.ChangeBallSpeed:
                    MultiplySpeed(boosterEffect.Amount);
                    break;
                default:
                    break;
            }
        }

        public bool IsThrown { get; private set; }

        public void Throw(Vector2 direction)
        {
            transform.SetParent(null);
            var body = GetComponent<Rigidbody2D>(); //because rigidbody is reserved name
            body.velocity = Vector2.zero;
            body.isKinematic = false;
            body.AddForceAtPosition(direction * Configs.BALL_THROW_SPEED, transform.position, ForceMode2D.Impulse);
            IsThrown = true;
        }

        public void ApplySimpleRandom()
        {
            var body = GetComponent<Rigidbody2D>();
            var velocity = body.velocity;
            var scalarVelocity = velocity.magnitude;

            var velocityDirection = velocity.normalized;
            velocityDirection.x += UnityEngine.Random.Range(-Configs.BALL_RANDOM_FORCE, Configs.BALL_RANDOM_FORCE);
            velocityDirection.y += UnityEngine.Random.Range(-Configs.BALL_RANDOM_FORCE, Configs.BALL_RANDOM_FORCE);
            body.velocity = velocityDirection.normalized * scalarVelocity;
        }
        
        private void MultiplySpeed(int amount)
        {
            var body = GetComponent<Rigidbody2D>();
            body.velocity *= amount;
        }
    }
}