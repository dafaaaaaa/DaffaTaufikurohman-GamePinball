using UnityEngine;

public class RampController : MonoBehaviour
{
    public float speedMultiplier = 2f; // Multiplier for the speed boost

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>(); // Get the Rigidbody of the colliding object
        if (rb != null)
        {
            // Check if the colliding object has a Rigidbody (like the ball)
            rb.AddForce(transform.forward * speedMultiplier, ForceMode.Impulse); // Add force forward (in the direction of the ramp) to give it a speed boost
        }
    }
}
