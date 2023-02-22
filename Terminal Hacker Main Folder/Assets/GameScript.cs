using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    enum Screen { NameSelect, MainMenu, University, Corporate, NatDef } // To indicate what level are we on
    Screen currentScreen;
    string userName; // To store the user's name
    string[] arrayUsed; // To indicate what set of words to choose from
    int arrayUsedLen; // To get the length of the set for max random
    string selectedWord; // To store the selected word
    string scrambledWord; //  To store the scrambled word

    // Word Set for each level
    string[] university = { "exam", "dean", "book", "Class" };
    string[] corporate = { "", "handcuffs", "holster", "uniform", "arrest" };
    string[] natdef = { "missile", "weapons", "general", "exploration", "astronauts" };

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
        Terminal.WriteLine("");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Blarvard University");
        Terminal.WriteLine("Press 2 for Shmapple Inc.");
        Terminal.WriteLine("Press 3 for Deparment of Defences");
        Terminal.WriteLine("Type \"close\" to close the application");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your Selection:");
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
            University();
        }

        else if (input == "2" & currentScreen == Screen.MainMenu)
        {
           Corporate();
        }

        else if (input == "3" & currentScreen == Screen.MainMenu)
        {
            NASA();
        }

        else if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "close")
        {
            Debug.Log("close pc");
            Application.Quit();
        }
         else if(currentScreen == Screen.MainMenu & !(input == "secret")) 
        {
            ShowMainMenu();
            Terminal.WriteLine("Invalid input. Please try again.");
        }
        else if (!(currentScreen == Screen.MainMenu) || !(currentScreen == Screen.NameSelect))
        {
            ShowWinScreen(input);
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

    void ShowWinScreen(string answer)
    {
        if (answer == selectedWord)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congrats on beating the terminal hackergame! Your coding and logical skills areimpressive, and your dedication has paidoff. Keep up the great work and may you continue to succeed in all your future  endeavors. Well done!");
            Terminal.WriteLine("");
            Terminal.WriteLine("Type \"menu\" to go back");
        }
        else
        {
            string level = null;
            if (currentScreen == Screen.University)
            {
                level = "Level 1 - Blarvard University";
                Terminal.ClearScreen();
                Terminal.WriteLine(level);
                Terminal.WriteLine("Clue: " + scrambledWord);
            }
            else if (currentScreen == Screen.Corporate)
            {
                level = "Level 2 - Shmapple Inc.";
                Terminal.ClearScreen();
                Terminal.WriteLine(level);
                Terminal.WriteLine("Clue: " + scrambledWord);
            }
            else if (currentScreen == Screen.NatDef)
            {
                level = "Level 3 - Department of Defences";
                Terminal.ClearScreen();
                Terminal.WriteLine(level);
                Terminal.WriteLine("Clue: " + scrambledWord);
            }
            
        }
    }
    // Each Level Functions
    void University()
    {
        currentScreen = Screen.University;
        arrayUsed = university;
        arrayUsedLen = university.Length;

        WordScrambler();

        Terminal.ClearScreen();
        Terminal.WriteLine("Level 1 - Blarvard University");
        Terminal.WriteLine("Clue: " + scrambledWord);
    }

    void Corporate()
    {
        currentScreen = Screen.Corporate;
        arrayUsed = corporate;
        arrayUsedLen = corporate.Length;

        WordScrambler();

        Terminal.ClearScreen();
        Terminal.WriteLine("Level 2 - Shmapple Inc.");
        Terminal.WriteLine("Clue: " + scrambledWord);
    }

    void NASA()
    {
        currentScreen = Screen.NatDef;
        arrayUsed = natdef;
        arrayUsedLen = natdef.Length;

        WordScrambler();

        Terminal.ClearScreen();
        Terminal.WriteLine("Level 3 - Department for Defences");
        Terminal.WriteLine("Clue: " + scrambledWord);
    }

}
