using UnityEngine;
using UnityEngine.Events;
using TMPro;

// using Unity.VisualScripting;

namespace src.team_lead_1.scripts
{
    public class TMPTextBox : MonoBehaviour
    {
        public TextMeshProUGUI myTMPTextElement; // Drag your TextMeshProUGUI object here
        [SerializeField] public string initialText;

        void Awake()
        {
            myTMPTextElement = GetComponent<TextMeshProUGUI>();
            if (myTMPTextElement != null)
                myTMPTextElement.text = initialText;
        }

        public void ChangeTMPText(string newText)
        {
            if (myTMPTextElement != null)
                myTMPTextElement.text = newText;
        }
    }
}