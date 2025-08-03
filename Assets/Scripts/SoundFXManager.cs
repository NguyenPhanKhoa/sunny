using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayRandomSound(AudioClip[] clips, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.volume = volume;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
