using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    public GearType gearType = GearType.GearSmall;
    public float RotationSpeed = 10f;

    public enum GearType
    {
        GearSmall,
        GearBig
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gearType == GearType.GearBig)
        {
            RotationSpeed *= 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }
}
