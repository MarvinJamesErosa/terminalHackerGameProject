using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    enum Screen { NameSelect, MainMenu, LocalLibraryLevel, LocalPoliceStation, NASA } // To indicate what level are we on
    Screen currentScreen;
    string userName; // To store the user's name
    string[] arrayUsed; // To indicate what set of words to choose from
    int arrayUsedLen; // To get the length of the set for max random
    string selectedWord; // To store the selected word
    string scrambledWord; //  To store the scrambled word

    // Word Set for each level
    string[] library = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] police = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] nasa = { "starfield", "telescope", "environment", "exploration", "astronauts" };

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
        Terminal.WriteLine("Hello " + userName + ",");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the local police station");
        Terminal.WriteLine("Press 3 for NASA");
    }

    // For getting user input
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

        else if (input == "2" & currentScreen == Screen.MainMenu)
        {
            LocalPoliceStation();
        }

        else if (input == "3" & currentScreen == Screen.MainMenu)
        {
            NASA();
        }

        else if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (!(currentScreen == Screen.MainMenu) || !(currentScreen == Screen.NameSelect))
        {
            showWinScreen(input);
        }
    }

    // To randomly select the word from the chosen set
    void WordSelection()
    {
        System.Random rd = new System.Random();
        int word = rd.Next(0, arrayUsedLen - 1);
        selectedWord = arrayUsed[word];
    }

    // To scramble the selected word
    void WordScrambler()
    {
        WordSelection();
        char[] chars = selectedWord.ToCharArray();
        System.Random rd = new System.Random();

        for (int index = 0; index < chars.Length; index++)
        {
            int randomPos = rd.Next(chars.Length);
            char temp = chars[index];
            chars[index] = chars[randomPos];
            chars[randomPos] = temp;
        }

        scrambledWord = new string(chars);
    }

    void showWinScreen(string answer)
    {
        if (answer == selectedWord)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congrats");
        }
        else
        {
            string level = null;
            if (currentScreen == Screen.LocalLibraryLevel)
            {
                level = "Level 1 - Local Library";
            }
            else if (currentScreen == Screen.LocalPoliceStation)
            {
                level = "Level 2 - Local Police Station";
            }
            else if (currentScreen == Screen.NASA)
            {
                level = "Level 3 - NASA";
            }
            Terminal.ClearScreen();
            Terminal.WriteLine(level);
            Terminal.WriteLine("Password: " + scrambledWord);
        }
    }
    // Each Level Functions
    void LocalLibrary()
    {
        currentScreen = Screen.LocalLibraryLevel;
        arrayUsed = library;
        arrayUsedLen = library.Length;

        WordScrambler();

        Terminal.ClearScreen();
        Terminal.WriteLine("Level 1 - Local Library");
        Terminal.WriteLine("Password: " + scrambledWord);
    }

    void LocalPoliceStation()
    {
        currentScreen = Screen.LocalPoliceStation;
        arrayUsed = police;
        arrayUsedLen = police.Length;

        WordScrambler();

        Terminal.ClearScreen();
        Terminal.WriteLine("Level 2 - Local Police Station");
        Terminal.WriteLine("Password: " + scrambledWord);
    }

    void NASA()
    {
        currentScreen = Screen.NASA;
        arrayUsed = nasa;
        arrayUsedLen = nasa.Length;

        WordScrambler();

        Terminal.ClearScreen();
        Terminal.WriteLine("Level 3 - NASA");
        Terminal.WriteLine("Password: " + scrambledWord);
    }

}
