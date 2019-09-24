using System;
using UnityEngine;

namespace DataBases
{
    [Serializable]
    public struct BlockData
    {
        [SerializeField]
        private Color _color;
        [SerializeField]
        private int _lives;
        [SerializeField]
        private bool _isSpawnBooster;

        public Color Color => _color;
        public int Lives => _lives;
        public bool IsSpawnBooster => _isSpawnBooster;
    }
    [CreateAssetMenu(fileName = "BlocksDataBase.asset",menuName = "DataBases/BlocksDataBase")]
    public class BlocksDataBase : ScriptableObject
    {
        [SerializeField]
        private BlockData[] _blocks;

        public BlockData[] Blocks => _blocks;
    }
}