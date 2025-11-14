using UnityEngine;
using TMPro;

public class SkillPointDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text skillPointsText;

    void Start()
    {
        // If you forget to assign the TMP text in the inspector, auto-grab it
        if (skillPointsText == null)
            skillPointsText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        skillPointsText.text = LevelSystem.Instance.skillPoint.ToString() + " SP";
    }
}
