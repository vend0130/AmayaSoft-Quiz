using UnityEngine;
using Quiz.Data;

namespace Quiz.Bundle
{
    [CreateAssetMenu(fileName = "Level GridBundleData", menuName = "Level Bundle Data", order = 1)]
    public class LevelBundleData : ScriptableObject
    {
        [SerializeField] private GridData[] _levels;

        public GridData[] Levels => _levels;
    }
}