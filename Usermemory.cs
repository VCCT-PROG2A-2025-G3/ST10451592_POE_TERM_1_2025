namespace CybersecurityChatbot
{
    /// <summary>
    /// Manages user data, including name, conversation history, and preferences.
    /// </summary>
    public class UserMemory
    {
        private string _userName;
        private string _favoriteTopic;
        private string _lastKeyword;
        private List<string> _history = new List<string>();

        /// <summary>
        /// Sets the user's name.
        /// </summary>
        /// <param name="name">The user's name.</param>
        public void SetUserName(string name) => _userName = name;

        /// <summary>
        /// Gets the user's name.
        /// </summary>
        /// <returns>The user's name or null if not set.</returns>
        public string GetUserName() => _userName;

        /// <summary>
        /// Adds a user input to the conversation history.
        /// </summary>
        /// <param name="input">The user's input.</param>
        public void AddToHistory(string input) => _history.Add(input);

        /// <summary>
        /// Gets the last user input from the conversation history.
        /// </summary>
        /// <returns>The last input or null if no history exists.</returns>
        public string GetLastInput() => _history.LastOrDefault();

        /// <summary>
        /// Sets the user's favorite topic.
        /// </summary>
        /// <param name="topic">The favorite topic.</param>
        public void SetFavoriteTopic(string topic) => _favoriteTopic = topic;

        /// <summary>
        /// Gets the user's favorite topic.
        /// </summary>
        /// <returns>The favorite topic or null if not set.</returns>
        public string GetFavoriteTopic() => _favoriteTopic;

        /// <summary>
        /// Sets the last keyword discussed.
        /// </summary>
        /// <param name="keyword">The last keyword.</param>
        public void SetLastKeyword(string keyword) => _lastKeyword = keyword;

        /// <summary>
        /// Gets the last keyword discussed.
        /// </summary>
        /// <returns>The last keyword or null if not set.</returns>
        public string GetLastKeyword() => _lastKeyword;
    }
}