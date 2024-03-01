using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;

    public float score;
    public ScoreManager scoreManager;

    public AudioManager audioManager;
    public VFXManager vfxManager;

    private SwitchState state;
    private Renderer rendere;

    private void Start()
    {
        rendere = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();
            // Memunculkan VFX dan SFX saat bola menyentuh switch
            PlayEffects();
        }
    }

    private void PlayEffects()
    {
        // Memainkan efek suara
        audioManager.PlaySFX(transform.position);
        // Memainkan efek visual
        vfxManager.PlayVFX(transform.position);
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            rendere.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            rendere.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            rendere.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            rendere.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
