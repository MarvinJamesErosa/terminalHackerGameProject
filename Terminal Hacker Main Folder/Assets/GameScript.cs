using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
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
    string[] university = { "exam", "dean", "book", "class" };
    string[] corporate = { "finance", "growth", "culture", "planning", "manager" };
    string[] natdef = { "missiles", "strategy", "generals", "discipline", "tacticians" };

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
        StartCoroutine(MenuEnum());

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
            NatDef();
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
        if (answer == selectedWord & currentScreen == Screen.University )
        {
            StartCoroutine(UniversityEnumCongrats());
        }
        else if (answer == selectedWord & currentScreen == Screen.Corporate)
        {
            StartCoroutine(CorporateEnumCongrats());
        }
        else if (answer == selectedWord & currentScreen == Screen.NatDef)
        {
            StartCoroutine(NatDefEnumCongrats());
        }
        else
        {
            if (currentScreen == Screen.University)
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Changing IP Address...\n");
                StartCoroutine(UniversityEnum(scrambledWord));
            }
            else if (currentScreen == Screen.Corporate)
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Changing IP Address...\n");
                StartCoroutine(CorporateEnum(scrambledWord));
            }
            else if (currentScreen == Screen.NatDef)
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Changing IP Address...\n");
                StartCoroutine(NatDefEnum(scrambledWord));
            }
            
        }
    }
    IEnumerator MenuEnum()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + userName + "," + "\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Blarvard University");
        Terminal.WriteLine("Press 2 for Shmapple Inc.");
        Terminal.WriteLine("Press 3 for Deparment of Defences");
        Terminal.WriteLine("Type \"close\" to go back.\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Enter your Selection:");
    }
    IEnumerator UniversityEnum(string word)
    {
        Terminal.WriteLine("~Blarvard University Login~\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Executing Forget Password Script...\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Forget Password Clue: " + word + "\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Password: \n");
    }
    IEnumerator CorporateEnum(string word)
    {
        Terminal.WriteLine("~Shmapple Inc. Login~\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Executing Forget Password Script...\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Forget Password Clue: " + word + "\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Password: \n");
    }
    IEnumerator NatDefEnum(string word)
    {
        Terminal.WriteLine("~Department of Defensor Login~\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Executing Forget Password Script...\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Forget Password Clue: " + word + "\n");
        yield return new WaitForSeconds(1);
        Terminal.WriteLine("Password: \n");
    }
    IEnumerator UniversityEnumCongrats()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Connecting to server...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Verifying login credentials...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Login successful!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Welcome back, Professor " + userName + "!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Executing Change Grade Script...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Please wait while the system loads...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Script Loaded Successfully!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Type \"menu\" to go back.\n");
    }
    IEnumerator CorporateEnumCongrats()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Connecting to Shmapple Inc. server...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Verifying login credentials...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("login successful!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Welcome back, Sir " + userName + "!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Executing Get Iphony 25 Schematics Script...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Please wait while the system loads...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Script Loaded Successfully!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Type \"menu\" to go back.\n");
    }
    IEnumerator NatDefEnumCongrats()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Connecting to Department of Defensor server...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Verifying login credentials...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("login successful!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Welcome back, General " + userName + "!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Executing Get Nuclear Launch Code Script...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Please wait while the system loads...\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Script Loaded Successfully!\n");
        yield return new WaitForSeconds(2);
        Terminal.WriteLine("Type \"menu\" to go back.\n");
    }
    // Each Level Functions
    void University()
    {
        currentScreen = Screen.University;
        arrayUsed = university;
        arrayUsedLen = university.Length;

        WordScrambler();
        Terminal.ClearScreen();
        StartCoroutine(UniversityEnum(scrambledWord));
    }    

    void Corporate()
    {
        currentScreen = Screen.Corporate;
        arrayUsed = corporate;
        arrayUsedLen = corporate.Length;

        WordScrambler();
        Terminal.ClearScreen();
        StartCoroutine(CorporateEnum(scrambledWord));
    }

    void NatDef()
    {
        currentScreen = Screen.NatDef;
        arrayUsed = natdef;
        arrayUsedLen = natdef.Length;

        WordScrambler();
        Terminal.ClearScreen();
        StartCoroutine(NatDefEnum(scrambledWord));
    }

}
