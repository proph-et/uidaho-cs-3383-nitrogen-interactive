using UnityEngine;

public class SMScript : MonoBehaviour
{
    [Header("Player Sounds")]
    [SerializeField] private AudioClip player_dash_clip;

    [Header("Enemy Sounds")]
    [SerializeField] private AudioClip enemy_defeated_clip;

    [Header("Item Sounds")]
    [SerializeField] private AudioClip collectable_clip;
    [SerializeField] private AudioClip powerup_clip;

    [Header("Background Music")]
    [SerializeField] private AudioClip background_clip;
    [SerializeField] private float background_volume = 1f;

    private AudioSource bgSource;
    private AudioSource sfxSource;

    private void Awake()
    {
        // Create one reusable SFX AudioSource
        sfxSource = gameObject.AddComponent<AudioSource>();
        
        // Create background audio source
        bgSource = gameObject.AddComponent<AudioSource>();
        bgSource.loop = true;
        bgSource.volume = background_volume;
    }

    private void Start()
    {
        BackgroundMusic();
    }

    // ------------------------
    // Background Music
    // ------------------------
    public void BackgroundMusic()
    {
        if (background_clip == null)
            return;

        bgSource.clip = background_clip;
        bgSource.Play();
    }

    public void pauseBackgroundMusic()
    {
        bgSource.Pause();
    }
    public void unpauseBackgroundMusic()
    {
        bgSource.UnPause();
    }

    // ------------------------
    //  One-Shot SFX
    // ------------------------
    public void DashSound()
    {
        if (player_dash_clip != null)
            sfxSource.PlayOneShot(player_dash_clip);
    }

    public void DefeatSound()
    {
        if (enemy_defeated_clip != null)
            sfxSource.PlayOneShot(enemy_defeated_clip);
    }

    public void CollectableSound()
    {
        if (collectable_clip != null)
            sfxSource.PlayOneShot(collectable_clip);
    }

    public void PowerupSound()
    {
        if (powerup_clip != null)
            sfxSource.PlayOneShot(powerup_clip);
    }
}

