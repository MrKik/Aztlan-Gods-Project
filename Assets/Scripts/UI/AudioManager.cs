using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource walkCualli;
    public AudioSource runCualli;
    public AudioSource attackCualli;
    public AudioSource dashCualli;
    public AudioSource walkSoldier;
    public AudioSource attackSoldier;
    public AudioSource uiButton;
    public AudioSource pauseButton;
    public AudioSource damageCualli;
    public AudioSource damageSoldier;
    public AudioSource cacaoPick;
    public AudioSource deathCualli;
    public AudioSource healCualli;
    public AudioSource superCacaoPick;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // sounds of Cualli
    public void PlayWalkCualli()
    {
        //walkCualli.Stop();
        walkCualli.pitch = 0.79f;
        walkCualli.Play();
    }

    public void StopWalkCualli()
    {
        walkCualli.Stop();
    }

    public void PlayRunCualli()
    {
        //walkCualli.Stop();
        walkCualli.pitch = 1.0f;
        walkCualli.Play();
    }

    public void PlayAttackCualli()
    {
        attackCualli.Play();
    }

    public void PlayDashCualli()
    {
        dashCualli.Play();
    }

    public void PlayDeathCualli()
    {
        deathCualli.Play();
    }

    public void PlayHealCualli()
    {
        healCualli.Play();
    }

    public void PlayDamageCualli()
    {
        damageCualli.Play();
    }

    // sounds of the enemy soldier
    public void PlayWalkSoldier()
    {
        walkSoldier.pitch = 1.18f;
        walkSoldier.Play();
    }

    public void PlayRunSoldier()
    {
        walkSoldier.pitch = 1.6f;
        walkSoldier.Play();
    }

    public void StopWalkSoldier()
    {
        walkSoldier.Stop();
    }

    public void PlayAttackSoldier()
    {
        walkSoldier.Stop();
        attackSoldier.Play();
    }

    public void PlayDamageSoldier()
    {
        walkSoldier.Stop();
        damageSoldier.Play();
    }

    // ui sounds
    public void PlayUIButton()
    {
        uiButton.Play();
    }

    public void PlayPauseButton()
    {
        pauseButton.Play();
    }

    public void PlayCacaoPick()
    {
        cacaoPick.Play();
    }

    public void PlaySuperCacaoPick()
    {
        superCacaoPick.Play();
    }

}
