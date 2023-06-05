using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_GameOver : MonoBehaviour
{
    public float duration = 1f; // Transition duration in seconds
    public float targetAlpha = 0f; // Target alpha value you want to achieve

    private SpriteRenderer spriteRenderer;
    private Color initialColor;
    private float startTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
        startTime = Time.time;
    }

    private void Update()
    {
        // Calculate the elapsed time since the start of the transition
        float elapsedTime = Time.time - startTime;

        // Calculate the fraction of elapsed time relative to the total duration
        float timeFraction = Mathf.Clamp01(elapsedTime / duration);

        // Interpolate between the initial color and the target color using the time fraction
        Color newColor = Color.Lerp(initialColor, new Color(initialColor.r, initialColor.g, initialColor.b, targetAlpha), timeFraction);

        // Update the color of the Sprite Renderer
        spriteRenderer.color = newColor;
    }
}

