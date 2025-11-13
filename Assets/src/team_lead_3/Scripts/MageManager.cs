using UnityEngine;
using UnityEngine.UI;

public class MageManager : MonoBehaviour
{
    public Button ab301;
    public Button ab302;
    public Button ab303;
    public Button ab304;
    public Button ab305;
    public Button ab306;
    public Button ab307;
    public Button ab308;
    private Mage mage;


    void Start()
    {
        mage = new Mage();

        ab301.onClick.AddListener(() => mage.GetAb(301));
        ab301.onClick.AddListener(() => ChangeColor(ab301, 1));
        ab302.onClick.AddListener(() => mage.GetAb(302));
        ab302.onClick.AddListener(() => ChangeColor(ab302, 2));
        ab303.onClick.AddListener(() => mage.GetAb(303));
        ab303.onClick.AddListener(() => ChangeColor(ab303, 3));
        ab304.onClick.AddListener(() => mage.GetAb(304));
        ab304.onClick.AddListener(() => ChangeColor(ab304, 4));
        ab305.onClick.AddListener(() => mage.GetAb(305));
        ab305.onClick.AddListener(() => ChangeColor(ab305, 5));
        ab306.onClick.AddListener(() => mage.GetAb(306));
        ab306.onClick.AddListener(() => ChangeColor(ab306, 6));
        ab307.onClick.AddListener(() => mage.GetAb(307));
        ab307.onClick.AddListener(() => ChangeColor(ab307, 7));
        ab308.onClick.AddListener(() => mage.GetAb(308));
        ab308.onClick.AddListener(() => ChangeColor(ab308, 8));
    }

    public void ChangeColor(Button button, int req)
    {
        if (mage.mageLevel >= req)
        {
            button.image.color = Color.black;
        }
    }
}
