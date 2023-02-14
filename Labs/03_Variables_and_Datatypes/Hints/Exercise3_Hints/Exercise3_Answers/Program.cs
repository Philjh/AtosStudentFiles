// This file contains hints that will help
// you correct the code for Exercise 3

//dressSize = 12;           // 1) Cannot use before declared
double dressSize;           // 2) Dress sizes are integers 
double salary = 50000.50;   // 3) the decimal type should be used for money, then suffix with 
decimal pi = 3.14159;       // 4) either change to double or add a suffix 
decimal distanceToPlutoInMillimetres;  // 5) double has greater range than decimal
int iResult = 31 & 17;  // 6) This runs but probably does not give the answer you were expecting. It evaluates to 17 because it is a bitwise AND
                        //    It's not clear what it should be. Perhaps a + sign?
long height = 200;
int width = height; // 7) Compiler will not silently cast a long to an int. A cast is required

double kerbWeight = 20000;
double maxWeightPerAxle = 660;
int requiredNumberOfAxles = (int)kerbWeight / maxWeightPerAxle; // 8) You need the result cast to integer, notjust kerbWeight

string programFiles = "c:\Program Files"; // 9)  the '@' symbol is required to ignore control characters

string pmsAddress = " // 10)  the '@' symbol is required to ignore newlines
        10 Downing Street
        London
        SW1A 2AA";

int win1 = 42, win2 = 1, win3 = 5, win4 = 49, win5 = 33, win6 = 34;
// 11) all indices in C# start at zero
string lotteryNumbers = string.Format("The winning lottery numbers are {1}, {2}, {3}, {4}, {5}, {6}", win1, win2, win3, win4, win5, win6);

// 12) There is a mis-match between the placeholders (curly brackets) and supplied parameters
string moreLotteryNumbers = string.Format("Next week's winning lottery numbers are {0}, {1}, {2}, {3}, {4}, {5}", win1, win2, win3, win4, win5);

// 13) The leading '$' is needed
string evenMoreLotteryNumbers = "Next week's winning lottery numbers are {win1}, {win2}, {win3}, {win4}, {win5}, {win6}";

// 14) Put a breakpoint here and F11. Confirm it does short-circuit evaluation and never goes into Condition2()
bool bResult2 = Condition1() && Condition2();