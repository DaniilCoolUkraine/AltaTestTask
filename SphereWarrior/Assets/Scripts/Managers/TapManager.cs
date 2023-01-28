using System;
using UnityEngine;

namespace SphereWarrior.Managers
{
    public class TapManager : MonoBehaviour
    {
        [SerializeField] private float _sizePerFrame;
        
        public static event Action OnTap;
        public static event Action OnTapReleased;
        public static event Action<float> OnTapHold;
        
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Began)
                    OnTap?.Invoke();
                
                if (touch.phase == TouchPhase.Ended)
                    OnTapReleased?.Invoke();

                if (touch.phase == TouchPhase.Stationary)
                    OnTapHold?.Invoke(_sizePerFrame * Time.deltaTime);
            }
        }

        private void OnDisable()
        {
            OnTap = null;
            OnTapReleased = null;
            OnTapHold = null;
        }
    }
}