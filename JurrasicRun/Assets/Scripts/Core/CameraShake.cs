using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    private CinemachineVirtualCamera camera;
    private float shakeTimer;

    private void Awake()
    {
        Instance = this;
        camera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cbmcp = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cbmcp.m_AmplitudeGain = 0f;
            }
        }
           
    }

    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cbmcp = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cbmcp.m_AmplitudeGain = intensity;
        shakeTimer -= Time.deltaTime;
       // new WaitForSeconds(time);
        cbmcp.m_AmplitudeGain = 0;

    }
}
