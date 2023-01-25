using UnityEngine;

namespace SphereWarrior.Managers
{
    public class ObstacleGenerator : MonoBehaviour
    {
        [SerializeField] private int _fieldWidth;
        [SerializeField] private int _fieldLength;
        [SerializeField] private Vector3 _offset;

        [SerializeField] private int _obstacleDencity;

        [SerializeField] private GameObject[] _availableObstacles;

        private GameObject[,] _generatedObstacles;
        
        public void Start()
        {
            GenerateNoise();
            SetMap();
        }

        private void GenerateNoise()
        {
            _generatedObstacles = new GameObject[_fieldWidth, _fieldLength];

            for (int x = 0; x < _fieldWidth; x++)
            {
                for (int y = 0; y < _fieldLength; y++)
                {
                    if (Random.Range(0, 100) >= _obstacleDencity)
                        _generatedObstacles[x, y] = _availableObstacles[Random.Range(0, _availableObstacles.Length)];
                    else
                        _generatedObstacles[x, y] = null;
                }
            }
        }
        
        private void SetMap()
        {
            for (int x = 0; x < _fieldWidth; x++)
            {
                for (int y = 0; y < _fieldLength; y++)
                {
                    if(_generatedObstacles[x, y] != null)
                        Instantiate(_generatedObstacles[x, y], new Vector3(x, 0, y) + _offset, Quaternion.identity);
                }
            }
        }
        
    }
}