using DataBases;
using DefaultNamespace;
using GamePlayFramework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace States.Main
{
    public partial class MainState
    {
        private void SpawnBooster(Vector2 position, BoosterData boosterData)
        {
            var booster = Object.Instantiate(
                    Resources.Load<GameObject>(
                        ResourcesNames.PrefabsNames.BOOSTER
                    )
                )
                .GetComponent<Booster>();
            booster.Initialize(boosterData);
            booster.transform.position = position;
            booster.OnCollisionEnter2DEvent += OnBoosterCollisionEnter2D;
        }

        private void OnBoosterCollisionEnter2D(Collision2D collision2D)
        {
            var wall = collision2D.gameObject.GetComponent<Wall>();
            if (wall != null && wall == _bottomWall)
            {
                DestroyBooster(collision2D.otherCollider.GetComponent<Booster>());
            }
        }

        private void DestroyBooster(Booster booster)
        {
            Object.Destroy(booster.gameObject);
        }
        
        
    }
}