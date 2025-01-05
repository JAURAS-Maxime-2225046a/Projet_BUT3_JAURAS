using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public GameObject winPanel;  // Panneau de victoire
    public Button mainMenuButton; // Bouton pour revenir au menu principal

    public GameObject[] pieces;  // Liste des pièces
    private int piecesDestroyed = 0;  // Compteur des pièces détruites

    void Start()
    {
        // Assurez-vous que le panneau est désactivé au début
        winPanel.SetActive(false);

        // Ajoutez des écouteurs aux boutons
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        // Si toutes les pièces sont détruites, afficher le panneau de victoire
        if (piecesDestroyed == pieces.Length)
        {
            ShowWinPanel();
        }
    }

    // Méthode appelée par PieceDisappear pour vérifier si toutes les pièces sont touchées
    public void CheckPieces()
    {
        piecesDestroyed = 0;  // Réinitialiser le compteur
        foreach (GameObject piece in pieces)
        {
            if (piece == null || !piece.activeInHierarchy)  // Vérifier si la pièce est désactivée
            {
                piecesDestroyed++;
            }
        }
    }

    // Fonction pour afficher le panneau de victoire
    void ShowWinPanel()
    {
        winPanel.SetActive(true);  // Afficher le panneau
        Time.timeScale = 0f;       // Mettre le jeu en pause (arrêter le temps)
    }

    // Fonction pour revenir au menu principal
    void GoToMainMenu()
    {
        Time.timeScale = 1f;  // Assurez-vous que le temps reprend
        // Réinitialisez toute autre logique si nécessaire
        SceneManager.LoadScene("Main Menu");  // Remplacez "Main Menu" par le nom de votre scène de menu principal
    }

    // Fonction pour assurer que Time.timeScale est réinitialisé lors du changement de scène
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f; // Réinitialiser Time.timeScale lors du chargement d'une nouvelle scène
    }

    void OnEnable()
    {
        // Assurez-vous que l'écouteur de scène est attaché lorsque la scène change
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Retirer l'écouteur de scène lors de la désactivation
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}