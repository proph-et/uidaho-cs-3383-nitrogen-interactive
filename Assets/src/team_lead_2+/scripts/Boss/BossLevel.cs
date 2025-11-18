using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private Health health;
    [SerializeField] private BossAbilities abilities;
    [SerializeField] private BossMovement movement;
    [SerializeField] private CooldownManagerBoss cooldowns;
    [SerializeField] private BossCombat combat;
    [SerializeField] private Animator animator;

    [Header("Boss Phase thresholds as %")]
    [Range(0f, 1f)][SerializeField] private float phase2AtHp = 0.68f;
    [Range(0f, 1f)][SerializeField] private float phase3AtHp = 0.34f;

    private BossPhase _currentphase;

    // Public read-only for the BehaviorPath calculations 
    public BossAbilities Abilities => abilities;
    public Transform Player => player;
    public Health Health => health;
    public BossMovement Movement => movement;
    public CooldownManagerBoss Cooldowns => cooldowns;
    public BossCombat Combat => combat;
    public Animator Animator => animator;

    private void Awake()
    {
        if (abilities == null) abilities = GetComponent<BossAbilities>();
        if (movement == null) movement = GetComponent<BossMovement>();
        if (cooldowns == null) cooldowns = GetComponent<CooldownManagerBoss>();
        if (combat == null) combat = GetComponent<BossCombat>();
        if (animator == null) animator = GetComponentInChildren<Animator>();
        if (health == null) health = GetComponent<Health>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        //need animation and sonds to play for die and onBossDamage
        health.AddOnDeathListener(Die);

        abilities.Init(this);

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

    public void Die()
    {
        Debug.Log("Boss died");
        //add animation here
        Movement?.StopMoving();
        enabled = false;
        StopAllCoroutines();
        _currentphase = null;

        Animator.SetTrigger("Bossdead");

        StartCoroutine(FinishDeath());

        Destroy(player.gameObject);

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

        Debug.Log("You won the Game!");
    }

    private IEnumerator FinishDeath()
    {
        yield return null;

        var info = Animator.GetCurrentAnimatorStateInfo(0);
        float animLength = info.length;

        if (animLength > 0.1f) { animLength = 2f; }

        yield return new WaitForSeconds(animLength);

        Debug.Log("Boss death animation done");
    }
}
