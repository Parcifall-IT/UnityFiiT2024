using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    [SerializeField] AudioClip hamster;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        StartCoroutine(PlayWithFade(hamster));
    }
    IEnumerator PlayWithFade(AudioClip clip)
    {
        StartCoroutine(FadeOutMusic());

        yield return new WaitForSeconds(0.5f);

        audioSource.PlayOneShot(clip, 0.3f);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutMusic());
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
