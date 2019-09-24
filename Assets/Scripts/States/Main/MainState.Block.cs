using System.Collections.Generic;
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
        private List<Block> _blocks = new List<Block>();

        private Block SpawnBlock(Vector2 position, BlockData blockData)
        {
            var block = Object.Instantiate(
                    Resources.Load<GameObject>(
                        ResourcesNames.PrefabsNames.BLOCK
                    )
                )
                .GetComponent<Block>();
            block.Initialize(blockData);
            block.transform.position = position;
            _blocks.Add(block);
            return block;
        }

        private void DestroyBlock(Block block)
        {
            if (_blocks.Remove(block))
            {
                Object.Destroy(block.gameObject);
            }
        }

        private void InitializeBlocks()
        {
            var startBlockOffset = new Vector2(-Configs.LEVEL_BLOCKS_GRID_WIDTH / 2 * Configs.BLOCK_WIDTH,
                -Configs.LEVEL_BLOCKS_GRID_HEIGHT * Configs.BLOCK_HEIGHT + Configs.LEVEL_WALLS_HEIGHT / 2);
            for (int i = 0; i < Configs.LEVEL_BLOCKS_GRID_HEIGHT; i++)
            {
                for (int j = 0; j < Configs.LEVEL_BLOCKS_GRID_WIDTH; j++)
                {
                    var needCreate = Random.Range(0, 100) > 50;
                    if (needCreate)
                    {
                        var block = SpawnBlock(
                            startBlockOffset + new Vector2(j * Configs.BLOCK_WIDTH, i * Configs.BLOCK_HEIGHT),
                            _levelBlockDatas.GetRandomElement());    
                    }
                }
            }
        }

        private void DeinitializeBlocks()
        {
            while (_blocks.Count > 0)
            {
                DestroyBlock(_blocks.First());
            }
        }
    }
}