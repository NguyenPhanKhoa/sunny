using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private AudioClip[] diedClips;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered with: " + other.name);
            // Play a random sound from the diedClips array
            SoundFXManager.instance.PlayRandomSound(diedClips, transform, 1f);
        }

    }
}
