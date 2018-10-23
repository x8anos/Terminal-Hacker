using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    //Game configuration data
    string[] level1Passwords = { "brave", "solo", "goose", "horse" };
    string[] level2Passwords = { "maze", "attitude", "craftsman", "literally" };

    //Game State
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

	// Use this for initialization
	void Start () {
        // gameObject.SetActive(true);
        //  print("Hello Console");

        ShowMainMenu("Hello Thanos");       

    }

    void ShowMainMenu(string greeting)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;       
        //Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where do you want to enter?");
        Terminal.WriteLine("Choose 1 for elementary stuff.");
        Terminal.WriteLine("Choose 2 for medium level.");
        Terminal.WriteLine("Choose 3 for the real deal.");
        Terminal.WriteLine("Enter your choice:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Hello");          
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else (currentScreen == Screen.Win)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Congrats!!!");
           // CheckPassword(input);
        }
    }

    void CheckPassword(string input)
    {

        if (input == password)
        {
            currentScreen = Screen.Win;
           
        }
        else
        {
            Terminal.WriteLine("You missed!Give it another shot");
        }
        
    }

    private void RunMainMenu(string input)
    {

        if (input == "1")
        {
            level = 1;
            password = level1Passwords[0];
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Passwords[0];
            StartGame();
        }
        else { Terminal.WriteLine("Please choose a valid level"); }
    }

    void StartGame()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have selected level "+level);
        Terminal.WriteLine("Please select a password:");

    }
}
