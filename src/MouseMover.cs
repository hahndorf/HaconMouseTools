using System;
using System.Diagnostics;

// https://github.com/rhinterndorfer/MousePointerReposition.git

namespace Hacon.MouseTools
{
    internal class MouseMover
    {
        private Vanara.PInvoke.RECT foreGroundWindowRectStart;

        public bool ConsoleOutput { get; set; }

        private void Print(string text)
        {
            if (ConsoleOutput)
                Console.WriteLine(text);

        }

        public bool TryMouseRepositioning()
        {
            Print("TryMouseRepositioning start");
            // get foreground window
            var foregroundWindowHandle = Vanara.PInvoke.User32.GetForegroundWindow();
            Vanara.PInvoke.User32.GetWindowRect(foregroundWindowHandle, out Vanara.PInvoke.RECT windowRect);

            Print(String.Format("Old window: left={0} top={1} width={2} height={3}", foreGroundWindowRectStart.left, foreGroundWindowRectStart.top, foreGroundWindowRectStart.Width, foreGroundWindowRectStart.Height));
            Print(String.Format("New window: left={0} top={1} width={2} height={3}", windowRect.left, windowRect.top, windowRect.Width, windowRect.Height));


            if (foreGroundWindowRectStart.left != windowRect.left
                || foreGroundWindowRectStart.Width != windowRect.Width
                || foreGroundWindowRectStart.top != windowRect.top
                || foreGroundWindowRectStart.Height != windowRect.Height)
            {
                // check if mouse position is within new active application window
                // get current cursor position
                Vanara.PInvoke.User32.GetCursorPos(out Vanara.PInvoke.POINT cursorPos);

                Print(String.Format("Current cursor: x={0} y={1}", cursorPos.X, cursorPos.Y));

                if (windowRect.left <= cursorPos.X
                    && windowRect.right >= cursorPos.X
                    && windowRect.top <= cursorPos.Y
                    && windowRect.bottom >= cursorPos.Y)
                {
                    return true;
                }
                else
                {
                    int x = windowRect.left + windowRect.Width / 2;
                    int y = windowRect.top + windowRect.Height / 2;

                    Print(String.Format("New cursor: x={0} y={1}", x, y));
                    Vanara.PInvoke.User32.SetCursorPos(x + 1, y + 1); // sometimes cursor is not positioned right
                    Vanara.PInvoke.User32.SetCursorPos(x, y); // calling twice sets the correct postion

                    Print("TryMouseRepositioning end");
                    return true;
                }
            }
            else
            {
                Print("TryMouseRepositioning end");
                return false;
            }
        }
    }
}
