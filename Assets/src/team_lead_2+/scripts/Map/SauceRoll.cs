using UnityEngine;

public class SauceRoll : MonoBehaviour
{
    [SerializeField] private float rollspeed = 0.2f;
    private Renderer rend;
    private Vector2 offset = Vector2.zero;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        offset.y += Time.deltaTime * rollspeed;
        rend.material.SetTextureOffset("_BaseMap", offset);
        rend.material.SetTextureOffset("_MainTex", offset);
    }
}
