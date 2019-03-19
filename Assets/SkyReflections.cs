using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyReflections : MonoBehaviour
{
    // Start is called before the first frame update

    private ReflectionProbe skyBox;

    void Awake()
    {
        skyBox = GetComponent<ReflectionProbe>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalTexture("_NewCeto_DirectionSkyMap", skyBox.realtimeTexture);
    }
}
