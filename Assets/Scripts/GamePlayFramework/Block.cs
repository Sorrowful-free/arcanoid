using DataBases;
using UnityEngine;

namespace GamePlayFramework
{
    public class Block : MonoBehaviour
    {
        public int CurrentLives { get; set; }
        public BlockData Data { get; private set; }
        public void Initialize(BlockData data)
        {
            Data = data;
            CurrentLives = data.Lives;
            GetComponent<SpriteRenderer>().color = data.Color;
        }
    }
}