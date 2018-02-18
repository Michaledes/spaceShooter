using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceShooter
{
    public partial class MainWindow : Form
    {
        public MainWindow()            
        {
            InitializeComponent();

            //this.ClientSize = new Size(1024, 768);
            this.ClientSize = new Size(800, 600);

            GameMenu = new MainMenu();
            GameMenu.Parent = this;
            GameMenu.Dock = DockStyle.Fill;
           
            GameMenu.Show();

            GameMenu.ItemChoosed += Menu_ItemChoosed;
        }

        MainMenu GameMenu;

        private void Menu_ItemChoosed(MenuItems menuItems)
        {
            switch (menuItems)
            {
                case MenuItems.NewGame:
                    GameMenu.Dispose();
                    GameMenu = null;
                    StartGame();
                    break;
                case MenuItems.End:
                    Application.Exit();
                    break;
            }
        }

        private void StartGame()
        {
            this.BackColor = Color.Black;
            GameWorld game = new GameWorld(this);
        }
    }
}
