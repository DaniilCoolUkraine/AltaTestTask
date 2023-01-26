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

        private GamePhaseManager _gamePhaseManager;

        private void Awake()
        {
            _gamePhaseManager = GameObject.FindWithTag("GamePhaseManager").GetComponent<GamePhaseManager>();
        }

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
                ReleaseProjectile();
                _gamePhaseManager.EndGame(EGamePhase.Loose);
            }
        }
        
        public void CheckPath(Transform characteristics)
        {
            if (Physics.BoxCast(characteristics.position, characteristics.localScale, Vector3.forward, out RaycastHit hitObject, Quaternion.identity, Mathf.Infinity))
            {
                if (hitObject.collider.gameObject.CompareTag("Finish"))
                {
                    _gamePhaseManager.EndGame(EGamePhase.Win);
                }
            }
        }
        
    }
}
