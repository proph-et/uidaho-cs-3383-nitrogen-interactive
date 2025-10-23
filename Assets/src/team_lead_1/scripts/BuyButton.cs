using UnityEngine;
using UnityEngine.UI;

namespace src.team_lead_1.scripts
{
    public class BuyButtonHandler : MonoBehaviour
    {
        private Button _myButton;
        public UIManager uiManager;

        void Start()
        {
            _myButton = GetComponent<Button>();
            _myButton.onClick.AddListener(OnButtonClick);
            uiManager = FindFirstObjectByType<UIManager>();
        }

        void OnButtonClick()
        {
            int value = 5;
            Debug.Log("item purchased");
            uiManager.BuyItem(value);
        }
    }
}