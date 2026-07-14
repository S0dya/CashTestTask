using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PaywallView paywallView;
        
        private void Start()
        {
            AdLoader adLoader = new(this);

            paywallView ??= FindObjectOfType<PaywallView>();

            adLoader.Init();
            paywallView.Init(adLoader);
            
            paywallView.Show();
        }
    }
}