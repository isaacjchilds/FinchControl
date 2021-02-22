using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Finch_Control___Menu_Starter
{
    //########
    // Application: Finch Control - Menu Starter
    // Author: Childs, Isaac
    // Description: Starter solution with the opening,
    // closing, and menu screens.
    // Date Created: 2/20/21
    // Date Revised: 2/21/21
    //########
    class Program
    {
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                static void DisplayMenuScreen()
                {
                    Console.CursorVisible = true;

                    bool quitApplication = false;
                    string menuChoice;

                    Finch finchRobot = new Finch();

                    do
                    {
                        DisplayScreenHeader("Main Menu");

                        //###
                        //display menu options
                        //###
                        Console.WriteLine("\ta) Connect Finch");
                        Console.WriteLine("\tb) Talent Show");
                        Console.WriteLine("\tc) Alarm System");
                        Console.WriteLine("\td) User Programming");
                        Console.WriteLine("\te) Data Recorder");
                        Console.WriteLine("\tf) Disconnect Finch");
                        Console.WriteLine("\tq) Quit");
                        Console.Write("\t\tEnter Choice:");
                        menuChoice = Console.ReadLine().ToLower();

                        switch (menuChoice)
                        {
                            case "a":
                                DisplayConnectFinchRobot(finchRobot);
                                break;

                            case "b":
                                TalentShowDisplayMenuScreen(finchRobot);
                                break;

                            case "c":

                                break;

                            case "d":

                                break;

                            case "e":

                                break;

                            case "f":
                                DisplayDisconnectFinchRobot(finchRobot);
                                break;

                            case "q":
                                DisplayDisconnectFinchRobot(finchRobot);
                                quitApplication = true;
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine("\tEnter a letter for the menu choice.");
                                DisplayContinuePrompt();
                                break;
                        }
                    } while (!quitApplication);
                }

                #region TALENT SHOW

                static void TalentShowDisplayMenuScreen(Finch finchRobot)
                {
                    Console.CursorVisible = true;

                    bool quitTalentShowMenu = false;
                    string menuChoice;

                    do
                    {
                        DisplayScreenHeader("Talent Show");

                        Console.WriteLine("\ta) Light and Sound");
                        Console.WriteLine("\tb) Dance");
                        Console.WriteLine("\tc) Mixing it Up");
                        Console.WriteLine("\tq) Main Menu");
                        Console.Write("\t\tEnter Choice:");
                        menuChoice = Console.ReadLine().ToLower();

                        switch (menuChoice)
                        {
                            case "a":
                                TalentShowDisplayLightAndSound(finchRobot);
                                break;

                            case "b":

                                break;

                            case "c":

                                break;

                            case "q":
                                quitTalentShowMenu = true;
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine("\tEnter a letter for the menu choice.");
                                DisplayContinuePrompt();
                                break;
                        }
                    } while (!quitTalentShowMenu);
                }
                ///<param name="finchRobot">finch robot object</param>
                static void TalentShowDisplayLightAndSound(Finch finchRobot)
                {
                    Console.CursorVisible = false;

                    DisplayScreenHeader("Light and Sound");

                    Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
                    DisplayContinuePrompt();

                    for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
                    {
                        finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                        finchRobot.noteOn(lightSoundLevel * 100);
                    }
                    DisplayMenuPrompt("Talent Show Menu");
                }

                #endregion

                #region FINCH ROBOT MANAGEMENT

                /// <param name="finchRobot">finch robot object</param>
                static void DisplayDisconnectFinchRobot(Finch finchRobot)
                {
                    Console.CursorVisible = false;

                    DisplayScreenHeader("Disconnect Finch");

                    Console.WriteLine("\tAbout to disconnect from your Finch.");
                    DisplayContinuePrompt();

                    finchRobot.disConnect();

                    Console.WriteLine("\tYour Finch robot is now disconnected.");

                    DisplayMenuPrompt("Main Menu");
                }
                /// <param name="finchRobot">finch robot object</param>
                /// <returns>notify if the robot is connected</returns>
                static bool DisplayConnectFinchRobot(Finch finchRobot)
                {
                    Console.CursorVisible = false;

                    bool robotConnected;

                    DisplayScreenHeader("Connect Finch Robot");

                    Console.WriteLine("\tAbout to connect to Finch. Ensure that the USB cable is connected to the robot and computer now.");
                    DisplayContinuePrompt();

                    robotConnected = finchRobot.connect();

                    DisplayMenuPrompt("Main Menu");

                    finchRobot.setLED(0, 0, 0);
                    finchRobot.noteOff();

                    return robotConnected;
                }

                #endregion

                #region USER INTERFACE

                static void DisplayClosingScreen()
                {
                    Console.CursorVisible = false;

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\t\tThank you for using this Finch!");
                    Console.WriteLine();

                    DisplayContinuePrompt();
                }

                static void DisplayContinuePrompt()
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue.");
                    Console.ReadKey();
                }

                static void DisplayMenuPrompt(string menuName)
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
                    Console.ReadKey();
                }

                static void DisplayScreenHeader(string headerText)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\t\t" + headerText);
                    Console.WriteLine();
                }
            }
        }
