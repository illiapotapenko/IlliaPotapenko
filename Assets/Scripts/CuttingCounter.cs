using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
   [SerializeField] private CuttingRecipeSO[] _cuttingRecipeSOArray;
   public override void Interact(Player player)
   {
      if (!HasKitchenObject())
      {
         if (player.HasKitchenObject())
         {
            player.GetKitchenObject().SetKitchenObjectParent(this);
         }
      }else
      {
         if (!player.HasKitchenObject())
         {
            this.GetKitchenObject().SetKitchenObjectParent(player);
         }
      }
   }

   public override void InteractAlternate(Player player)
   {
      if (HasKitchenObject())
      {
         KitchenObjectSO outputKitchenObjectSo = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
         
         if(outputKitchenObjectSo == null) return;
         
         GetKitchenObject().DestroySelf();

         KitchenObject.SpawnKitchenObject(outputKitchenObjectSo, this);
      }
   }

   private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
   {
      foreach (var cuttingRecipeSo in _cuttingRecipeSOArray)
      {
         if (cuttingRecipeSo.input == inputKitchenObjectSO)
         {
            return cuttingRecipeSo.output;
         }
      }

      return null;
   }
}
