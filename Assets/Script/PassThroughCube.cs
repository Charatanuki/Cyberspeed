using UnityEngine;

public class PassThroughCube : MonoBehaviour
{
    public GameObject objectToTrack; // Reference to the object to track

    private Collider cubeCollider;

    private void Start()
    {
        cubeCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToTrack)
        {
            cubeCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectToTrack)
        {
            cubeCollider.enabled = true;
        }
    }
}
