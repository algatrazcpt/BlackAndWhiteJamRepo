using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineShakeController : MonoBehaviour
{
    public float time = 2f;
    public float shake = 1.2f;
    public static CinemachineShakeController Instance;
    public CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void CutSceneShake()
    {
        StopCoroutine(CameraShake(0,0));
        StartCoroutine(CameraShake(time, shake));
    }

    public void CameraShakeStart(float time,float shakeStrenght)
    {
        CancelInvoke();
        StartCoroutine(CameraShake(time, shakeStrenght));
    }
    IEnumerator CameraShake(float time,float shakeValue)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeValue;
        yield return new WaitForSeconds(time);
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
    }

}
