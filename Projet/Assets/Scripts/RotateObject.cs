using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f); // Vitesse de rotation sur les axes X, Y et Z

    void Update()
    {
        // Applique une rotation constante
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
