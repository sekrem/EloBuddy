﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace LazyLucian
{
    internal class ComboHandler
    {
        public static void Combo()
        {
            var target = TargetSelector.SelectedTarget != null &&
                         TargetSelector.SelectedTarget.Distance(ObjectManager.Player) < 20000
                ? TargetSelector.SelectedTarget
                : TargetSelector.GetTarget(1500, DamageType.Physical);

            if (target == null ||
                (Init.ComboMenu["spellWeaving"].Cast<CheckBox>().CurrentValue && Events.PassiveUp) ||
                Orbwalker.IsAutoAttacking ||
                ObjectManager.Player.IsDashing())
                return;


            if (Spells.Q.IsReady())
            {
                if (Init.ComboMenu["useQcombo"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastQ();
                }
                if (Init.ComboMenu["useQextended"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastExtendedQ();
                }
            }

            if (Spells.W.IsReady())
            {
                if (Init.ComboMenu["useWaaRange"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastWinRange();
                }
                if (Init.ComboMenu["useWalways"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastWcombo();
                }
            }

            if (Spells.E.IsReady())
            {
                if (Init.ComboMenu["useEcombo"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastEcombo();
                }
                if (Init.ComboMenu["useEgap"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastEgap();
                }
            }

            if (!Spells.R.IsReady()) return;
            {
                if (Init.ComboMenu["useRkillable"].Cast<CheckBox>().CurrentValue)
                {
                    Spells.CastR();
                }
            }
        }
    }
}