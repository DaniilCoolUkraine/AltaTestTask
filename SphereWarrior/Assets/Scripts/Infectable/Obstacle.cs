using UnityEngine;

namespace SphereWarrior.Infectable
{
    public class Obstacle : MonoBehaviour, IInfectable
    {
        [SerializeField] private Color _infectedColor;
        [SerializeField] private ParticleSystem _explosionParticles;
        
        public void Infect()
        {
            GetComponent<Renderer>().material.SetColor("_Color", _infectedColor);
            
            var _particles = Instantiate(_explosionParticles, transform.position, Quaternion.identity);
            _particles.Play();
            
            Destroy(_particles.gameObject, _explosionParticles.duration);
            Destroy(gameObject, _explosionParticles.duration);
        }
        
    }
}