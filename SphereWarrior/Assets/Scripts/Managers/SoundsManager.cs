using UnityEngine;

namespace SphereWarrior.Managers
{
    public class SoundsManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _resizingAudio;
        [SerializeField] private AudioSource[] _releaseAudio;
        
        private void Start()
        {
            TapManager.OnTap += PlayAudio;
            TapManager.OnTapReleased += StopAudio;
        }

        private void PlayAudio()
        {
            _resizingAudio?.Play();
        }
        
        private void StopAudio()
        {
            _resizingAudio?.Stop();
            _releaseAudio[Random.Range(0, _releaseAudio.Length)]?.Play();
        }
    }
}