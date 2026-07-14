using System.Collections;
using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PaywallView : MonoBehaviour
    {
        [SerializeField] private ButtonPulseAnimation buttonPulseAnimation;
        [SerializeField] private Button showAdButton;
        [SerializeField] private CanvasGroup paywallCg;
        [Space]
        [SerializeField] private float fadeDuration = 0.1f;

        private Coroutine _fadeCoroutine;

        private void Awake()
        {
            paywallCg.alpha = 0f;
        }

        public void Init(AdLoader adLoader)
        {
            showAdButton.onClick.AddListener(() => ShowAdPressed(adLoader));
        }

        public void Show()
        {
            StartFade(1f);

            buttonPulseAnimation.Play();
        }

        public void Hide()
        {
            StartFade(0f);

            buttonPulseAnimation.Stop();
        }

        private void ShowAdPressed(AdLoader adLoader)
        {
            if (adLoader.TryShowAd())
            {
                // Hide();
            }
        }

        private void StartFade(float targetAlpha)
        {
            if (_fadeCoroutine != null) StopCoroutine(_fadeCoroutine);

            _fadeCoroutine = StartCoroutine(FadeCoroutine(targetAlpha));
        }

        private IEnumerator FadeCoroutine(float targetAlpha)
        {
            float elapsed = 0f;
            float startAlpha = paywallCg.alpha;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                float progress = Mathf.Clamp01(elapsed / fadeDuration);
                paywallCg.alpha = Mathf.Lerp(startAlpha, targetAlpha, progress);

                yield return null;
            }

            paywallCg.alpha = targetAlpha;
            _fadeCoroutine = null;
        }

        private void OnDestroy()
        {
            showAdButton.onClick.RemoveAllListeners();
        }
    }
}