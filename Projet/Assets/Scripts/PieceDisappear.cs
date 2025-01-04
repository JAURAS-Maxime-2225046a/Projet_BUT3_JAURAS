using UnityEngine;

public class PieceDisappear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le personnage (tag "Player")
        if (other.CompareTag("Player"))
        {

            // Désactive la pièce
            gameObject.SetActive(false);

            // Destroy(gameObject);
        }
    }
}