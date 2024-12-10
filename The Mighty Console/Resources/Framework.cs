using The_Mighty_Console.Resources.FrameworkMethods.IngameCommands;
using The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories;
using The_Mighty_Console.Resources.FrameworkMethods.IO;
using The_Mighty_Console.Resources.FrameworkMethods.PrintMethods;
using The_Mighty_Console.Resources.FrameworkMethods.StringWorks;
using The_Mighty_Console.Resources.FrameworkMethods.VariableManagement;
using The_Mighty_Console.Resources.FrameworkMethods.WindowManagement;
using The_Mighty_Console.Resources.GameData.Objects;

namespace The_Mighty_Console.Resources
{
    struct Rect { public int Left; public int Top; public int Right; public int Bottom; }
    internal class Framework
    {
        // One singleton to rule them ALL!
        // Not standard or even suggested practice, but fuck it, we ball.
        private static readonly Framework _instance = new Framework();
        private Framework() { ConsoleStorage.Instance.StoreConsole(); }
        public static Framework Instance => _instance;


        public bool skippedIntro = true;
        public bool skippedFirst = true;
        public bool skippedSecond = true; // TODO: Implement this variable in the second chapter.

        public bool isAtPC = true;
        public bool loggedIn = false;
        public bool aiRunning = false;
        public bool introCompleted = false;

        public bool exploredMain = false;
        public bool exploredEntranceHall = false;
        public bool exploredOutside = false;
        public bool exploredBasement = false;
        public bool exploredUpstairs = false;
        public bool exploredTopFloor = false;
        public bool investigatedManagement = false;
        public bool exploredStorage = false;
        public bool investigatedStorage = false;

        public bool rashMentioned = false;
        public bool usbPerms = false;
        public bool usbTileLifted = false;
        public bool formulaPerms = false;
        public bool formulaCollected = false;
        public bool discoveredHint = false; // Used in Basement.cs
        public bool aiWithPlayer = false;

        public string userPath = "main.usrs.tmp";
        public string textInput = "";
        public string name = "";
        public string systemHostname = "DESKTOP-9806515";

        public string? nationality = null;
        public int? age = null;
        public double? height = null;
        public string? eyeColor = null;

        public int aiTrustLevel = 0;
        public bool aiTrustLevelRequested = false;
        public bool positiveTrustAnnounced = false;
        public int falseRequestAttempts = 0;

        public DateTime systemDate = new DateTime(1977, 9, 28);
        public DateTime creationDate = new DateTime(1971, 4, 25, 7, 34, 22);

        public List<GameProcesses> processes = new List<GameProcesses>();

        public List<string> commandHistory = new List<string>();
        public List<string> playerChoices = new List<string>();
        public List<string> playerNotes = new List<string>();



        /// <summary>
        /// Returns a list of all processes which match all provided parameters.
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="processId"></param>
        /// <param name="sessionName"></param>
        /// <param name="memoryUsage"></param>
        /// <returns></returns>
        public List<GameProcesses> GetMatchingProcesses(string? processName = null, int? processId = null, string? sessionName = null, int? memoryUsage = null)
            => getGetMatchingProcesses.Exec(processName, processId, sessionName, memoryUsage);
        private GetMatchingProcesses getGetMatchingProcesses = new GetMatchingProcesses();
        /// <summary>
        /// Returns the contents of a folder as a list containing files, empty folders, and folders with contents. <br></br>
        /// Files with the extension .d are interpreted as empty folders and .dd as filled folders without permisions.
        /// </summary>
        /// <param name="dotPath"></param>
        /// <returns></returns>
        public List<string> ListInternalDirectoryContents(string dotPath)
            => listInternalDirectoryContents.Exec(dotPath);
        private ListInternalDirectoryContents listInternalDirectoryContents = new ListInternalDirectoryContents();
        /// <summary>
        /// Removes duplicate entries in a string List and returns it.
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public List<string> RemoveDuplicates(List<string> inputList)
            => removeDuplicates.Exec(inputList);
        private RemoveDuplicates removeDuplicates = new RemoveDuplicates();
        /// <summary>
        /// Returns a list with the contents of a file. <br></br>
        /// Each line of said file is an entry in the string list.
        /// </summary>
        /// <param name="dotPath"></param>
        /// <returns></returns>
        public List<string> InternalFileToList(string dotPath)
            => internalFileToList.Exec(dotPath);
        private InternalFileToList internalFileToList = new InternalFileToList();
        /// <summary>
        /// Returns a bool if the process list contains any process matching all provided parameters.
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="processId"></param>
        /// <param name="sessionName"></param>
        /// <param name="memoryUsage"></param>
        /// <returns></returns>
        public bool ContainsProcess(string? processName = null, int? processId = null, string? sessionName = null, int? memoryUsage = null)
            => containsProcess.Exec(processName, processId, sessionName, memoryUsage);
        private ContainsProcess containsProcess = new ContainsProcess();
        /// <summary>
        /// Returns a bool after the user is tasked to confirm or deny.
        /// </summary>
        /// <returns></returns>
        public bool ConfirmAction()
            => confirmAction.Exec();
        private ConfirmAction confirmAction = new ConfirmAction();
        /// <summary>
        /// Checks whether there is at least one internal path that is exactly one segment longer than the parameter.
        /// </summary>
        /// <param name="filePathInDots"></param>
        /// <returns></returns>
        public bool CheckIfFileHasExtensionInResources(string filePathInDots)
            => checkIfFileHasExtensionInResources.Exec(filePathInDots);
        private CheckIfFileHasExtensionInResources checkIfFileHasExtensionInResources = new CheckIfFileHasExtensionInResources();
        /// <summary>
        /// Returns a bool after checking whether a file exists at the binary path.
        /// </summary>
        /// <param name="filePathInDots"></param>
        /// <returns></returns>
        public bool CheckForInternalFile(string filePathInDots)
            => checkForInternalFile.Exec(filePathInDots);
        private CheckForInternalFile checkForInternalFile = new CheckForInternalFile();
        /// <summary>
        /// Returns a bool after checking whether a directory exists at the binary path. <br></br>
        /// If the target is a binary file, it sets a boolean in the second parameter to true.
        /// </summary>
        /// <param name="directoryPathInDots"></param>
        /// <param name="isFilePath"></param>
        /// <returns></returns>
        public bool CheckForInternalDirectory(string directoryPathInDots, out bool isFilePath)
            => checkForInternalDirectory.Exec(directoryPathInDots, out isFilePath);
        private CheckForInternalDirectory checkForInternalDirectory = new CheckForInternalDirectory();
        /// <summary>
        /// Returns a bool based on whether the binary directory is empty.
        /// </summary>
        /// <param name="filePathInDots"></param>
        /// <returns></returns>
        public bool IsInternalDirectoryEmpty(string filePathInDots)
            => isInternalDirectoryEmpty.Exec(filePathInDots);
        private IsInternalDirectoryEmpty isInternalDirectoryEmpty = new IsInternalDirectoryEmpty();
        /// <summary>
        /// Checks whether the user input has a '?' after the command.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool HelpFlagChecker(string input, bool doNotCheck = false)
            => helpFlagChecker.Exec(input, doNotCheck);
        private HelpFlagChecker helpFlagChecker = new HelpFlagChecker();
        /// <summary>
        /// Returns a bool based on whether the user's command contains a flag at a given positon.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="flag"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool CommandFlagChecker(string input, string flag, int position = 1)
            => commandFlagChecker.Exec(input, flag, position);
        private CommandFlagChecker commandFlagChecker = new CommandFlagChecker();
        /// <summary>
        /// Like <c>CommandFlagChecker()</c>, but returns a string with the flag removed. <br></br>
        /// Also outputs a boolean when it detects the given flag.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="flag"></param>
        /// <param name="flagDetected"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public string CommandFlagHandler(string input, string flag, out bool flagDetected, int position = 1)
            => commandFlagHandler.Exec(input, flag, out flagDetected, position);
        private CommandFlagHandler commandFlagHandler = new CommandFlagHandler();
        /// <summary>
        /// Removes the endings .d and .dd from empty files that represent locked or empty folders. <br></br>
        /// Returns the output as a string.
        /// </summary>
        /// <param name="dotPath"></param>
        /// <returns></returns>
        public string RemoveFolderSuffix(string dotPath)
            => removeFolderSuffix.Exec(dotPath);
        private RemoveFolderSuffix removeFolderSuffix = new RemoveFolderSuffix();
        /// <summary>
        /// Turns a string from a regular path into a dot path. <br></br>
        /// Also properly handles escape cases. <br></br>
        /// Returns <c>null</c> if the path does not exist in the binary.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string? ConvertToDotPath(string filePath)
            => convertToDotPath.Exec(filePath);
        private ConvertToDotPath convertToDotPath = new ConvertToDotPath();
        /// <summary>
        /// Converts a dot path to a regular path. <br></br>
        /// If the second parameter is set to <c>true</c>, the last dot is kept.
        /// </summary>
        /// <param name="filePathInDots"></param>
        /// <returns></returns>
        public string ConvertToBackslashPath(string filePathInDots, bool isFile)
            => convertToBackslashPath.Exec(filePathInDots, isFile);
        private ConvertToBackslashPath convertToBackslashPath = new ConvertToBackslashPath();
        /// <summary>
        /// Removes any unwanted parts from the start of a dot path. <br></br>
        /// By default, it will remove <c>IngameDir.</c>, but anything can be specified.
        /// </summary>
        /// <param name="filePathInDots"></param>
        /// <param name="toTrim"></param>
        /// <returns></returns>
        public string TrimDotPathDirPrefix(string filePathInDots, string toTrim = "IngameDir.")
            => trimDotPathDirPrefix.Exec(filePathInDots, toTrim);
        private TrimDotPathDirPrefix trimDotPathDirPrefix = new TrimDotPathDirPrefix();
        /// <summary>
        /// Capitalizes the first letter in a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CapitalizeFirstLetter(string input)
            => capitalizeFirstLetter.Exec(input);
        private CapitalizeFirstLetter capitalizeFirstLetter = new CapitalizeFirstLetter();
        /// <summary>
        /// Takes a string and replaces a word of your liking with another. <br></br>
        /// Unlike <c>String.Replace()</c>, it only affects one instance of a word.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="newWord"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string ReplaceWord(string input, string newWord, int position = 0)
            => replaceWord.Exec(input, newWord, position);
        private ReplaceWord replaceWord = new ReplaceWord();
        /// <summary>
        /// Removes The first word and space from a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string RemoveFirstWord(string input)
            => removeFirstWord.Exec(input);
        private RemoveFirstWord removeFirstWord = new RemoveFirstWord();
        /// <summary>
        /// Shortens or lengthens a string to a specific length.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <param name="rightBound"></param>
        /// <returns></returns>
        public string SetStringLength(string input, int length, bool rightBound = false)
            => setStringLength.Exec(input, length, rightBound);
        private SetStringLength setStringLength = new SetStringLength();
        /// <summary>
        /// Returns the last word in a dot path as a string. <br></br>
        /// Should only be used with internal directories and not files.
        /// </summary>
        /// <param name="dotPath"></param>
        /// <returns></returns>
        public string LastDotPathWord(string dotPath)
            => lastDotPathWord.Exec(dotPath);
        private LastDotPathWord lastDotPathWord = new LastDotPathWord();
        /// <summary>
        /// Removes the last word from a dot path and returns the rest as a string. <br></br>
        /// Should only be used with internal directories and not files.
        /// </summary>
        /// <param name="dotPath"></param>
        /// <returns></returns>
        public string RemoveLastDotPathWord(string dotPath)
            => removeLastDotPathWord.Exec(dotPath);
        private RemoveLastDotPathWord removeLastDotPathWord = new RemoveLastDotPathWord();
        /// <summary>
        /// Returns everything before the first space in a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ReturnFirstWord(string input)
            => returnFirstWord.Exec(input);
        private ReturnFirstWord returnFirstWord = new ReturnFirstWord();
        /// <summary>
        /// Like <c>Console.ReadLine()</c>, but masks user input as asterisks.
        /// </summary>
        /// <returns></returns>
        public string ReadLineWithMask()
            => readLineWithMask.Exec();
        private ReadLineWithMask readLineWithMask = new ReadLineWithMask();
        /// <summary>
        /// Returns the input decoration for <c>InputDisplay()</c>.
        /// </summary>
        /// <returns></returns>
        public string InputDecoration()
            => inputDecoration.Exec();
        private InputDecoration inputDecoration = new InputDecoration();
        /// <summary>
        /// Takes an input string, and returns it centered to the console buffer. <br></br>
        /// Spaces are added left to achieve this effect.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CenterString(string input)
            => centerString.Exec(input);
        private CenterString centerString = new CenterString();
        /// <summary>
        /// Tasks the player to press a key to choose between inputs. <br></br>
        /// Each input is defined by a new string in the choice list. <br></br>
        /// The player navigates through the choices by pressing up or down and enter to select inputs.
        /// </summary>
        /// <param name="choices"></param>
        /// <returns></returns>
        public int PlayerChoice(List<string> playerChoices, bool clearChoiceList = true, int delay = 1, bool printOutput = true, bool resumeRecording = true, ConsoleColor selectionColor = ConsoleColor.Blue, bool addInputDecoration = false)
            => playerChoice.Exec(playerChoices, clearChoiceList, delay, printOutput, resumeRecording, selectionColor);
        private PlayerChoice playerChoice = new PlayerChoice();
        /// <summary>
        /// Returns the amount of words in a string. <br></br>
        /// A word here is defined as a series of ANY symbols separated by spaces. <br></br>
        /// The amount of spaces is irrelevant.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int CountWords(string input)
            => countWords.Exec(input);
        private CountWords countWords = new CountWords();



        /// <summary>
        /// Brings the console window up above all other windows and focuses it.
        /// </summary>
        public void FocusWindow()
            => focusWindow.Exec();
        private FocusWindow focusWindow = new FocusWindow();
        /// <summary>
        /// Sets the window to fullscreen.
        /// </summary>
        public void FullscreenWindow()
            => fullscreenWindow.Exec();
        private FullscreenWindow fullscreenWindow = new FullscreenWindow();
        /// <summary>
        /// Restores the window size and goes out of fullscreen.
        /// </summary>
        public void RestoreWindow()
            => restoreWindow.Exec();
        private RestoreWindow restoreWindow = new RestoreWindow();
        /// <summary>
        /// Minimizes the console.
        /// </summary>
        public void MinimizeWindow()
            => minimizeWindow.Exec();
        private MinimizeWindow minimizeWindow = new MinimizeWindow();
        /// <summary>
        /// Toggles whether the window is set to always be on top. <br></br>
        /// Always on top does not mean it necessarily is focused.
        /// </summary>
        public bool SetTopWindow()
            => setTopWindow.Exec();
        private SetTopWindow setTopWindow = new SetTopWindow();
        /// <summary>
        /// Sets and outputs a new trust level.
        /// </summary>
        public void TrustManager(int newTrustLevel, bool announce = true)
            => trustManager.Exec(newTrustLevel, announce);
        private TrustManager trustManager = new TrustManager();
        /// <summary>
        /// Displays a blinking "GAME OVER!" message and tasks the player to close the game.
        /// </summary>
        public void GameOver()
            => gameOver.Exec();
        private GameOver gameOver = new GameOver();
        /// <summary>
        /// Flickers the background of the console. <br></br>
        /// Background color will always return to what it was before. <br></br>
        /// Flicker color and durations can be specified via parameters.
        /// </summary>
        /// <param name="flickerColor"></param>
        /// <param name="repetitions"></param>
        public void ConsoleFlicker(ConsoleColor flickerColor = ConsoleColor.Red, int repetitions = 10, int delay = 100)
            => consoleFlicker.Exec(flickerColor, repetitions, delay);
        private ConsoleFlicker consoleFlicker = new ConsoleFlicker();
        /// <summary>
        /// Checks whether the player is logged in before running the selected command.
        /// </summary>
        /// <param name="commandMethod"></param>
        public void CommandPermCheck(Action commandMethod)
            => commandPermCheck.Exec(commandMethod);
        private CommandPermCheck commandPermCheck = new CommandPermCheck();
        /// <summary>
        /// Prints out input text with a definable delay per letter. <br></br>
        /// If the input is empty, it will output a default message.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="delay"></param>
        /// <param name="newLine"></param>
        public void DelayedPrint(string? input = "", int delayInMilliseconds = 1, bool newLine = true)
            => delayedPrint.Exec(input, delayInMilliseconds, newLine);
        private DelayedPrint delayedPrint = new DelayedPrint();
        /// <summary>
        /// Prints out the input string as an error or warning.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isWarning"></param>
        /// <param name="errorLevel"></param>
        public void ErrorPrint(string input, bool isWarning = false, int errorLevel = 2)
            => errorPrint.Exec(input, isWarning, errorLevel);
        private ErrorPrint errorPrint = new ErrorPrint();
        /// <summary>
        /// Prints out the input string as info.
        /// </summary>
        /// <param name="input"></param>
        public void InfoPrint(string input)
            => infoPrint.Exec(input);
        private InfoPrint infoPrint = new InfoPrint();
        /// <summary>
        /// Empties the user's input string.
        /// </summary>
        public void Clear() => textInput = "";
        /// <summary>
        /// Adds a process to the in-game task list with specified info.
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="processId"></param>
        /// <param name="sessionName"></param>
        /// <param name="memoryUsage"></param>
        public void AddProcess(string processName, int processId, string sessionName, int memoryUsage)
            => processes.Add(new GameProcesses(processName, processId, sessionName, memoryUsage));
        /// <summary>
        /// Prints out an internal file. <br></br>
        /// The path has to first be converted to a dot path using <c>ConvertToDotPath()</c>.
        /// </summary>
        /// <param name="filePathInDots"></param>
        /// <param name="delay"></param>
        public void PrintFromInternalFile(string filePathInDots, int delay = 0)
            => printFromInternalFile.Exec(filePathInDots, delay);
        private PrintFromInternalFile printFromInternalFile = new PrintFromInternalFile();
        /// <summary>
        /// Like <c>PrintFromInternalFile()</c>, but with some differences. <br></br>
        /// Character delay is always 1. <br></br>
        /// Empty lines will be printed as empty. <br></br>
        /// The <c>#</c> symbol with the colour after it will set the console colour, and the line will be ignored. <br></br>
        /// Examples: <c>#Cyan</c>, <c>#Yellow</c>, <c>#Red</c> <br></br>
        /// Similarly, you can add <c>CLEAR</c> after the # symbol to clear the console. <br></br>
        /// The line has to only contain <c>#CLEAR</c> for it to work. <br></br>
        /// A line with three dots will be printed slowly. <br></br>
        /// A line containing <c>#AUTO</c> will turn off the need for user input. <br></br>
        /// A line containing <c>#CONFIRM</c> will resume default behaviour.
        /// </summary>
        /// <param name="filePathInDots"></param>
        /// <param name="delay"></param>
        public void PrintStoryDialogue(string filePathInDots)
            => printStoryDialogue.Exec(filePathInDots);
        private PrintStoryDialogue printStoryDialogue = new PrintStoryDialogue();
        /// <summary>
        /// Used to write the user input decoration before the input line.
        /// </summary>
        public void InputDisplay()
            => Console.Write(InputDecoration());
        /// <summary>
        /// Interprets the user's text input as a command.
        /// </summary>
        /// <param name="commandRequired"></param>
        public void CommandHandler(bool commandRequired)
            => commandHandler.Exec(commandRequired);
        private CommandHandler commandHandler = new CommandHandler();
        /// <summary>
        /// Handles user input. <br></br>
        /// Any input is written to the string <c>Framework.textInput</c>
        /// </summary>
        /// <param name="isCommand"></param>
        /// <param name="commandRequired"></param>
        public void InputHandler(bool isCommand = false, bool commandRequired = false)
            => inputHandler.Exec(isCommand, commandRequired);
        private InputHandler inputHandler = new InputHandler();
        /// <summary>
        /// The list of cases which exit <c>InputHandler()</c> pre-emptively. <br></br>
        /// Used for things like cutting user input when a chapter is completed.
        /// </summary>
        /// <returns></returns>
        public bool InputHandlerExitCases()
            => inputHandlerExitCases.Exec();
        private InputHandlerExitCases inputHandlerExitCases = new InputHandlerExitCases();
    }
}