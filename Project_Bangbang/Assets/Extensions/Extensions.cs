using System;
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

    public static void SetSpawnPosition (this UnityView view)
    {
        if (view.Entity.hasViewData && view.Entity.viewData.spawnPositionID.Length > 0)
        {
            var inputety = view.Contexts.input.CreateEntity();
            inputety.AddInputNewPosition(view.ID, ScenePositionUtility.Instance.GetSpawnPosition(view.Entity.viewData.spawnPositionID));
        }
    }

    public static void SetParent (this UnityView view)
    {
        if (view.Entity.hasViewData && view.Entity.viewData.parentID != "")
        {
            view.transform.SetParent(ScenePositionUtility.Instance.GetParent(view.Entity.viewData.parentID), false);
        }
    }
}

