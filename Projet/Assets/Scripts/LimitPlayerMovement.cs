using UnityEngine;

public class LimitPlayerMovement : MonoBehaviour
{
    // Définir les limites selon la taille du plane
    public float minX = -25f; // Limite minimum sur l'axe X
    public float maxX = 25f;  // Limite maximum sur l'axe X
    public float minZ = -25f; // Limite minimum sur l'axe Z
    public float maxZ = 25f;  // Limite maximum sur l'axe Z

    void Update()
    {
        // Récupère la position actuelle du personnage
        Vector3 currentPosition = transform.position;

        // Limite la position sur l'axe X
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Limite la position sur l'axe Z
        currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);

        // Applique la nouvelle position au personnage
        transform.position = currentPosition;
    }
}