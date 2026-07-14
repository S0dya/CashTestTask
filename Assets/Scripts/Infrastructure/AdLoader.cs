using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class AdLoader
    {
        private readonly Vector2 _adLoadingDuration = new(3, 5);
        
        private readonly MonoBehaviour _coroutineRunner;
        private bool _isAdLoaded;

        public AdLoader(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Init()
        {
            _isAdLoaded = false;

            _coroutineRunner.StartCoroutine(LoadAdCoroutine());
        }

        public bool TryShowAd()
        {
            if (_isAdLoaded == false)
            {
                Debug.Log("Реклама еще загружается...");
                return false;
            }

            Debug.Log("Реклама успешно показана");
            return true;
        }

        private IEnumerator LoadAdCoroutine()
        {
            Debug.Log("Начинаем загрузку рекламы");

            yield return new WaitForSeconds(Random.Range(_adLoadingDuration.x, _adLoadingDuration.y));

            _isAdLoaded = true;

            Debug.Log("Реклама загружена");
        }
    }
}