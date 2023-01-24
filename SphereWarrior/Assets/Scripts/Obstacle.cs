using UnityEngine;

namespace SphereWarrior
{
    public class Obstacle : MonoBehaviour, IInfectable
    {
        [SerializeField] private Color _infectedColor;
        [SerializeField] private ParticleSystem _explosionParticles;
        
        public void Infect()
        {
            GetComponent<Renderer>().material.SetColor("_Color", _infectedColor);
            //Destroy(gameObject, _explosionParticles.time);
        }
        
    }
}