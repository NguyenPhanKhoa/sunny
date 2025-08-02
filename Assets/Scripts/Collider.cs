using UnityEngine;

public class Collider : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.collider.name);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
