using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Référence au joueur à suivre

    private NavMeshAgent agent; // Référence au NavMeshAgent

    void Start()
    {
        // Récupère le NavMeshAgent attaché à cet objet
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            // Met à jour la destination de l'ennemi pour suivre le joueur
            agent.SetDestination(player.position);
        }
    }
}