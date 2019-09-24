using System;
using UnityEngine;

namespace DataBases
{
    public enum BoosterType
    {
        ChangeBallSpeed,
        ChangeRacketSize,
        MakeCloneOfBall
    }

    [Serializable]
    public struct BoosterEffect
    {
        [SerializeField] private BoosterType _type;
        [SerializeField] private int _amount;

        public BoosterType Type => _type;
        public int Amount => _amount;
    }

    [Serializable]
    public struct BoosterData
    {
        [SerializeField] private Color _color;
        [SerializeField] private BoosterEffect[] _effects;

        public Color Color => _color;
        public BoosterEffect[] Effects => _effects;
    }

    [CreateAssetMenu(fileName = "BoostersDataBase.asset", menuName = "DataBases/BoostersDataBase")]
    public class BoostersDataBase : ScriptableObject
    {
        [SerializeField]
        private BoosterData[] _boosters;
        public BoosterData[] Boosters => _boosters;
    }
}