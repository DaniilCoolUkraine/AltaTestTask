using System.Collections;
using UnityEngine;

namespace SphereWarrior
{
    public class Obstacle : MonoBehaviour, IInfectable
    {
        [SerializeField] private ParticleSystem _explosionParticles;
        
        public void Infect()
        {
            GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 0.44f, 0f));
        }
        
    }
}