using UnityEngine;

public class DriftParticle : MonoBehaviour {

    public GameObject driftParticlePrefab;
    public float driftFactor = 0.95f;
    public float maxAngularVelocity = 50f;

    private Rigidbody rb;
    private float currentSpeed;
    private float previousSpeed;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");

        if (h != 0f) {
            rb.AddForce(transform.forward * h * 1000f);
            rb.AddTorque(transform.up * h * 10f);

            currentSpeed = rb.velocity.magnitude;

            if (currentSpeed < previousSpeed) {
                // Drift started, spawn particle effect
                GameObject driftParticle = Instantiate(driftParticlePrefab, transform.position, Quaternion.identity);
                Destroy(driftParticle, 2f);
            }

            previousSpeed = currentSpeed;
        }
    }
}
