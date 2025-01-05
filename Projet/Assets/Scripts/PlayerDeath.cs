using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public GameObject losePanel; // Panneau affiché en cas de défaite
    public Button mainMenuButton; // Bouton pour retourner au menu principal
    public GameObject player; // Le personnage

    void Start()
    {
        losePanel.SetActive(false);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si le joueur touche un objet avec le tag "Danger" ou "Enemy", il meurt
        if (other.CompareTag("Danger") || other.CompareTag("Enemy"))
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        // Désactive le personnage
        player.SetActive(false);

        // Affiche le panneau de défaite
        losePanel.SetActive(true);

        // Met le jeu en pause
        Time.timeScale = 0f;
    }

    void GoToMainMenu()
    {
        // Reprend le temps normal
        Time.timeScale = 1f;

        SceneManager.LoadScene("Main Menu");
    }
}