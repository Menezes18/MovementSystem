using System;
using UnityEngine;

namespace MenezesMovementSystem
{
    [Serializable]
    public class CapsuleColliderUtility 
    {
       public CapsuleColliderData CapsuleColliderData { get; private set; }
       [field: SerializeField] public DefaultColliderData DefaultColliderData { get; private set; }
       [field: SerializeField] public SlopeData SlopeData { get; private set; }

       public void Initialize(GameObject gameObject)
       {
           if (CapsuleColliderData != null)
           {
               return;
           }
           CapsuleColliderData = new CapsuleColliderData();
           CapsuleColliderData.Initialize(gameObject);
       }
       public void CalculateCapsuleColliderDimensions()
       {
           SetCapsuleColliderRadius(DefaultColliderData.Radius);
           
           SetCapsuleColliderHeight(DefaultColliderData.Heigh * (1f - SlopeData.StepHeightPercentage));

           RecalculateCapsuleColliderCenter();

           float halfColliderHeight = CapsuleColliderData.Collider.height / 2f;
           
           if (halfColliderHeight< CapsuleColliderData.Collider.radius)
           {
               SetCapsuleColliderRadius(halfColliderHeight);
           } 
           CapsuleColliderData.UpdateColliderData();
       }


       public void SetCapsuleColliderRadius(float radius)
       {
           CapsuleColliderData.Collider.radius = radius;
       }
       public void SetCapsuleColliderHeight(float height)
       {
           CapsuleColliderData.Collider.height = height;
       }
       public void RecalculateCapsuleColliderCenter()
       {
           float colliderHeightDifference = DefaultColliderData.Heigh - CapsuleColliderData.Collider.height;
           Vector3 newColliderCenter =
               new Vector3(0f, DefaultColliderData.CenterY + (colliderHeightDifference / 2), 0f);
           CapsuleColliderData.Collider.center = newColliderCenter;
       }
    }
}
