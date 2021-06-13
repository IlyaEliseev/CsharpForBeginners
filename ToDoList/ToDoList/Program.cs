using System;

namespace ToDoList
{
    internal class Program
    {
        private static IssueList _issueList;
        private static void Main(string[] args)
        {
            _issueList = new IssueList(100);

            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("1 - show issue list");
                Console.WriteLine("2 - create issue");
                Console.WriteLine("3 - delite issue");
                Console.WriteLine("4 - chenge issue");
                Console.WriteLine("5 - flag issue as complite");
                Console.WriteLine("X - to exite");

                string operation = Console.ReadLine();

                switch (operation.ToLower())
                {
                    case Operations.SHOW_ISSUES_LIST:
                        PrintIssues();

                        break;

                    case Operations.ADD_NEW_ISSUE:
                        CreateNewIssue();

                        break;

                    case Operations.REMOVE_ISSUE:
                        DeliteIssue();
                        break;

                    case Operations.EDIT_ISSUE:
                        EditIssue();
                        break;

                    case Operations.SET_ISSUE_ASS_DONE:
                        SetIssueAsDone();
                        break;

                    case Operations.EXITE:
                        isContinue = false;
                        break;

                    default:
                        Console.WriteLine("This is wrong operation" + operation);
                        break;
                }

                Console.WriteLine("Input any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void SetIssueAsDone()
        {
            int selectedIssueNumber = GetIsuueNumber();
            _issueList.RemoveIssueStatus(selectedIssueNumber);
        }

        private static void DeliteIssue()
        {
            int selectedIssueNumber = GetIsuueNumber();
            _issueList.Delete(selectedIssueNumber);
        }

        private static void EditIssue()
        {

            int selectedIssueNumber = GetIsuueNumber();
            Console.WriteLine("Input new issue title: ");
            string newTitle = Console.ReadLine();

            _issueList.EditTitle(selectedIssueNumber, newTitle);

        }

        private static void CreateNewIssue()
        {
            Console.WriteLine("Write title issue");
            string tittle = Console.ReadLine();

            Issue newIssue = new Issue
            {
                Title = tittle
            };

            _issueList.Add(newIssue);

            Console.WriteLine("Create new Issue");
        }

        private static void PrintIssues()
        {
            Issue[] issues = _issueList.GetIssues();

            for (int i = 0; i < issues.Length; i++)
            {
                Issue issue = issues[i];
                int issueNumber = i + 1;
                Console.WriteLine(issueNumber + ": Title: " + issue.Title + " Status " + issue.Status);
            }
        }


        private static int GetIsuueNumber()
        {
            Issue[] issues = _issueList.GetIssues();

            for (int i = 0; i < issues.Length; i++)
            {
                Issue issue = issues[i];
                int issueNumber = i + 1;
                Console.WriteLine(issueNumber + ": Title: " + issue.Title + " Status " + issue.Status);
            }

            bool isSucsess;
            int selectedIssueNumber;

            do
            {
                Console.WriteLine("Input issue number: ");
                string userInput = Console.ReadLine();
                isSucsess = int.TryParse(userInput, out selectedIssueNumber);

                if (selectedIssueNumber < 1 || selectedIssueNumber > issues.Length)
                {
                    isSucsess = false;
                }


            } while (isSucsess == false);

            return selectedIssueNumber;
        }
    }
}
