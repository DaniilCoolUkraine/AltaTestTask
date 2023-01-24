using System;
using System.Collections.Generic;
using UnityEngine;

namespace SphereWarrior
{
    public class Projectile : MonoBehaviour
    {
        private float _size;

        private List<IInfectable> _obstacles;

        private void Start()
        {
            _obstacles = new List<IInfectable>();
            
            TapManager.OnTapHold += Increase;
            TapManager.OnTapReleased += SetVelocity;

            SetComponents();
        }

        private void SetComponents()
        {
            gameObject.AddComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
        private void Increase(float size)
        {
            _size += size;
            transform.localScale = new Vector3(_size, _size, _size);
        }

        private void SetVelocity()
        {
            var _rb = GetComponent<Rigidbody>();
            
            _rb.constraints = RigidbodyConstraints.FreezePositionY;
            _rb.velocity = Vector3.forward;
            
            TapManager.OnTapHold -= Increase;
            TapManager.OnTapReleased -= SetVelocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            FindInfectableObjects();
            InfectAll();
            Destroy(gameObject);
        }

        private void FindInfectableObjects()
        {
            RaycastHit[] obstacles = Physics.SphereCastAll(transform.position, _size, transform.forward);
            foreach (RaycastHit obstacle in obstacles)
            {
                var infectableObject = obstacle.collider.gameObject.GetComponent<IInfectable>();
                if (infectableObject!= null)
                    _obstacles.Add(infectableObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _size);
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