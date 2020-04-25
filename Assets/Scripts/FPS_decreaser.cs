using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_decreaser : MonoBehaviour
{

    public int FPS = 60;

    public bool to_decrease = false;
    void Update()
    {
#if UNITY_EDITOR
        if (to_decrease)
        {
            QualitySettings.vSyncCount = 0;  // VSync must be disabled
            Application.targetFrameRate = FPS;
        }
#endif
    }
}
