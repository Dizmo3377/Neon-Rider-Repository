using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;
    private static AudioSource audioSource;
    private void Awake()
    {
        PlayerPrefs.SetInt("Music", 1);
        Play();
    }

    private void Play()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            audioSource = this.GetComponent<AudioSource>();
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public static void Stop()
    {
        audioSource.Stop();
    }
}
