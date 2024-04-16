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

    public enum WeaponMode
    {
        Knife = 1,
        Weapon = 2,
        Grenade = 3,
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
