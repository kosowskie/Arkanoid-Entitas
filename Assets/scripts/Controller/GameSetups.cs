using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[CreateAssetMenu]
[Game, Unique]
public class GameSetups : ScriptableObject
{
    public GameObject player;
    public GameObject ball;
    public GameObject[] block;
    public GameObject deadZone;

    public int height = 4;
    public int width = 6;

    public float playerMovementSpeed = 5f;
    public float ballSpeed = 5f;
}