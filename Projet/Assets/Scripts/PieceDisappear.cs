using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDisappear : MonoBehaviour
{
    public WinCondition winCondition;  // Référence au gestionnaire de victoire
    public AudioSource pickupSound;    // Référence à l'AudioSource du son à jouer

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le personnage (tag "Player")
        if (other.CompareTag("Player"))
        {
            pickupSound.Play();

            // Désactive la pièce
            gameObject.SetActive(false);

            // Notifie le gestionnaire de victoire que cette pièce a été touchée
            winCondition.CheckPieces(); // Appeler la méthode CheckPieces de WinCondition
        }
    }
}