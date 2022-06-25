using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private CinemachineVirtualCamera cameraToShake;
    CinemachineBasicMultiChannelPerlin channelPerlin;

    private void Awake()
    {
        instance = this;
        cameraToShake = GetComponent<CinemachineVirtualCamera>();
        channelPerlin = cameraToShake.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    public void Shake(float intensity, float duration)
    {

        channelPerlin.m_AmplitudeGain = intensity;

        StartCoroutine(StopShake(duration));
    }

    IEnumerator StopShake(float duration)
    {
        yield return new WaitForSeconds(duration);
        while (channelPerlin.m_AmplitudeGain > 0)
            channelPerlin.m_AmplitudeGain -= Time.deltaTime;
        channelPerlin.m_AmplitudeGain = 0;
    }
}
