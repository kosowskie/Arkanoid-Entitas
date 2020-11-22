//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AccelerationComponent acceleration { get { return (AccelerationComponent)GetComponent(GameComponentsLookup.Acceleration); } }
    public bool hasAcceleration { get { return HasComponent(GameComponentsLookup.Acceleration); } }

    public void AddAcceleration(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Acceleration;
        var component = (AccelerationComponent)CreateComponent(index, typeof(AccelerationComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAcceleration(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Acceleration;
        var component = (AccelerationComponent)CreateComponent(index, typeof(AccelerationComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAcceleration() {
        RemoveComponent(GameComponentsLookup.Acceleration);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAcceleration;

    public static Entitas.IMatcher<GameEntity> Acceleration {
        get {
            if (_matcherAcceleration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Acceleration);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAcceleration = matcher;
            }

            return _matcherAcceleration;
        }
    }
}
