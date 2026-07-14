using System.Collections;
using UnityEngine;

namespace UI
{
    public class ButtonPulseAnimation : MonoBehaviour
    {
        [SerializeField] private float animationDuration = 0.8f;
        [SerializeField] private float maxScale = 1.1f;

        private Coroutine _pulseCoroutine;

        public void Play()
        {
            Stop();

            _pulseCoroutine = StartCoroutine(PulseCoroutine());
        }

        public void Stop()
        {
            if (_pulseCoroutine != null) StopCoroutine(_pulseCoroutine);

            transform.localScale = Vector2.one;
        }

        private IEnumerator PulseCoroutine()
        {
            Vector2 initialScale = Vector2.one;
            Vector2 targetScale = Vector2.one * maxScale;

            while (true)
            {
                float timer = 0f;

                while (timer < animationDuration)
                {
                    timer += Time.deltaTime;
                    float progress = timer / animationDuration;
                    transform.localScale = Vector2.Lerp(initialScale, targetScale, Mathf.SmoothStep(0f, 1f, progress));

                    yield return null;
                }

                timer = 0f;

                while (timer < animationDuration)
                {
                    timer += Time.deltaTime;
                    float progress = timer / animationDuration;
                    transform.localScale = Vector2.Lerp(targetScale, initialScale, Mathf.SmoothStep(0f, 1f, progress));

                    yield return null;
                }
            }
        }
    }
}