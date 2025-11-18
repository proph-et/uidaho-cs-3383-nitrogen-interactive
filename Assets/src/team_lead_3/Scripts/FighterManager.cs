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
        ab101.onClick.AddListener(() => ChangeColor(ab101, 1));
        ab102.onClick.AddListener(() => fighter.GetAb(102));
        ab102.onClick.AddListener(() => ChangeColor(ab102, 2));
        ab103.onClick.AddListener(() => fighter.GetAb(103));
        ab103.onClick.AddListener(() => ChangeColor(ab103, 3));
        ab104.onClick.AddListener(() => fighter.GetAb(104));
        ab104.onClick.AddListener(() => ChangeColor(ab104, 4));
        ab105.onClick.AddListener(() => fighter.GetAb(105));
        ab105.onClick.AddListener(() => ChangeColor(ab105, 5));
        ab106.onClick.AddListener(() => fighter.GetAb(106));
        ab106.onClick.AddListener(() => ChangeColor(ab106, 6));
        ab107.onClick.AddListener(() => fighter.GetAb(107));
        ab107.onClick.AddListener(() => ChangeColor(ab107, 7));
        ab108.onClick.AddListener(() => fighter.GetAb(108));
        ab108.onClick.AddListener(() => ChangeColor(ab108, 8));
        ab109.onClick.AddListener(() => fighter.GetAb(109));
        ab109.onClick.AddListener(() => ChangeColor(ab109, 9));
        ab110.onClick.AddListener(() => fighter.GetAb(110));
        ab110.onClick.AddListener(() => ChangeColor(ab110, 10));
        ab111.onClick.AddListener(() => fighter.GetAb(111));
        ab111.onClick.AddListener(() => ChangeColor(ab111, 11));
        ab112.onClick.AddListener(() => fighter.GetAb(112));
        ab112.onClick.AddListener(() => ChangeColor(ab112, 12));
    }

    private void ChangeColor(Button button, int req)
    {
        if (fighter.fighterLevel >= req)
        {
            button.image.color = Color.black;
        }
    }
}
