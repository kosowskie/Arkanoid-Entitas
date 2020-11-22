using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class BlockType
{
    public char ColorCharacter;
    public Sprite Sprite;
}

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject BlockPrefab;

    [SerializeField]
    BlockType[] BlockTypes;

	public void GenerateLevel(string levelName)
    {
        var level = LoadLevel(levelName);
        GenerateBlocks(level);
    }

    BlockType[][] LoadLevel(string name)
    {
        var path = "Assets/levels/" + name + ".txt";
        var text = AssetDatabase.LoadAssetAtPath<TextAsset>(path).text;

        var lines = Regex.Split(text, System.Environment.NewLine);
        return ParseLines(lines);
    }

    BlockType ParseCharacter(char character)
    {
        return BlockTypes
            .FirstOrDefault(block => block.ColorCharacter == character);
    }

    BlockType[] ParseLine(string text)
    {
        return text
            .Select(ParseCharacter)
            .ToArray();
    }

    BlockType[][] ParseLines(string[] text)
    {
        return text
            .Select(ParseLine)
            .ToArray();
    }

    void GenerateBlocks(BlockType[][] blocks)
    {
        var height = blocks.Length;
        var width = blocks[0].Length;

        for(int x=0; x<width; x++)
        {
            for(int y=0; y<height; y++)
            {
                var block = blocks[y][x];

                if (block == null)
                    continue;

                var position = new Vector2(
                    x - width/2,
                    -y + height/2);

                GenerateBlock(block.Sprite, position);
            }
        }
    }

    void GenerateBlock(Sprite sprite, Vector2 position)
    {
        var block = Instantiate(BlockPrefab);

        block.transform.parent = transform;
        block.transform.localPosition = position;

        block.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
