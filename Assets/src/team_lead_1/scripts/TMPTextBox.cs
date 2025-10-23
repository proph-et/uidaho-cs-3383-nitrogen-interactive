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

        void Start()
        {
            if (myTMPTextElement != null)
                myTMPTextElement.text = initialText;
        }

        public void ChangeTMPText(string newText)
        {
            myTMPTextElement.text = newText;
        }
    }
}