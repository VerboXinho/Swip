using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomOption : MonoBehaviour
{
    private Camera mainCamera;
    private Volume bloomVolume;
    private Bloom bloomEffect;

    private void Start()
    {
        mainCamera = Camera.main;
        bloomVolume = mainCamera.GetComponent<Volume>();
        if (bloomVolume == null)
        {
            Debug.LogError("Volume not found on the main camera!");
            return;
        }

        if (!bloomVolume.profile.TryGet(out bloomEffect))
        {
            Debug.LogError("Bloom effect not found in the Volume!");
        }
    }

    // Toggle the Bloom effect on/off
    public void ToggleBloomEffect(bool isEnabled)
    {
        if (bloomEffect != null)
        {
            bloomEffect.active = isEnabled; // Set the active state of the Bloom effect
            
            // Update the Volume's weight
            bloomVolume.weight = isEnabled ? 1f : 0f;

            Debug.Log("Setting Bloom Effect Active State to: " + isEnabled);
            Debug.Log("Setting Volume Weight to: " + bloomVolume.weight);
        }
        else
        {
            Debug.LogWarning("Bloom effect reference is null!");
        }
    }
}
