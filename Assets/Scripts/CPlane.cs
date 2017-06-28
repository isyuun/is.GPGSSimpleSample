using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlane : MonoBehaviour {

    public CGPSManager _gpsManager;

    void OnMouseDown()
    {
        _gpsManager.OnClickCountUpButtonClick();
    }
}
