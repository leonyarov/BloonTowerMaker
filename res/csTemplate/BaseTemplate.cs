using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using /*tower*/.Displays.Projectiles; //projectile namespace
using MelonLoader;

namespace /*tower*/
{
    public class /*tower*/ : ModTower
    {
        // public override string Portrait => "Don't need to override this, using the default of Name-Portrait";
        // public override string Icon => "Don't need to override this, using the default of Name-Icon";

        public override string TowerSet => /*TowerSet*/;
        public override string BaseTower => /*BaseTower*/;
        public override int Cost => /*Cost*/;

        public override int TopPathUpgrades => /*TopPathUpgrades*/;
        public override int MiddlePathUpgrades => /*MiddlePathUpgrades*/;
        public override int BottomPathUpgrades => /*BottomPathUpgrades*/;
        public override string Description => /*Description*/;

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Card Monkey'"

        public override ParagonMode ParagonMode => /*ParagonMode*/;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range += /*range*/;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += /*attack_range*/;

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay</*projectile*/>(); //set projectile sprite
            projectile.pierce += /*pierce*/;
        }

        /// <summary>
        /// Make Card Monkey go right after the Boomerang Monkey in the shop
        /// <br/>
        /// If we didn't have this, it would just put it at the end of the Primary section
        /// </summary>
    /*
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.BoomerangMonkey).towerIndex + 1;
    }*/

    /// <summary>
    /// Support the Ultimate Crosspathing Mod by generating all the Tower Tiers if the mod exists
    /// <br/>
    /// That mod will handle actually allowing the upgrades to happen in the UI
    /// </summary>
    /*
    public override IEnumerable<int[]> TowerTiers()
    {
        if (MelonHandler.Mods.OfType<BloonsTD6Mod>().Any(m => m.GetModName() == "UltimateCrosspathing"))
        {
            for (var top = 0; top <= TopPathUpgrades; top++)
            {
                for (var mid = 0; mid <= MiddlePathUpgrades; mid++)
                {
                    for (var bot = 0; bot <= BottomPathUpgrades; bot++)
                    {
                        yield return new[] { top, mid, bot };
                    }
                }
            }
        }
        else
        {
            foreach (var towerTier in base.TowerTiers())
            {
                yield return towerTier;
            }
        }
    }
      */

    } //end class
} //end namespace
