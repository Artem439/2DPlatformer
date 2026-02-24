using System;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public interface ISpawnable<T> where T : Component
    {
        event Action<T> Released;
        void Reset(Vector2 position);
    }
}