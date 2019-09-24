using System;
using DataBases;
using UnityEngine;

namespace GamePlayFramework
{
    public class Ball : Interactable
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
            Debug.Log(direction);
            body.AddForceAtPosition(direction * Configs.BALL_THROW_SPEED, transform.position, ForceMode2D.Impulse);
            IsThrown = true;
        }
        
        private void MultiplySpeed(int amount)
        {
            var body = GetComponent<Rigidbody2D>();
            body.velocity *= amount;
        }
    }
}