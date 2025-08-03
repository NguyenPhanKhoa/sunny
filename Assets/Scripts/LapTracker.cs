using TMPro;
using UnityEngine;

public class LapTracker : MonoBehaviour
{
    public int currentLap = 0;
    public int totalCheckpoints = 4; // Adjust to match track
    private int nextCheckpointIndex = 0;
    
    [SerializeField] TextMeshPro text;

    void Start()
    {
        text.text = "Score: " + currentLap;
    }

    private void OnTriggerEnter(Collider other)
    {
        Checkpoint checkpoint = other.GetComponent<Checkpoint>();
        if (checkpoint != null)
        {
            if (checkpoint.checkpointIndex == nextCheckpointIndex)
            {
                nextCheckpointIndex++;
                // Completed all checkpoints, new lap
                if (nextCheckpointIndex >= totalCheckpoints)
                {
                    currentLap++;
                    nextCheckpointIndex = 0;
                    text.text = "Score: " + currentLap;
                }
            }
        }
    }
}