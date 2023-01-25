using System.Collections.Generic;
using UnityEngine;
using SphereWarrior.Managers;
using SphereWarrior.Infectable;
using SphereWarrior.CalculateAreaFormulas;

namespace SphereWarrior
{
    public class Projectile : MonoBehaviour
    {
        private float _size;
        private float _speed;

        private List<IInfectable> _obstacles;
        
        private ICalculateArea _calculateAreaFormula;
        private float _findRadius;

        private void Start()
        {
            _obstacles = new List<IInfectable>();
            
            TapManager.OnTapHold += Increase;
            TapManager.OnTapReleased += SetVelocity;
        }
        
        public void SetComponents(ICalculateArea calculator, float speed)
        {
            gameObject.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            _calculateAreaFormula = calculator;
            _speed = speed;
        }
        
        private void Increase(float size)
        {
            _size += size;
            transform.localScale = new Vector3(_size, _size, _size);
            
            _findRadius = _calculateAreaFormula.CalculateArea(_size);
        }

        private void SetVelocity()
        {
            var _rb = GetComponent<Rigidbody>();
            
            _rb.constraints = RigidbodyConstraints.FreezePositionY;
            _rb.velocity = Vector3.forward * _speed;
            
            TapManager.OnTapHold -= Increase;
            TapManager.OnTapReleased -= SetVelocity;
        }

        private void OnCollisionEnter()
        {
            FindInfectableObjects();
            InfectAll();
            Destroy(gameObject);
        }

        private void FindInfectableObjects()
        {
            RaycastHit[] obstacles = Physics.SphereCastAll(transform.position, _findRadius, Vector3.one);
            foreach (RaycastHit obstacle in obstacles)
            {
                var infectableObject = obstacle.collider.gameObject.GetComponent<IInfectable>();
                if (infectableObject!= null)
                    _obstacles.Add(infectableObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _findRadius);
        }

        private void InfectAll()
        {
            foreach (IInfectable obstacle in _obstacles)
            {
                obstacle.Infect();
            }
        }
    }
}