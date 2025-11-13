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
        ab201.onClick.AddListener(() => ChangeColor(ab201, 1));
        ab202.onClick.AddListener(() => ranger.GetAb(202));
        ab202.onClick.AddListener(() => ChangeColor(ab202, 2));
        ab203.onClick.AddListener(() => ranger.GetAb(203));
        ab203.onClick.AddListener(() => ChangeColor(ab203, 3));
        ab204.onClick.AddListener(() => ranger.GetAb(204));
        ab204.onClick.AddListener(() => ChangeColor(ab204, 4));
        ab205.onClick.AddListener(() => ranger.GetAb(205));
        ab205.onClick.AddListener(() => ChangeColor(ab205, 5));
        ab206.onClick.AddListener(() => ranger.GetAb(206));
        ab206.onClick.AddListener(() => ChangeColor(ab206, 6));
        ab207.onClick.AddListener(() => ranger.GetAb(207));
        ab207.onClick.AddListener(() => ChangeColor(ab207, 7));
        ab208.onClick.AddListener(() => ranger.GetAb(208));
        ab208.onClick.AddListener(() => ChangeColor(ab208, 8));
        ab209.onClick.AddListener(() => ranger.GetAb(209));
        ab209.onClick.AddListener(() => ChangeColor(ab209, 9));
    }
    public void ChangeColor(Button button, int req)
    {
        if (ranger.rangerLevel >= req)
        {
            button.image.color = Color.black;
        }
    }
}
