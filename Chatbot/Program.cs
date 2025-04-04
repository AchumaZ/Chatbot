using System;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Threading;

namespace Chatboth
{
    class Program
    {
        static void Main()
        {
            // Displaying the startup message 
            Console.WriteLine("Starting Chatbot...");
            //path to the audio file 
            string audioFilePath = "C:\\Users\\achum\\source\\repos\\Chatbot\\Chatbot\\Resources\\greeting.wav";
            // Playing the voice recording 
            PlayVoiceGreeting(audioFilePath);
            //Displaying ASCII Art
            DisplayAsciiImage();
            //starting chat with user
            StartChat();

            // Displaying the introductory messages
            Console.WriteLine(" \nHello! Welcome to the CyberSecurity Awareness Bot.");
            Console.WriteLine("I'm here to help you stay safe online.Type your question");

            // Running chatbot to handle user interactions 
            RunChatbot();
        }

        //Global variable to store user's name 
        public static string Username = "Guest";
        //The method to play an audio greeting 
         static void PlayVoiceGreeting(string filepath)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(filepath))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }

         // Method to display an ASCIIA image in the console 
        static void DisplayAsciiImage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
      .-'      `-.
    .'            '.
   / Cybersecurity \'
  ;    Chatbot     ;
  |    (•-•)       |
  ;                ;
   \______________/ ");
            Console.ResetColor();
        }
        //Method to start the chat and get user's name
        static void StartChat()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------------------------");
            Console.WriteLine(" CHATBOT INTERACTION ");
            Console.WriteLine("---------------------------");

            TypeEffect("\nWhat is your name?");
            string userInput = Console.ReadLine();
            Username = string.IsNullOrWhiteSpace(userInput) ? "Guest" : userInput;

            TypeEffect($"Hello {Username}! Ask me anything about cybersecurity.");
        }

        // Method to handle charbot responses
        static void RunChatbot()
        {
            // Dictionary storing predefined responses 
            Dictionary<string, string> responses = new Dictionary<string, string>
            {
                { "how are you", "I'm just a bot, but I'm here to help!" },
                { "what's your purpose", "I am here to educate you about cybersecurity awareness" },
                { "what can i ask you about", "You can ask me about password safety, phishing, and safe browsing." },
                {"tell me about password safety", "Use strong passwords with at least 12 charecters, including numbers and special sysmbols." },
                {"what is phishing", "Phishing is a scam where attackers trick you into revealing sensitive information via fake emails or websites" },
                {"how can i browse safely","Avoid suspicious links, use updated antivirus software, and only enter personal info on secure website(https://)." }

            };

            while (true)
            {
                // Formating user input prompt 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nYou: ");
                Console.ResetColor();

                // Getting user inpput 
                string userinput = Console.ReadLine()?.ToLower().Trim();

                    
            // Formating chatbot response 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Chatbot: ");
            Console.ResetColor();
                if (userinput == "exit")
                {
                    TypeEffect("\nGoodbye! Stay safe online.");
                    break;
                }
                // Checking  if user input exists in predefined response
                if (responses.ContainsKey(userinput))
            {
                TypeEffect(responses[userinput]);
            }
            else
            {
                TypeEffect("I didn't quite understand that. Could you rephrase?");
            }

        }
    
}
     
        //Method to create a typing effect in chatbot responses 
        static void TypeEffect(string text, int delay = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

    }
}
            

            
            



               
                   









                    

                


            


        

        
        

    
