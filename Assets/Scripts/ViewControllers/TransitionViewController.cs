using System;
using UnityEngine;

namespace ViewControllers
{
    public class TransitionViewController : BaseViewController
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration = 0.5f;

        private float _targetAlpha = 1;
        private Action _onDone;

        public void FadeIn(Action onDone)
        {
            _onDone = onDone;
            _targetAlpha = 1;
            if (_targetAlpha == _canvasGroup.alpha)
                _onDone?.Invoke();
        }

        public void FadeOut(Action onDone)
        {
            _onDone = onDone;
            _targetAlpha = 0;
            if (_targetAlpha == _canvasGroup.alpha)
                _onDone?.Invoke();
        }

        private void Update()
        {
            if (_targetAlpha == _canvasGroup.alpha)
                return;

            var alpha = _canvasGroup.alpha;
            var direction = _targetAlpha - alpha;

            alpha = Mathf.Clamp01(alpha +
                                  (direction > 0
                                      ? (Time.deltaTime / _fadeDuration)
                                      : -(Time.deltaTime / _fadeDuration)));
            _canvasGroup.alpha = alpha;
            if (alpha == 1 || alpha == 0)
                _onDone?.Invoke();
        }
    }
}