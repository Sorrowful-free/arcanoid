using System;
using UnityEngine;

namespace GamePlayFramework
{
    public abstract class Collidable : MonoBehaviour
    {
        public event Action<Collision2D> OnCollisionEnter2DEvent;

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollisionEnter2DEvent?.Invoke(other);
        }
    }
}