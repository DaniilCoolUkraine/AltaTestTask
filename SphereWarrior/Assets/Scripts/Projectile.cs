using UnityEngine;

namespace SphereWarrior
{
    public class Projectile : MonoBehaviour
    {
        private float _size;

        private IInfectable[] _obstacles;

        private void Start()
        {
            TapManager.OnTapHold += Increase;
            TapManager.OnTapReleased += SetVelocity;

            SetComponents();
        }

        private void SetComponents()
        {
            transform.position = Vector3.forward*5;
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
        }
    }
}