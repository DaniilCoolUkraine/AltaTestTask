using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SphereWarrior.Managers
{
    public class GamePhaseManager : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonNext;
        [SerializeField] private GameObject _buttonRestart;
        [SerializeField] private Text _finalText;

        [SerializeField] private GameObject _tapManager;
        
        public void EndGame(EGamePhase gamePhase)
        {
            _tapManager.GetComponent<TapManager>().enabled = false;

            if (gamePhase == EGamePhase.Win)
            {
                _buttonNext.SetActive(true);
                _finalText.text = "You`re winner!";
            }

            if (gamePhase == EGamePhase.Loose)
            {
                _buttonRestart.SetActive(true);
                _finalText.text = "You loose!";
            }
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }
        
    }
}