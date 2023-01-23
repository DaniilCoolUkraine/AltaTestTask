using UnityEngine;

namespace SphereWarrior
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _minimumSize;
        
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
            _currentProjectile.AddComponent<Projectile>();
        }

        private void ReleaseProjectile()
        {
            _currentProjectile = null;
        }

        private void Decrease(float size)
        {
            _size -= size;
            transform.localScale = new Vector3(_size, _size, _size);
            
            // TODO add check if curr size == minimum size
        }
        
    }
}
