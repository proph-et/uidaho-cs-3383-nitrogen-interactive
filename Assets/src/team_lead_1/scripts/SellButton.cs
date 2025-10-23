using UnityEngine;
using UnityEngine.UI;

namespace src.team_lead_1.scripts
{
    public class SellButtonHandler : MonoBehaviour
    {
        private Button _myButton;
        public UIManager uiManager;

        void Awake()
        {
            _myButton = GetComponent<Button>();
            if (_myButton != null)
                _myButton.onClick.AddListener(OnButtonClick);

            uiManager = FindFirstObjectByType<UIManager>();
        }

        void OnButtonClick()
        {
            int value = 5;
            Debug.Log("item sold");
            if (uiManager != null)
                uiManager.SellItem(value);
        }
    }
}