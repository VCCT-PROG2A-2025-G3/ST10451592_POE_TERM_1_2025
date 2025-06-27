using System;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Manages the chat session, handling user input and coordinating responses.
    /// </summary>
    class StartChat
    {
        private readonly RespondToUser _responder; // Handles processing of user input
        private readonly UserMemory _memory; // Stores user data for memory and recall
        private bool _isInitialized = false; // Tracks if the chat session is initialized

        /// <summary>
        /// Initializes a new instance of the StartChat class, setting up the memory and responder.
        /// </summary>
        public StartChat()
        {
            _memory = new UserMemory(); // Initialize user memory
            _responder = new RespondToUser(_memory); // Initialize responder with memory
        }

        /// <summary>
        /// Starts the chat session, greeting the user and handling their inputs until they exit.
        /// </summary>
        public void InitiateChat()
        {
            if (!_isInitialized)
            {
                _isInitialized = true; // Sets initialization flag
            }
            // Chat loop handled by GUI event
        }

        /// <summary>
        /// Processes a single step of user input for GUI integration and returns the response.
        /// </summary>
        /// <param name="userInput">The user's input string.</param>
        /// <returns>The chatbot's response.</returns>
        public string InitiateChatStep(string userInput)
        {
            if (!_isInitialized)
            {
                _memory.SetUserName(userInput); // Sets the user's name on first input
                _isInitialized = true;
                return $"Hello, {userInput}! I'm your Cybersecurity Awareness Bot. Ask me about password security, scams, privacy, phishing, or type 'exit' to quit.";
            }

            if (userInput.ToLower() == "exit")
            {
                return $"Stay safe online, {_memory.GetUserName()}! Goodbye."; // Returns exit message
            }

            return _responder.ProcessInput(userInput); // Delegates to responder for processing
        }

        /// <summary>
        /// Gets the user's name.
        /// </summary>
        /// <returns>The user's name or "User" if not set.</returns>
        public string GetUserName() => _memory.GetUserName() ?? "User";

        /// <summary>
        /// Sets the user's name.
        /// </summary>
        /// <param name="name">The user's name.</param>
        public void SetUserName(string name) => _memory.SetUserName(name); // Sets the user's name
    }
}