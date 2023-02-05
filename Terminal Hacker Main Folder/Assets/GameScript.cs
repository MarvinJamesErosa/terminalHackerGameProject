using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    enum Screen { NameSelect, MainMenu, LocalLibraryLevel}
    Screen currentScreen;
    string userName;
    string[] arrayUsed;
    int arrayUsedLen;
    string[] library = { "books", "pencil", "librarian" };

    void Start()
    {
        currentScreen = Screen.NameSelect;
        AskUserName();
    }
    
    void AskUserName()
    {
        Terminal.WriteLine("What do you want to be called:"); 
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + name + ",");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the local police station");
        Terminal.WriteLine("Press 3 for NASA");
    }
    void OnUserInput(string input)
    {
        if (currentScreen == Screen.NameSelect)
        {
            userName = input;
            ShowMainMenu();
        }

        else if (input == "1" & currentScreen == Screen.MainMenu)
        {
            LocalLibrary();
        }

        else if (input == "menu")
        {
            ShowMainMenu();
        }
    }
    void WordSelection()
    {
        System.Random rd = new System.Random();
        int word = rd.Next(0, arrayUsedLen);
        Terminal.WriteLine("Password: " + arrayUsed[word]);
    }
    void LocalLibrary()
    {
        currentScreen = Screen.LocalLibraryLevel;
        arrayUsed = library;
        arrayUsedLen = library.Length;
        Terminal.ClearScreen();
        Terminal.WriteLine("Level 1 - Local Library");
        WordSelection();

    }
    
    
}
