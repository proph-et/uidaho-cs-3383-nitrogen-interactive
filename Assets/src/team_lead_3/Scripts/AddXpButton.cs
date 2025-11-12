using UnityEngine;
using UnityEngine.UI;

// this script was written by chatgpt entirely btw

public class AddXpButton : MonoBehaviour
{
    public SkillTree skillTree; // Drag your SkillTree GameObject here in the Inspector
    public int xpAmount = 50;    // How much XP this button gives

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("AddXpButton script must be attached to a Button GameObject!");
            return;
        }

        button.onClick.AddListener(AddXp);
    }

    private void AddXp()
    {
        if (skillTree != null)
        {
            // Get the LevelSystem from SkillTree
            var levelSystem = skillTree.GetLvlSystem();

            if (levelSystem != null)
            {
                levelSystem.AddXp(xpAmount);
                Debug.Log($"Added {xpAmount} XP!");
            }
            else
            {
                Debug.LogWarning("LevelSystem not found in SkillTree!");
            }
        }
        else
        {
            Debug.LogWarning("SkillTree reference not set on AddXpButton!");
        }
    }
}
