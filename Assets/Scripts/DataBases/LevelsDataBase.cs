using System;
using UnityEngine;

namespace DataBases
{
    [Serializable]
    public struct LevelData
    {
        [SerializeField] private int[] _availableBlocks;
        [SerializeField] private int[] _availableBoosters;

        public int[] AvailableBlocks => _availableBlocks;
        public int[] AvailableBoosters => _availableBoosters;
    }

    [CreateAssetMenu(fileName = "LevelsDataBase.asset", menuName = "DataBases/LevelDataBase")]
    public class LevelsDataBase : ScriptableObject
    {
        [SerializeField] private LevelData[] _levels;

        public LevelData[] Levels => _levels;
    }
}