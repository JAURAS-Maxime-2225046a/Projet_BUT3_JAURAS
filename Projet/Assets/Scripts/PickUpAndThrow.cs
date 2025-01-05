using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndThrow : MonoBehaviour
{
    public Transform holdPoint;  // Point où l'objet sera tenu
    public float throwForce = 10f;  // Force avec laquelle l'objet sera jeté

    private GameObject heldObject;  // L'objet actuellement ramassé

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Touche pour ramasser ou jeter
        {
            if (heldObject == null)
            {
                TryPickUp();
            }
            else
            {
                ThrowObject();
            }
        }
    }

    void TryPickUp()
    {
        // Vérifie s'il y a un objet à proximité avec lequel interagir
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f); // Rayon d'interaction
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Pickup")) // Vérifie si l'objet est ramassable (tag "Pickup")
            {
                PickUp(collider.gameObject);
                return;
            }
        }
    }

    void PickUp(GameObject obj)
    {
        heldObject = obj;

        // Désactive la physique de l'objet pendant qu'il est tenu
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Place l'objet au point de tenue
        heldObject.transform.position = holdPoint.position;
        heldObject.transform.parent = holdPoint;

        Debug.Log("Objet ramassé : " + heldObject.name);
    }

    void ThrowObject()
    {
        // Détache l'objet
        heldObject.transform.parent = null;

        // Réactive la physique
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * throwForce, ForceMode.Impulse); // Applique une force pour lancer l'objet
        }

        Debug.Log("Objet jeté : " + heldObject.name);
        heldObject = null; // Réinitialise l'objet tenu
    }

    void OnDrawGizmosSelected()
    {
        // Dessine le rayon d'interaction pour la prise d'objet
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}