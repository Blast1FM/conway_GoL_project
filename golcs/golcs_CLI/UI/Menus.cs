namespace golcs.UI;

public class Menus
{
    public static int Get_int_from_console()
    {
        if(int.TryParse(Console.ReadLine(), out int number)) return number;
        else return -1; 
    }
    public static int Main_menu()
    {
        System.Console.WriteLine
        (
            @"1.Load megasave
            2.Create new megasave
            0.Exit"
        );
        return Get_int_from_console();
    }
}
