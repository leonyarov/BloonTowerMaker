using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace /*tower*/
{
    public class /*upgrade*/ : ModUpgrade</*tower*/>
    {
        public override int Path { get { return /*path*/; } } 
        public override int Tier { get { return /*tier*/; } } 
        public override int Cost { get { return /*cost*/; } } 
        public override int Priority { get { return /*priority*/; ; } } 

        public override string Description { get { return "/*description*/"; } } 

        public override string Portrait { get { return "/*portrait*/"; } } 

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.pierce += /*pierce*/;
            //weaponModel.emission = new EmissionWithOffsetsModel("EmissionWithOffsetsModel_", new[]
            //{
            //    new ThrowMarkerOffsetModel("ThrowMarkerOffsetModel_", -4, 0, 0, 0)
            //}, 1, false, null, 0);

            //TODO: Projectile count
            //for (var i = 1; i <= 1; i++)
            //{
            //    var newWeapon = weaponModel.Duplicate();
            //    newWeapon.projectile.GetDamageModel().damage += /*damage*/;
            //    newWeapon.emission.Cast<EmissionWithOffsetsModel>().throwMarkerOffsetModels[0].ejectX += i * 2;
            //    tower.GetAttackModel().AddWeapon(newWeapon);
            //}
            //TODO: Projectile count, not duplicated
            //tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 15, null, false);

            //TODO: per tier changes
            //if (tower.tier == 5)
            //{
            //    weaponModel.projectile.pierce += 30;
            //}
            //else
            //{
            //    weaponModel.projectile.pierce += 3;
            //}
            //Any tier change, should be like this ^^^
            //TODO: Firerate
            //weaponModel.Rate *= /*firerate*/;
        }
            tower.range += /*range*/;
            tower.GetAttackModel().range += /*attack_range*/;
        }
    }
}