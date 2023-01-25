using System;
using UnityEngine;
using SphereWarrior.Managers;
using SphereWarrior.CalculateAreaFormulas;

namespace SphereWarrior
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _minimumSize;
        [SerializeField] private Transform _projectileSpawnPosition;
        [SerializeField] private float _projectileSpeed;

        private float _size;

        private GameObject _currentProjectile;

        private void Start()
        {
            TapManager.OnTap += CreateProjectile;
            TapManager.OnTapReleased += ReleaseProjectile;
            TapManager.OnTapHold += Decrease;

            _size = transform.localScale.x;
        }
        
        private void CreateProjectile()
        {
            _currentProjectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            _currentProjectile.transform.position = _projectileSpawnPosition.position;
            
            _currentProjectile.AddComponent<Projectile>();
            _currentProjectile.GetComponent<Projectile>().SetComponents(new SquareCalculator(), _projectileSpeed);
        }

        private void ReleaseProjectile()
        {
            _currentProjectile = null;
        }

        private void Decrease(float size)
        {
            _size -= size;
            transform.localScale = new Vector3(_size, _size, _size);
            
            if (_size <= _minimumSize)
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            // TODO implement end game
            
        }
    }
}
