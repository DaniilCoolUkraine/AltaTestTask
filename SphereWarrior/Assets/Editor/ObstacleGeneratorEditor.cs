using SphereWarrior.Managers;
using UnityEditor;
using UnityEngine;

namespace SphereWarrior
{
    [CustomEditor(typeof(ObstacleGenerator))]
    public class ObstacleGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ObstacleGenerator generatorEditor = (ObstacleGenerator) target;
            
            if (GUILayout.Button("Generate obstacles"))
            {
                generatorEditor.Start();
            }
        }
    }
}
