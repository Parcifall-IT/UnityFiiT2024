using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip rari;
    [SerializeField] AudioClip Farm;
    [SerializeField] AudioClip Boss;
    [SerializeField] AudioClip[] Shoots;
    [SerializeField] AudioClip Melee;
    [SerializeField] AudioClip Dead;
    [SerializeField] AudioClip Am;
    [SerializeField] AudioSource audioSource;

    public void Awake()
    {
        PlayFarm();
    }

    public void PlayRari()
    {
        audioSource.PlayOneShot(rari, 0.5f);
    }

    public void PlayShoot(int val)
    {
        audioSource.PlayOneShot(Shoots[val], 0.5f);
    }

    public void PlayMelee()
    {
        audioSource.PlayOneShot(Melee, 0.5f);
    }
    public void PlayAm()
    {
        audioSource.PlayOneShot(Am, 0.5f);
    }


    public void PlayBoss()
    {
        StartCoroutine(PlayWithFade(Boss));
    }

    public void PlayDead()
    {
        StartCoroutine(PlayWithFade(Dead));
    }

    public void PlayFarm()
    {
        StartCoroutine(PlayWithFade(Farm));
    }

    IEnumerator PlayWithFade(AudioClip clip)
    {
        StartCoroutine(FadeOutMusic());

        yield return new WaitForSeconds(0.5f);

        audioSource.PlayOneShot(clip, 0.5f);
    }

    IEnumerator FadeOutMusic()
    {
        var startVolume = audioSource.volume;
        var currentTime = 0f;

        while (currentTime < 0.5)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, currentTime);
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
