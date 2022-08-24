﻿using FrooxEngine;

namespace NEOSPlus.Components.Physics
{
    public class ClothCapsuleConnector : UnityBetterComponentConnector<ClothCapsuleCollider, UnityEngine.CapsuleCollider>
    {
        public override void ApplyChanges()
        {
            unityComponent.radius = Owner.Radius.Value;
            unityComponent.height = Owner.Height.Value;
        }
    }
}
