using UnityEngine;

public class BossLevel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private Health health;

    [Header("Boss Phase thresholds as %")]
    [Range(0f, 1f)][SerializeField] private float phase2AtHp = 0.68f;
    [Range(0f, 1f)][SerializeField] private float phase3AtHp = 0.34f;

    [SerializeField] private BossAbilities abilities;

    public BossAbilities Abilities => abilities;
    private BossPhase _currentphase;

    // Public read-only for the BehaviorPath calculations 
    public Transform Player => player;
    public Health Health => health;

    private void Awake()
    {
        if (abilities == null)
        {
            abilities = GetComponent<BossAbilities>();
        }
        if (health == null)
        {
            health = GetComponent<Health>();
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        //need animation and sonds to play for die and onBossDamage
        health.AddOnDeathListener(Die);
        health.AddOnDamageListener(OnBossDamaged);

        //init phase 1
        var p1 = new Phase1();
        p1.Init(this);
        _currentphase = p1;
    }

    private void Update()
    {
        _currentphase?.UpdateBehavior(player);
        CheckPhaseTransitions();
    }

    private void CheckPhaseTransitions()
    {
        float hpRatio = health.GetHealthRatio();

        if (_currentphase is Phase1 && hpRatio < phase2AtHp)
        {
            var p2 = new Phase2();
            p2.Init(this);
            _currentphase = p2;
            Debug.Log("Switched to Phase2");
        }
        else if (_currentphase is Phase2 && hpRatio < phase3AtHp)
        {
            var p3 = new Phase3();
            p3.Init(this);
            _currentphase = p3;
            Debug.Log("Switched to Phase3");
        }
    }

    private void Die()
    {
        //add animations and sound
        Debug.Log("Boss died");
        enabled = false;
    }

    private void OnBossDamaged(float dmg)
    {
        //add animations and sound
        Debug.Log($"Boss took {dmg} damage");
    }
}
