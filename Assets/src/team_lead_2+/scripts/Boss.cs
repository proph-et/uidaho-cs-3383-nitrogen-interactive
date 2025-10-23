using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private BossAI BossAi;

    private bool isActive = false;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }


    private void Awake()
    {
        if (BossAi == null)
            GetComponent<BossAI>();

        BossAi.Initialize(this);
        BossAi.enabled = false;
    }

    private void Update()
    {
        if(!isActive && PlayerEnteredBossLevel())
        {
            ActivateBoss();
        }
    }

    private bool PlayerEnteredBossLevel()
    {
        return Vector3.Distance(player.position, transform.position) < 20f;
    }

    private void ActivateBoss()
    {
        isActive = true;
        BossAi.enabled = true;
        Debug.Log("Boss AI Activated!");
    }
}
