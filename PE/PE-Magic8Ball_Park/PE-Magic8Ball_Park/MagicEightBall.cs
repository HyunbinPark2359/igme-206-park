using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Magic8Ball_Park
{
    internal class MagicEightBall
    {
        // Include private fields
        private string owner;       // Who's holding the magic 8 ball
        private int timesShaken;    // The number of times the ball has been shaken
        private string[] responses; // Colletion of responses
        Random rng;                 // Random object


        // Parameterized constructor

        // Define all 4 fields
        public MagicEightBall(string owner)
        {
            this.owner = owner;
            this.timesShaken = 0;
            this.responses = new[] {"It is certain.", "As I see it, yes.", 
                             "Replay hazy, try again.", "Don't count on it.", "Very doubtful."};
            rng = new Random();
        }


        // Methods

        // Simulate shaking the magic 8 ball
        public string ShakeBall()
        {
            // Increase the number of times shaken
            timesShaken++;

            // Randomly choose one of the responses and return it
            return responses[rng.Next(responses.Length)];
        }

        // Return a statement about how many times the ball has been shaken
        public string Report()
        {
            switch(timesShaken)
            {
                // Ball has not been shaken
                case 0:
                    return String.Format("{0} has not shaken the ball yet.", owner);
                    break;

                // Ball has been shaken 1 - 3 times
                case 1:
                case 2:
                case 3:
                    return String.Format("{0} has shaken the ball {1} times.", 
                                         owner, timesShaken);
                    break;

                // Ball has been shaken more than 3 times
                default:
                    return String.Format("{0} has shaken the ball {1} times. " +
                                         "That's a lot of questions!", owner, timesShaken);
                    break;
            }
        }
    }
}
