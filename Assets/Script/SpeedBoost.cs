using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    public float speedMultiplier = 2f;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity *= speedMultiplier;
        }
    }
}
