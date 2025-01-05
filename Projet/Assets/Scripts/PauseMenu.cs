using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Le panneau de pause
    public Button pauseButton; // Le bouton qui active le menu de pause
    public Button resumeButton; // Le bouton pour reprendre le jeu
    public Button mainMenuButton; // Le bouton pour revenir au menu principal

    private bool isPaused = false; // Variable pour savoir si le jeu est en pause

    void Start()
    {
        // Au démarrage, le menu de pause est caché
        pauseMenuUI.SetActive(false);

        // Ajout des écouteurs pour les boutons
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        // Optionnel : Si vous voulez que le jeu soit aussi mis en pause en appuyant sur la touche "Escape"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();  // Si le jeu est en pause, on le reprend
            }
            else
            {
                Pause();   // Sinon on le met en pause
            }
        }
    }

    // Fonction pour mettre le jeu en pause et afficher le menu
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;  // Met le jeu en pause (le temps est figé)
        pauseMenuUI.SetActive(true);  // Affiche le panneau du menu pause
    }

    // Fonction pour reprendre le jeu
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;  // Reprend le temps du jeu (le jeu reprend)
        pauseMenuUI.SetActive(false);  // Cache le panneau du menu pause
    }

    // Fonction pour retourner au menu principal
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;  // Assurez-vous de réactiver le temps avant de charger une nouvelle scène
        SceneManager.LoadScene("Main Menu");  // Remplacez "Main Menu" par le nom de votre scène
    }
}