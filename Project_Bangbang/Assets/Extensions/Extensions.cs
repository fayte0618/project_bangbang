﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public static class Extensions
{
    public static void CreateInputCollision(this Collider2D other, UnityView self, CollisionType state)
    {
        var otherEntity = other.GetComponentInChildren<UnityView>();
        if (otherEntity == null) { otherEntity = other.GetComponentInParent<UnityView>(); }
        if (otherEntity != null)
        {
            var input = self.Contexts.input.CreateEntity();
            input.AddInputCollision(self.ID, otherEntity.ID, state);
        }
    }
}
