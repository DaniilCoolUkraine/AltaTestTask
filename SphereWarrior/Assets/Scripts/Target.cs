using SphereWarrior.Managers;
using UnityEngine;

namespace SphereWarrior
{
    public class Target : MonoBehaviour
    {
        private GamePhaseManager _gamePhaseManager;

        private void Awake()
        {
            _gamePhaseManager = GameObject.FindWithTag("GamePhaseManager").GetComponent<GamePhaseManager>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _gamePhaseManager.EndGame(EGamePhase.Win);
            }
        }
    }
}