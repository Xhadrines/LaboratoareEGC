using System;

namespace Lab_2
{
    public class FullScreen
    {
        public void GoFullScreen()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.SetWindowPosition(0, 0);

            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }
    }
}
