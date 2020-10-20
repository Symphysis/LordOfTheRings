using TMPro;
using UnityEngine;

namespace Hud
{
    public class GoldPress : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldPressText;
        [SerializeField] TextMeshProUGUI goldPressCostText;
        int _goldPressesOwned;

        public int GoldPressesOwned
        {
            get => _goldPressesOwned;
            set
            {
                _goldPressesOwned = value;
                PlayerPrefs.SetInt("GoldPress", value);
                goldPressText.text = $"GD owned: {value}";
            }
        }

        void Start()
        {
            GoldPressesOwned = PlayerPrefs.GetInt("GoldPress", GoldPressesOwned);
        }

        void OnDestroy()
        {
            PlayerPrefs.SetInt("GoldPress", GoldPressesOwned);
        }

        public void GoldPressIncrement()
        {
            foreach (var product in GetComponent<Hud>().products)
            {
                if (product.name != Names.GoldPress) continue;

                HudServices.HideProductInfo();
                if (GetComponent<Gold>().CurrentGold < product.cost) return;

                GoldPressesOwned += 1;
                GetComponent<Gold>().CurrentGold -= product.cost;
            }
        }
    }
}