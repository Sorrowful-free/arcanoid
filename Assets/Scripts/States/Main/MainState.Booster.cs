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
        }

        private void DestroyBooster(Booster booster)
        {
            Object.Destroy(booster.gameObject);
        }
    }
}