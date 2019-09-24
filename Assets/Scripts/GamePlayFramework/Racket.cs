using System;
using DataBases;
using UnityEngine;

namespace GamePlayFramework
{
    public class Racket : Interactable
    {
        public Vector2 Size
        {
            get => GetComponent<SpriteRenderer>().size;
            set => GetComponent<SpriteRenderer>().size = GetComponent<BoxCollider2D>().size = value;
        }

        public override void ApplyBoosterEffect(BoosterEffect boosterEffect)
        {
            switch (boosterEffect.Type)
            {
                case BoosterType.ChangeRacketSize:
                    MultiplySize(boosterEffect.Amount);
                    break;
                
                default:
                    break;
            }
        }

        private void MultiplySize(int amount)
        {
            var size = Size;
            size.x *= amount;
            Size = size;
        }
    }
}