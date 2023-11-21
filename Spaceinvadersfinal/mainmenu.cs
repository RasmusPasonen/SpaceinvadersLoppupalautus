using System;
using System.ComponentModel.Design;
using System.Numerics;
using Raylib_CsLo;
using Spaceinvadersfinal;

namespace Spaceinvadersfinal
{
    class mainmenu
    {
        private bool startButtonPressed;
        private bool exitButtonPressed;
        private bool optionsButtonPressed;
        private SettingsScreen settingsScreen;
        enum ScreenState { Start, Settings }
        private ScreenState currentState;
        public mainmenu()
        {
            Raylib.SetTargetFPS(60);
            startButtonPressed = false;
            exitButtonPressed = false;
            optionsButtonPressed = false;

            settingsScreen = new SettingsScreen();
            currentState = ScreenState.Start;
        }


        public void Draw()
        {
            Raylib.ClearBackground(Raylib.BLACK);

            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();
            if (currentState == ScreenState.Start)
            {
                // Tekstikenttä: Game name
                int titleWidth = Raylib.MeasureText("Avaruuspeli", 70);
                int titleX = (screenWidth - titleWidth) / 2;
                Raylib.DrawText("Avaruuspeli", titleX, 120, 70, Raylib.YELLOW);

                

                // Nappi: Aloita ohjelma
                int startButtonWidth = Raylib.MeasureText("Start", 100) + 80;
                int startButtonHeight = 50;
                int startButtonX = (screenWidth - startButtonWidth) / 2;
                int startButtonY = 450;
                startButtonPressed = RayGui.GuiButton(new Rectangle(startButtonX, startButtonY, startButtonWidth, startButtonHeight), "Start");

                // Nappi: Asetukset
                int optionsButtonWidth = Raylib.MeasureText("Options", 100) + 80;
                int optionsButtonHeight = 50;
                int optionsButtonX = (screenWidth - optionsButtonWidth) / 2;
                int optionsButtonY = 550;
                if (optionsButtonPressed = RayGui.GuiButton(new Rectangle(optionsButtonX, optionsButtonY, optionsButtonWidth, optionsButtonHeight), "Options"))
                {
                    currentState = ScreenState.Settings;
                }


                // Nappi: Ohjelman sulkeminen
                int exitButtonWidth = Raylib.MeasureText("Exit", 120) + 90;
                int exitButtonHeight = 50;
                int exitButtonX = (screenWidth - exitButtonWidth) / 2;
                int exitButtonY = 650;
                exitButtonPressed = RayGui.GuiButton(new Rectangle(exitButtonX, exitButtonY, exitButtonWidth, exitButtonHeight), "Exit");
                if (exitButtonPressed)
                {
                    Environment.Exit(0);
                }
            }
            else if (currentState == ScreenState.Settings)
            {
                settingsScreen.Draw();

                if (settingsScreen.Update())
                {
                    currentState = ScreenState.Start;
                }
            }
        }


        public bool IsStartPressed()
        {
            return startButtonPressed;
        }

        public bool ShouldExit()
        {
            return exitButtonPressed;
        }
    }
}