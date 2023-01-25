using UnityEngine;

namespace SphereWarrior.CalculateAreaFormulas
{
    public class SquareCalculator: ICalculateArea
    {
        public float CalculateArea(float size) => Mathf.Pow(size, 2);
    }
}