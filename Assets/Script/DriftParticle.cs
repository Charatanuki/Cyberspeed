using UnityEngine;

public class DriftParticle : MonoBehaviour {

    public GameObject driftParticlePrefab;
    public float driftFactor = 0.95f;
    public float maxAngularVelocity = 50f;
    public float particleFrequency = 0.1f; // Controls how often particles are instantiated

    private Rigidbody rb;
    private float currentSpeed;
    private float previousSpeed;
    private float timeSinceLastParticle = 0f;

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
                timeSinceLastParticle += Time.deltaTime;
                if (timeSinceLastParticle >= particleFrequency) {
                    GameObject driftParticle = Instantiate(driftParticlePrefab, transform.position, Quaternion.identity);
                    Destroy(driftParticle, 2f);
                    timeSinceLastParticle = 0f;
                }
                particleFrequency *= driftFactor; // Increase particle frequency while drifting
            }

            previousSpeed = currentSpeed;
        }
        else {
            particleFrequency = 0.1f; // Reset particle frequency when not drifting
        }
    }
}
