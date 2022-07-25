using VRage;
using VRage.Game;
using Sandbox.Game;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using Sandbox.ModAPI.Weapons;

namespace ExtendedSurvival
{

    public delegate void OnReloadHandheldGunEntity(HandheldGunEntity sender, int currentAmmo, UniqueEntityId magzineId);

    public class HandheldGunEntity : EntityBase<IMyAutomaticRifleGun>
    {

        private MyInventory AmmoInventory;
        private int CurrentMagazineAmmunition;

        public event OnReloadHandheldGunEntity OnReload;

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
            if (Entity != null && !Entity.IsReloading)
                CurrentMagazineAmmunition = Entity.CurrentMagazineAmmunition;
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
                OnReload?.Invoke(this, CurrentMagazineAmmunition, removedId);
            }
        }

    }

}