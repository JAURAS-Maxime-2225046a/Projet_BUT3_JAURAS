using UnityEngine;

public class PieceDisappear : MonoBehaviour
{
    public WinCondition winCondition;  // Référence au gestionnaire de victoire
    public AudioSource pickupSound;    // Référence à l'AudioSource du son à jouer

    private void Start()
    {
        // Si l'AudioSource n'est pas assigné dans l'éditeur, on affiche un message
        if (pickupSound == null)
        {
            Debug.LogWarning("AudioSource non assigné dans l'inspecteur!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le personnage (tag "Player")
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur a ramassé la pièce!");

            // Si l'AudioSource est assigné et désactivé, on l'active et on joue le son
            if (pickupSound != null && !pickupSound.isPlaying)
            {
                pickupSound.gameObject.SetActive(true);  // Active l'AudioSource (l'objet contenant l'AudioSource)
                pickupSound.Play();  // Joue le son
            }

            // Désactive la pièce
            gameObject.SetActive(false);

            // Notifie le gestionnaire de victoire que cette pièce a été touchée
            winCondition.CheckPieces(); // Appeler la méthode CheckPieces de WinCondition
        }
    }
}