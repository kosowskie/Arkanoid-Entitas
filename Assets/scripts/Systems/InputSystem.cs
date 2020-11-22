using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        Debug.Log(horizontal);

        _contexts.game.ReplaceInputCompontent(new Vector3(horizontal, 0f, 0f));
    }
}