using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineShakeController : MonoBehaviour
{
    public static CinemachineShakeController Instance;
    public CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
