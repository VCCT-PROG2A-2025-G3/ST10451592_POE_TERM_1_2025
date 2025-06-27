using System.Collections.Generic;

namespace CybersecurityApp
{
    public class UserMemory
    {
        private List<string> _history = new List<string>();

        public IReadOnlyList<string> History => _history.AsReadOnly();

        public void AddToHistory(string input)
        {
            _history.Add(input);
        }
    }
}