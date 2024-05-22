using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonARMode : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        UIController.ShowUI("NonAR");
    }
}
