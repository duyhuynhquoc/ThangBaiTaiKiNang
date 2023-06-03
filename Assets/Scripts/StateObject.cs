using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "StateObject", menuName = "StateObject", order = 0)]
public class StateObject : ScriptableObject
{
    [SerializeField]
    public AnimationClip animationClip;

    [SerializeField]
    public InputActionReference inputAction;

    [SerializeField]
    public StateObject[] nextStateObjects;

    public String GetAnimationClipName()
    {
        return animationClip.name;
    }
}
