using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI fpsText; // Reference to the TextMeshProUGUI component
    public float refreshRate = 0.5f; // How often to update the FPS text (in seconds)

    private float deltaTime = 0.0f;
    private float timer = 0.0f;

    private void Update()
    {
        // Calculate FPS and MS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        float ms = deltaTime * 1000.0f;

        // Update the timer
        timer += Time.unscaledDeltaTime;

        // Only update the text at the specified refresh rate
        if (timer >= refreshRate)
        {
            fpsText.text = $"FPS: {fps:0.} \nMS: {ms:0.0}";
            timer = 0.0f; // Reset the timer

            if (fps >= 58)
            {
                fpsText.color = Color.green;
            }
            else if (fps >= 30)
            {
                fpsText.color = Color.yellow;
            }
            else
            {
                fpsText.color = Color.red;
            }
        }
    }
}