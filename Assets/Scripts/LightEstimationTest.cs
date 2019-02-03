using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class LightEstimationTest : MonoBehaviour
{
    [Range(0f, 1f)]
    public float testValue = 0.5f;
    
    private void OnValidate()
    {
        SetGlobalLightEstimation(testValue);
    }
    private void Update()
    {
        SetGlobalLightEstimation(Frame.LightEstimate.PixelIntensity);
    }
    private void SetGlobalLightEstimation(float lightValue)
    {
        Shader.SetGlobalFloat("_GlobalLightEstimation", lightValue);
    }
}
