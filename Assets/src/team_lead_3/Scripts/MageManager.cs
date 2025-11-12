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
        ab302.onClick.AddListener(() => mage.GetAb(302));
        ab303.onClick.AddListener(() => mage.GetAb(303));
        ab304.onClick.AddListener(() => mage.GetAb(304));
        ab305.onClick.AddListener(() => mage.GetAb(305));
        ab306.onClick.AddListener(() => mage.GetAb(306));
        ab307.onClick.AddListener(() => mage.GetAb(307));
        ab308.onClick.AddListener(() => mage.GetAb(308));
    }
}
