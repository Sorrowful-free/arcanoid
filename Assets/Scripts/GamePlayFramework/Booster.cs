using System;
using DataBases;
using UnityEngine;

namespace GamePlayFramework
{
    public class Booster :  MonoBehaviour
    {
        
        public BoosterData Data { get; private set; }

        public void Initialize(BoosterData data)
        {
            Data = data;
            GetComponent<SpriteRenderer>().color = data.Color;
        }
    }
}