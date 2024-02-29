using System.Collections;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;
    public Material normalMaterial; // Materi saat tidak ditekan
    public Material pressedMaterial; // Materi saat ditekan

    public float maxTimeHold;
    public float maxForce;

    private Renderer rendere;
    private bool isHold;

    private void Start()
    {
        isHold = false;
        rendere = GetComponent<Renderer>();
        rendere.material = normalMaterial;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
            // Ganti materi saat tombol ditekan
            rendere.material = pressedMaterial;
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        // Kembalikan materi ke normal setelah tombol dilepas
        rendere.material = normalMaterial;
    }
}
