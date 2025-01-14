﻿using MoviesPortal.BusinessLayer;
using MoviesPortal.Data;
using MoviesPortal.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoviesPortal.Menu
{
    internal class AdminMenu : IMenu
    {
        ProgramService _programService = new();
        MovieStoreService MovieStoreService = new();
        CreativePersonAgencyService _creativePersonAgencyService = new();
        IOHelper ioHelper = new IOHelper();
        public List<string> SelectionOptions
        {
            get
            {
                return new List<string>() {
                    ">> Add Movies",
                    ">> Edit Movies",
                    ">> Delete Movie",
                    ">> Add Actor/Director",
                    ">> Edit Actor/Director",
                    ">> Delete Actor/Director",
                    ">> Print a list of all movies from database",
                    ">> Print a list f all Actors/Directors from database",
                    ">> Back to main menu" };
            }
        }
        public void ListMainOptions()
        {
            var index = 1;
            Console.WriteLine("=======================================");
            foreach (var option in SelectionOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
            Console.WriteLine("=======================================");
        }

        public void GetUserChoiceInMainMenu()
        {
            int currentLine = 0;
            int counter;
            ConsoleKeyInfo key;
            while (true)
            {

                LoggedUser.WhoIsLogged();
                Console.WriteLine("Choose option by type correct number:");
                for (counter = 0; counter < SelectionOptions.Count; counter++)
                {
                    if (currentLine == counter)
                    {
                        Console.WriteLine($"{SelectionOptions[counter]}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else //other lines
                    {
                        Console.WriteLine($"{SelectionOptions[counter]}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    }
                }

                Console.WriteLine("", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    currentLine++;
                    if (currentLine > SelectionOptions.Count - 1) currentLine = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentLine--;
                    if (currentLine < 0) currentLine = SelectionOptions.Count - 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (currentLine)
                    {
                        case 0: //add movies
                            Console.Clear();
                            Console.WriteLine($"Adding new movie to database: \n");
                            _programService.AddNewMovie();
                            MovieStoreService.SaveMoviesToJson();
                            GetUserChoiceInMainMenu();

                            break;

                        case 1: //Edit movies
                            break;

                        case 2: //delete movie
                            Console.Clear();
                            _programService.PrintAllMovies();
                            var movieIndexUserChoice = ioHelper.GetIntFromUser($"Enter index number of a movie you wont to delete: ");
                            var movieIndex = movieIndexUserChoice - 1;
                            MovieStoreService.DeleteMovie(movieIndex);
                            MovieStoreService.SaveMoviesToJson();
                            GetUserChoiceInMainMenu();
                            break;

                        case 3: //add actor / director
                            Console.Clear();
                            CreativeRole creativeRole = ioHelper.GetCreativePersoneRole($"Which profession do you want to add?: ");
                            _programService.AddPerson("", creativeRole.ToString(), creativeRole);
                            CreativePersonAgency agency = new();
                            agency.SaveCreativePersonsListToJson();
                            Console.WriteLine($"Succes! New {creativeRole} succesfully added!");
                            Thread.Sleep(1500);
                            Console.Clear();
                            GetUserChoiceInMainMenu();
                            break;

                        case 4://Edit actor / director

                            GetUserChoiceInMainMenu();
                            break;

                        case 5:// delete actor / director
                            Console.Clear();
                            CreativeRole creativeRoleToDelete = ioHelper.GetCreativePersoneRole($"From which profession do you want to delete?: ");
                            _programService.PrintAllCreativePersonsListByRole(creativeRoleToDelete);
                            _programService.DeleteCreativePerson(creativeRoleToDelete);
                            GetUserChoiceInMainMenu();
                            break;

                        case 6: //print all movies in db
                            Console.Clear();
                            Console.WriteLine("List of all movies in database: \n");
                            _programService.PrintAllMovies();
                            Thread.Sleep(2000);
                            GetUserChoiceInMainMenu();
                            break;

                        case 7: //print all actors/directors
                            CreativeRole creativeRoleToList = ioHelper.GetCreativePersoneRole($"From which profession do you want to list?: ");
                            _programService.PrintAllCreativePersonsListByRole(creativeRoleToList);
                            Thread.Sleep(1500);
                            GetUserChoiceInMainMenu();
                            break;

                        case 8:    // back to main menu                        
                            LoginPanel.MainPanel();
                            break;

                        default:
                            {
                                Console.WriteLine("Please type correct number (from 1 to 7)");
                                GetUserChoiceInMainMenu();
                                break;
                            }
                    }
                }
            }
        }

        public void InitializeMenu()
        {
            ListMainOptions();
            GetUserChoiceInMainMenu();
        }
    }
}
