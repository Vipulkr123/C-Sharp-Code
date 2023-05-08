using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

class AutoMouseMove
{
    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

    private const uint MOUSEEVENTF_MOVE = 0x0001;

    static void Main(string[] args)
    {
        // set the total duration of the mouse movement (in milliseconds)
        int totalDuration = 9 * 60 * 1000; // 9 minutes

        // set the interval time between mouse moves (in milliseconds)
        int intervalTime = 5000;

        // get the start time of the mouse movement
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalMilliseconds < totalDuration)
        {
            // get the current mouse position
            Point currentPos = Cursor.Position;

            // generate a random offset for the next mouse position
            int offsetX = new Random().Next(-50, 50);
            int offsetY = new Random().Next(-50, 50);

            // calculate the next mouse position
            Point nextPos = new Point(currentPos.X + offsetX, currentPos.Y + offsetY);

            // move the mouse to the next position
            Cursor.Position = nextPos;

            // simulate a left mouse button click to prevent the screen saver or sleep mode from activating
            mouse_event(MOUSEEVENTF_MOVE, 0, 0, 0, 0);

            // wait for the specified interval time
            Thread.Sleep(intervalTime);
        }
    }
}
