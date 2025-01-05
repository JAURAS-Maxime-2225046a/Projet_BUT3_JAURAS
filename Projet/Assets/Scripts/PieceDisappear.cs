using UnityEngine;

public class PieceDisappear : MonoBehaviour
{
    public WinCondition winCondition;  // Référence au gestionnaire de victoire

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le personnage (tag "Player")
        if (other.CompareTag("Player"))
        {
            // Désactive la pièce
            gameObject.SetActive(false);

            // Notifie le gestionnaire de victoire que cette pièce a été touchée
            winCondition.CheckPieces(); // Appeler la méthode CheckPieces de WinCondition
        }
    }
}