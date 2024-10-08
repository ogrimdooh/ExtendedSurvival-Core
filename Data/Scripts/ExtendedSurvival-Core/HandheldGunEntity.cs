﻿using VRage;
using VRage.Game;
using Sandbox.Game;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using Sandbox.ModAPI.Weapons;
using System.Linq;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Core
{

    public class HandheldGunEntity : EntityBase<IMyAutomaticRifleGun>
    {

        private MyInventory AmmoInventory;
        public int CurrentMagazineAmmunition { get; private set; }

        public bool HasInventory
        {
            get
            {
                return AmmoInventory != null;
            }
        }

        public HandheldGunEntity(IMyAutomaticRifleGun entity)
            : base(entity)
        {            
            TryToLoadInventory();
        }

        public void TryToLoadInventory()
        {
            if (Entity != null)
            {
                if (AmmoInventory == null && Entity.WeaponInventory != null)
                    AmmoInventory = Entity.WeaponInventory;
                if (AmmoInventory == null && Entity.AmmoInventory != null)
                    AmmoInventory = Entity.AmmoInventory;
                if (AmmoInventory == null && Entity.Owner != null)
                    AmmoInventory = Entity.Owner.GetInventory();
                if (AmmoInventory != null)
                    AmmoInventory.ContentsRemoved += AmmoInventory_ContentsRemoved;
            }
        }

        public void StoreCurrentAmmo()
        {
            if (AmmoInventory == null)
                TryToLoadInventory();
            if (Entity != null && !Entity.IsReloading)
            {
                CurrentMagazineAmmunition = Entity.CurrentMagazineAmmunition;
                if ((Entity.IsShooting || CurrentMagazineAmmunition == 1) && CurrentMagazineAmmunition > 0)
                    CurrentMagazineAmmunition -= 1; /* Avoid returning plus one ammo at quik reload */
            }
        }

        public UniqueEntityId GetCurrentAmmoMagazineId()
        {
            return new UniqueEntityId(Entity.GunBase.CurrentAmmoMagazineId);
        }

        private void AmmoInventory_ContentsRemoved(MyPhysicalInventoryItem inventoryItem, MyFixedPoint point)
        {
            var removedId = new UniqueEntityId(inventoryItem.Content.TypeId, inventoryItem.Content.SubtypeId);
            if (removedId == GetCurrentAmmoMagazineId() && Entity.IsReloading)
            {
                if (ExtendedSurvivalEntityManager.ReloadHandheldGun.Any())
                {
                    foreach (var reloadEvent in ExtendedSurvivalEntityManager.ReloadHandheldGun)
                    {
                        reloadEvent.Action?.Invoke(Entity, CurrentMagazineAmmunition, Entity.GunBase.CurrentAmmoMagazineId, AmmoInventory);
                    }
                }
            }
        }

    }

}