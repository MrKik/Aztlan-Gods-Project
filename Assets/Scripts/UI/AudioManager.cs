using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource walkCualli;
    public AudioSource attackCualli;
    public AudioSource dashCualli;
    public AudioSource walkSoldier;
    public AudioSource attackSoldier;
    public AudioSource uiButton;
    public AudioSource pauseButton;

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
        walkCualli.pitch = 0.79f;
        walkCualli.Play();
    }

    public void StopWalkCualli()
    {
        walkCualli.Stop();
    }

    public void PlayRunCualli()
    {
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

    // sounds of the enemy soldier
    public void PlayWalkSoldier()
    {
        walkSoldier.pitch = 1.18f;
        walkSoldier.Play();
    }

    public void PlayRunSoldier()
    {
        walkCualli.pitch = 1.6f;
        walkCualli.Play();
    }

    public void StopWalkSoldier()
    {
        walkSoldier.Stop();
    }

    public void PlayAttackSoldier()
    {
        attackSoldier.Play();
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
}
