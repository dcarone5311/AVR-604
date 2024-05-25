using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.XR.CoreUtils;

public class ShowTrackablesOnEnable : MonoBehaviour
{
    [SerializeField] XROrigin sessionOrigin;

    ARPlaneManager planeManager;
    ARPointCloudManager cloudManager;
    bool isStarted;

    private void Awake()
    {
        planeManager = sessionOrigin.GetComponent<ARPlaneManager>();
        cloudManager = sessionOrigin.GetComponent<ARPointCloudManager>();

    }

    private void Start()
    {
        isStarted = true;
    }


}
