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

    // Перечисление режима оружия
    public enum WeaponMode
    {
        Knife = 1,
        Weapon = 2,
        Grenade = 3,
    }

    // Перечисление оружий ближнего боя
    public enum Knife
    {
        Hand = 0,
        Hammer = 1,
        Sword = 2,
        Blades = 3
    }

    // Перечисление оружий дальнего боя
    public enum Weapon
    {
        Gun = 0,
        DoubleGun = 1,
        Shotgun = 2
    }

    // Перечисление гранат
    public enum Grenade
    {
        Grenade = 0,
        Molotov = 1,
        Flashbang = 2
    }

    // Перечисление вкладок меню
    public enum TabMenu
    {
        Inventory = 0,
        Notes = 1,
        Map = 2,
        Settings = 3,
        Dev = 4
    }

    // Вкладки настроек в главном меню
    public enum TabMainMenu
    {
        Control = 0,
        Graphics = 1,
        Language = 2,
        Secret = 3
    }
}
