using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spaceinvadersfinal;

namespace Spaceinvadersfinal
{
    internal class SettingsScreen
    {
        private bool backButtonPressed;

        public SettingsScreen()
        {
            Raylib.SetTargetFPS(60);
            backButtonPressed = false;
        }

        public void Draw()
        {
            Raylib.ClearBackground(Raylib.BLACK);

            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            // Draw the title
            int titleWidth = Raylib.MeasureText("Settings", 90);
            int titleX = (screenWidth - titleWidth) / 2;
            Raylib.DrawText("Settings", titleX, 170, 80, Raylib.WHITE);

            // Draw back button
            int backButtonWidth = Raylib.MeasureText("Back", 60) + 30;
            int backButtonHeight = 50;
            int backButtonX = (screenWidth - backButtonWidth) / 2;
            int backButtonY = screenHeight - backButtonHeight - 30;
            backButtonPressed = RayGui.GuiButton(new Rectangle(backButtonX, backButtonY, backButtonWidth, backButtonHeight), "Back");
        }

        public bool Update()
        {
            return backButtonPressed;
        }
    }
}