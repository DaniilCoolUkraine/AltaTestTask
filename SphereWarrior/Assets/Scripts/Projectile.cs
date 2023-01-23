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
        }

        private void OnEnable()
        {
            // TODO set velocity so projectile can fly 
        }

        private void Increase(float size)
        {
            Debug.Log(size);
            _size += _size - size;
        }
    }
}