using UnityEngine;
using UnityEngine.UI;

public class FighterManager : MonoBehaviour
{
    public Button ab101;
    public Button ab102;
    public Button ab103;
    public Button ab104;
    public Button ab105;
    public Button ab106;
    public Button ab107;
    public Button ab108;
    public Button ab109;
    public Button ab110;
    public Button ab111;
    public Button ab112;
    private Fighter fighter;

    void Start()
    {
        fighter = new Fighter();

        ab101.onClick.AddListener(() => fighter.GetAb(101));
        ab102.onClick.AddListener(() => fighter.GetAb(102));
        ab103.onClick.AddListener(() => fighter.GetAb(103));
        ab104.onClick.AddListener(() => fighter.GetAb(104));
        ab105.onClick.AddListener(() => fighter.GetAb(105));
        ab106.onClick.AddListener(() => fighter.GetAb(106));
        ab107.onClick.AddListener(() => fighter.GetAb(107));
        ab108.onClick.AddListener(() => fighter.GetAb(108));
        ab109.onClick.AddListener(() => fighter.GetAb(109));
        ab110.onClick.AddListener(() => fighter.GetAb(110));
        ab111.onClick.AddListener(() => fighter.GetAb(111));
        ab112.onClick.AddListener(() => fighter.GetAb(112));
    }
}
