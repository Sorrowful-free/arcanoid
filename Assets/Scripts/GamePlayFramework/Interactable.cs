using System;
using DataBases;
using UnityEngine;

namespace GamePlayFramework
{
    public abstract class Interactable : MonoBehaviour
    {
        public event Action<Collision2D> OnCollisionEnter2DEvent;

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollisionEnter2DEvent?.Invoke(other);
        }

        public abstract void ApplyBoosterEffect(BoosterEffect boosterEffect);
    }
}