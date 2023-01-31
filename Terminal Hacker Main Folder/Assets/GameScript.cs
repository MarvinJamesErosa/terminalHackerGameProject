using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    string name;
    int count = 0;
    void Start()
    {
        AskUserName();
    }
    
    void AskUserName()
    {
        Terminal.WriteLine("What do you want to be called:");
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + name + ",");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the local police station");
        Terminal.WriteLine("Press 3 for NASA");
    }
    void OnUserInput(string input)
    {
        if (count == 0)
        {
            name = input;
            count++;
            ShowMainMenu();
        }

    }
    
    
}
