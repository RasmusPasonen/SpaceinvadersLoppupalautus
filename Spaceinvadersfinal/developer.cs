using Raylib_CsLo;

namespace Spaceinvaders
{
    internal class developer
    {
        private bool backButtonPressed;
        public bool invincibilityToggled;

        public developer()
        {
            Raylib.SetTargetFPS(60);
            backButtonPressed = false;
            invincibilityToggled = false;
        }

        public void Draw()
        {
            Raylib.ClearBackground(Raylib.BLACK);

            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            
            int titleWidth = Raylib.MeasureText("Dev menu", 60);
            int titleX = (screenWidth - titleWidth) / 2;
            Raylib.DrawText("Dev menu", titleX, 150, 60, Raylib.WHITE);

           
            int toggleButtonWidth = Raylib.MeasureText("Toggle Kuolemattomuus", 80) + 60;
            int toggleButtonHeight = 50;
            int toggleButtonX = (screenWidth - toggleButtonWidth) / 2;
            int toggleButtonY = (screenHeight - toggleButtonHeight) / 2;

            if (RayGui.GuiButton(new Rectangle(toggleButtonX, toggleButtonY, toggleButtonWidth, toggleButtonHeight), "Toggle Kuolemattomuus"))
            {
                invincibilityToggled = !invincibilityToggled;
            }

            string invincibilityStatus = "Kuolemattomuus: " + (invincibilityToggled ? "Päälle" : "Pois");
            int statusWidth = Raylib.MeasureText(invincibilityStatus, 20);
            int statusX = (screenWidth - statusWidth) / 2;
            Raylib.DrawText(invincibilityStatus, statusX, toggleButtonY - 40, 20, Raylib.WHITE);

            
            int backButtonWidth = Raylib.MeasureText("Back", 40) + 20;
            int backButtonHeight = 50;
            int backButtonX = (screenWidth - backButtonWidth) / 2;
            int backButtonY = screenHeight - backButtonHeight - 30;
            backButtonPressed = RayGui.GuiButton(new Rectangle(backButtonX, backButtonY, backButtonWidth, backButtonHeight), "Back");
        }

        public bool IsBackPressed()
        {
            return backButtonPressed;
        }

        public bool IsInvincibilityToggled()
        {
            return invincibilityToggled;
        }

    }
}