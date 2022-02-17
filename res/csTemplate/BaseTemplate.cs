using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
//using /*tower*/.Displays.Projectiles; //projectile namespace
using MelonLoader;

namespace /*tower*/
{
    public class Tower : ModTower
    {
        // public override string Portrait { get { return "/*LatestURL*/"; } } "Don't need to override this, using the default of Name-Portrait";
        // public override string Icon { get { return "/*LatestURL*/"; } } "Don't need to override this, using the default of Name-Icon";
        /*VARIABLES*/
        public override string TowerSet { get { return /*TowerSet*/; } } 
        public override string BaseTower { get { return /*BaseTower*/; } } 
        public override int Cost { get { return /*Cost*/; } } 

        public override int TopPathUpgrades { get { return /*TopPathUpgrades*/; } } 
        public override int MiddlePathUpgrades { get { return /*MiddlePathUpgrades*/; } } 
        public override int BottomPathUpgrades { get { return /*BottomPathUpgrades*/; } } 
        public override string Description { get { return "/*Description*/"; } } 

        // public override string DisplayName { get { return "/*LatestURL*/"; } } "Don't need to override this, the default turns it into 'Card Monkey'"

        public override ParagonMode ParagonMode { get { return /*ParagonMode*/; } } 

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range += /*range*/;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += /*attack_range*/;

            var projectile = attackModel.weapons[0].projectile;
            //  projectile.ApplyDisplay</*projectile*/>(); //set projectile sprite
            projectile.pierce += /*pierce*/;
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += /*damage*/;
            }
        }
    } //end class
} //end namespace
 