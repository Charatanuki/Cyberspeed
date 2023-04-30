using UnityEngine;

public class DriftController : MonoBehaviour {

    public float driftFactor = 0.95f;
    public float maxAngularVelocity = 50f;
    public float driftMultiplier = 1.5f;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");

        if (h != 0f) {
            rb.AddForce(transform.forward * h * 1000f);
            rb.AddTorque(transform.up * h * 10f * driftMultiplier);
            rb.angularVelocity *= driftFactor;
        }
    }
}
