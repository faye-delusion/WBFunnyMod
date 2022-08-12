using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using System;

namespace WBFunnyMod.Entities.Hostile
{

    public class JoeBiden : ModNPC
    {

        public override void SetStaticDefaults(){

            DisplayName.SetDefault("JOE BIDEN");

            Main.npcFrameCount[Type] = 1;

        }

        public override void SetDefaults(){

            NPC.width = 84;
            NPC.height = 86;
            NPC.damage = 200;
            NPC.defense = 0;
            NPC.lifeMax = 750000;
            NPC.value = 66666666;
            
            AIType = NPCID.DemonEye;
            NPC.aiStyle = NPCID.DemonEye;

        }

        public override void ModifyNPCLoot(NPCLoot npcLoot){

            npcLoot.Add(ItemDropRule.Common(ItemID.IceCream, 1));

        }

        public override float SpawnChance(NPCSpawnInfo spawninfo){

            return SpawnCondition.OverworldNightMonster.Chance * 0.01f;

        }

    }

}