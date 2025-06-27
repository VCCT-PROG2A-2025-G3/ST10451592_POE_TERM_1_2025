using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Handles user input processing, generating dynamic responses based on keywords, sentiment, and conversation history.
    /// </summary>
    class RespondToUser
    {
        private readonly UserMemory _memory; // Stores user data for memory and recall
        private readonly Random _random; // Used to select random responses
        private readonly Dictionary<string, List<string>> _keywordResponses; // Maps cybersecurity keywords to response lists
        private readonly List<string> _affirmativeResponses; // List of affirmative human responses
        private readonly List<string> _negativeResponses; // List of negative human responses

        /// <summary>
        /// Initializes the RespondToUser class with a UserMemory instance and sets up keyword responses and simple human answer lists.
        /// </summary>
        /// <param name="memory">UserMemory instance to store and recall user details.</param>
        public RespondToUser(UserMemory memory)
        {
            _memory = memory;
            _random = new Random();

            // Initialize keyword responses for cybersecurity topics, including phishing tips
            _keywordResponses = new Dictionary<string, List<string>>
            {
                {
                    "password", new List<string>
                    {
                        "Use strong passwords with at least 12 characters, mixing letters, numbers, and symbols. Avoid reusing passwords!",
                        "Consider a password manager to generate and store unique, complex passwords securely.",
                        "Enable two-factor authentication (2FA) for an extra layer of account protection."
                    }
                },
                {
                    "scam", new List<string>
                    {
                        "Be wary of urgent emails or texts asking for personal info—verify the sender first.",
                        "Look for spelling errors or odd requests as red flags in potential scams.",
                        "Report suspected scams to your email provider or authorities to prevent further issues."
                    }
                },
                {
                    "privacy", new List<string>
                    {
                        "Regularly check and tighten your social media privacy settings.",
                        "Use a VPN on public Wi-Fi to encrypt your internet connection.",
                        "Think twice before sharing personal details online to protect your privacy."
                    }
                },
                {
                    "phishing", new List<string>
                    {
                        "Avoid opening emails from unknown senders asking for sensitive data.",
                        "Hover over links to check their true URL before clicking.",
                        "Contact the supposed sender directly if an email seems suspicious."
                    }
                }
            };

            // Initialize lists for simple human answers
            _affirmativeResponses = new List<string> { "yes", "sure", "okay", "yep", "yeah", "please", "go ahead" };
            _negativeResponses = new List<string> { "no", "nope", "not really", "nah" };
        }

        /// <summary>
        /// Processes user input and generates a response based on keywords, sentiment, conversation history, or simple human answers.
        /// </summary>
        /// <param name="input">The user's input string.</param>
        /// <returns>The generated response string.</returns>
        public string ProcessInput(string input)
        {
            string response = ""; // Initialize response
            input = input?.Trim().ToLower() ?? string.Empty; // Normalize input
            _memory.AddToHistory(input); // Store input in history

            string sentiment = DetectSentiment(input); // Detect user sentiment
            bool isSentimentDetected = !string.IsNullOrEmpty(sentiment);

            switch (input)
            {
                case "how are you":
                    response = $"I'm doing great, {_memory.GetUserName()}! Ready to help with cybersecurity tips. Interested in {_memory.GetFavoriteTopic() ?? "online safety"}?";
                    break;

                case "what's your purpose":
                    response = $"I'm here to guide you, {_memory.GetUserName()}, with tips on passwords, scams, privacy, and phishing. What would you like to explore?";
                    break;

                case "what can i ask you about":
                    response = "Feel free to ask about password security, scam prevention, privacy tips, or phishing awareness. What’s on your mind?";
                    break;

                default:
                    string keyword = _keywordResponses.Keys.FirstOrDefault(k => input.Contains(k));
                    if (keyword != null)
                    {
                        if (_memory.GetFavoriteTopic() == null)
                        {
                            _memory.SetFavoriteTopic(keyword);
                            response = $"Awesome, {_memory.GetUserName()}! I’ve noted your interest in {keyword}. Here’s a tip: ";
                        }
                        var responses = _keywordResponses[keyword];
                        response += responses[_random.Next(responses.Count)];
                        _memory.SetLastKeyword(keyword); // Update last keyword
                        response += " Would you like more info on this?";
                        if (isSentimentDetected)
                            response = AdjustForSentiment(sentiment, response);
                    }
                    else
                    {
                        string lastInput = _memory.GetLastInput()?.ToLower().Trim() ?? string.Empty;
                        if (lastInput.Contains("would you like more info") && _memory.GetLastKeyword() != null)
                        {
                            var inputWords = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (inputWords.Any(word => _affirmativeResponses.Contains(word)))
                            {
                                var responses = _keywordResponses[_memory.GetLastKeyword()];
                                response = responses[_random.Next(responses.Count)] + " Anything else you’d like to know?";
                            }
                            else if (inputWords.Any(word => _negativeResponses.Contains(word)))
                            {
                                response = $"Got it, {_memory.GetUserName()}! Let’s try a new topic—how about passwords, scams, privacy, or phishing?";
                            }
                            else
                            {
                                response = "Hmm, I’m not sure what you mean. Please say 'yes' or 'no' to more info!";
                            }
                            if (isSentimentDetected)
                                response = AdjustForSentiment(sentiment, response);
                        }
                        else
                        {
                            response = "I didn’t quite get that, {_memory.GetUserName()}. Try asking about passwords, scams, privacy, or phishing!";
                            if (isSentimentDetected)
                                response = AdjustForSentiment(sentiment, response);
                        }
                    }
                    break;
            }

            return response; // Return response for GUI display
        }

        /// <summary>
        /// Detects simple sentiments in user input based on predefined keywords.
        /// </summary>
        /// <param name="input">The user's input string.</param>
        /// <returns>The detected sentiment ("worried", "curious", "frustrated") or null if none detected.</returns>
        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared"))
                return "worried";
            if (input.Contains("curious") || input.Contains("interested"))
                return "curious";
            if (input.Contains("frustrated") || input.Contains("annoyed"))
                return "frustrated";
            return null;
        }

        /// <summary>
        /// Adjusts the response based on the detected sentiment to make it more empathetic.
        /// </summary>
        /// <param name="sentiment">The detected sentiment.</param>
        /// <param name="baseResponse">The original response before sentiment adjustment.</param>
        /// <returns>The adjusted response incorporating the sentiment.</returns>
        private string AdjustForSentiment(string sentiment, string baseResponse)
        {
            return sentiment switch
            {
                "worried" => $"I sense you're {sentiment}, {_memory.GetUserName()}. Let’s tackle this together: {baseResponse}",
                "curious" => $"Love your {sentiment}, {_memory.GetUserName()}! Here’s more: {baseResponse}",
                "frustrated" => $"I feel your {sentiment}, {_memory.GetUserName()}. Let’s simplify: {baseResponse}",
                _ => baseResponse
            };
        }
    }
}