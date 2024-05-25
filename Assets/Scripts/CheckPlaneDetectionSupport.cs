using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

public class CheckPlaneDetectionSupport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var planeDescriptors = new List<XRPlaneSubsystemDescriptor>();
        SubsystemManager.GetSubsystemDescriptors(planeDescriptors);
        Debug.Log("Plane descriptors count: " + planeDescriptors.Count);
        if (planeDescriptors.Count > 0)
        {
            foreach (var planeDescriptor in planeDescriptors)
            {
                Debug.Log("Support horizontal: " + planeDescriptor.supportsHorizontalPlaneDetection);
                Debug.Log("Support vertical: " + planeDescriptor.supportsVerticalPlaneDetection);
                Debug.Log("Support arbitrary: " + planeDescriptor.supportsArbitraryPlaneDetection);
                Debug.Log("Support classification: " + planeDescriptor.supportsClassification);

            }
        }
    }
}
