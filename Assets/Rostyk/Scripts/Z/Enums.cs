using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RostykEnums
{
    // Перечисление игровых режимов
    public enum Gamemode
    {
        creative = 0,
        survival = 1,
        hardcore = 2,
        infernum = 3,
    }

    // 
    public enum WeaponMode
    {
        Knife = 1,
        Weapon = 2,
        Grenade = 3,
    }

    // 100% будет
    public enum Knife
    {
        Hand = 0,
        Hammer = 1,
        Sword = 2,
        Blades = 3
    }

    // 100% будет
    public enum Weapon
    {
        Gun = 0,
        DoubleGun = 1,
        Shotgun = 2
    }

    // под вопросом
    public enum Grenade
    {
        Grenade = 0,
        Molotov = 1,
        Flashbang = 2
    }

    // Перечисление вкладок меню
    public enum Tab
    {
        Inventory = 0,
        Notes = 1,
        Map = 2,
        Settings = 3,
        Dev = 4
    }
}
