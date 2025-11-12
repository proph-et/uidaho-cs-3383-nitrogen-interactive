using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RangerManager : MonoBehaviour
{
    public Button ab201;
    public Button ab202;
    public Button ab203;
    public Button ab204;
    public Button ab205;
    public Button ab206;
    public Button ab207;
    public Button ab208;
    public Button ab209;
    private Ranger ranger;

    void Start()
    {
        ranger = new Ranger();

        ab201.onClick.AddListener(() => ranger.GetAb(201));
        ab202.onClick.AddListener(() => ranger.GetAb(202));
        ab203.onClick.AddListener(() => ranger.GetAb(203));
        ab204.onClick.AddListener(() => ranger.GetAb(204));
        ab205.onClick.AddListener(() => ranger.GetAb(205));
        ab206.onClick.AddListener(() => ranger.GetAb(206));
        ab207.onClick.AddListener(() => ranger.GetAb(207));
        ab208.onClick.AddListener(() => ranger.GetAb(208));
        ab209.onClick.AddListener(() => ranger.GetAb(209));
    }
    public Button GetButton(int ability)
    {
        switch (ability)
        {
            case 201:
                return ab201;
            case 202:
                return ab202;
            case 203:
                return ab203;
            case 204:
                return ab204;
            case 205:
                return ab205;
            case 206:
                return ab206;
            case 207:
                return ab207;
            case 208:
                return ab208;
            default:
                return null;
        }
    }

    private IEnumerator Visual(int ability, bool flag)
    {
        Button button = GetButton(ability);
        if (button == null)
        {
            yield break;
        }

        Color ogColor = button.image.color;
        if (flag == true)
        {
            button.image.color = Color.black;
        }
        else
        {
            button.image.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            button.image.color = ogColor;
        }
    }
}
