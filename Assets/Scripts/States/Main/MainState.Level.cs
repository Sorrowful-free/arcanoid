using System.Linq;
using DataBases;
using DefaultNamespace;
using Extensions;
using GamePlayFramework;
using UnityEngine;

namespace States.Main
{
    public partial class MainState
    {
        private int _levelIndex;
        private LevelData _levelData;
        private BlockData[] _levelBlockDatas;
        private BoosterData[] _levelBoosterDatas;

        private Wall _topWall;
        private Wall _leftWall;
        private Wall _rightWall;
        private Wall _bottomWall;

        private void InitializeLevel(int levelIndex)
        {
            _levelIndex = Mathf.Max(0,Mathf.Min(levelIndex,GameApplication.LevelsDataBase.Levels.Length-1));
            _levelData = GameApplication.LevelsDataBase.Levels[_levelIndex];
            _levelBlockDatas = _levelData.AvailableBlocks.Select(e => GameApplication.BlocksDataBase.Blocks[e])
                .ToArray();
            _levelBoosterDatas = _levelData.AvailableBoosters.Select(e => GameApplication.BoostersDataBase.Boosters[e])
                .ToArray();

            var wallsOffset = new Vector2(0, 0); //Configs.LEVEL_WALLS_HEIGHT / 2);

            _topWall = CreateWall(new Vector2(Configs.LEVEL_WALLS_WIDTH, Configs.BLOCK_HEIGHT),
                new Vector2(0, Configs.LEVEL_WALLS_HEIGHT / 2 + wallsOffset.y));

            _leftWall = CreateWall(new Vector2(Configs.RACKET_SIZE_HEIGHT, Configs.LEVEL_WALLS_HEIGHT),
                new Vector2(-Configs.LEVEL_WALLS_WIDTH / 2, wallsOffset.y));

            _rightWall = CreateWall(new Vector2(Configs.BLOCK_HEIGHT, Configs.LEVEL_WALLS_HEIGHT),
                new Vector2(Configs.LEVEL_WALLS_WIDTH / 2, wallsOffset.y));

            _bottomWall = CreateWall(new Vector2(Configs.LEVEL_WALLS_WIDTH, Configs.BLOCK_HEIGHT),
                new Vector2(0, -Configs.LEVEL_WALLS_HEIGHT / 2 + wallsOffset.y));


            
        }

        private void DeinitializeLevel()
        {
            DestroyWall(_topWall);
            DestroyWall(_leftWall);
            DestroyWall(_rightWall);
            DestroyWall(_bottomWall);
        }

        private Wall CreateWall(Vector2 size, Vector2 position)
        {
            var wall = Object.Instantiate(
                Resources.Load<GameObject>(
                    ResourcesNames.PrefabsNames.WALL
                )
            ).GetComponent<Wall>();
            wall.Initialize(size, position);
            return wall;
        }

        private void DestroyWall(Wall wall)
        {
            Object.Destroy(wall.gameObject);
        }
    }
}