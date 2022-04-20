using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsidienController : MonoBehaviour
{
    public bool[] allObsidens;
    public int allObsidensSize;
    private void Start()
    {
        allObsidensSize = allObsidens.Length;
    }
}
