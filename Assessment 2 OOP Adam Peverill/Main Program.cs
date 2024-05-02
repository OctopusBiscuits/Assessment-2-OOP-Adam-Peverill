using Assessment_2_OOP_Adam_Peverill;
using System;


class MainProgram
{
    static void Main(string[] args)
    {
        // starts the program by taking the user to the game select menu.

        GameSelection Game = new GameSelection();

        Game.Game_select();

    }


}


