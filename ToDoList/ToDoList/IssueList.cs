using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class IssueList
    {
        private Issue[] _issues;
        public IssueList(int max)
        {
            _issues = new Issue[max];                        
        }

        public Issue[] GetIssues()
        {

            int issueCount = Count();
            Issue[] result = new Issue[issueCount];

            for (int i = 0; i < issueCount; i++)
            {
                result[i] = _issues[i];
            }

            return result;
        }

        public void Add(Issue newIssue) 
        {
            int issueCount = Count();
            _issues[issueCount] = newIssue;
        }

        private int Count() 
        {
            int counter = 0;

            for (int i = 0; i < _issues.Length; i++)
            {
                if (_issues[i] != null) 
                {
                    counter++;
                }
            }

            return counter;
        }

        internal void EditTitle(int selectedIssueNumber, string newTitle)
        {
            if(selectedIssueNumber>0 && string.IsNullOrWhiteSpace(newTitle) == false)
            {
                _issues[selectedIssueNumber - 1].Title = newTitle;
            }
            
        }

        internal void Delete(int selectedIssueNumber) 
        {                       

            int issueIndexToRemove = selectedIssueNumber - 1;
            _issues[issueIndexToRemove] = null;

            int issuesCount = Count();

            for (int i = issueIndexToRemove; i <= issuesCount-1; i++)
            {
                Issue temp = _issues[i + 1];
                _issues[i + 1] = _issues[i];
                _issues[i] = temp;
            }
        }

        internal void RemoveIssueStatus(int selectedIssueNumber)
        {
            int issueIndexToRemove = selectedIssueNumber - 1;
            _issues[issueIndexToRemove].Status = Status.Done;
        }
    }
}
