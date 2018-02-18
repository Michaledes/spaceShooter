using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceShooter
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();

            this.BackColor = Color.Black;
            this.DoubleBuffered = true;

            this.Paint += PaintEventoperation;

            this.MouseDoubleClick += MainMenu_MouseClick;
        }

        MenuItems ChoosedItem;

        const int ItemWidth = 400;
        const int ItemHeight = 100;

        Rectangle NewGameRectangle;
        Rectangle EndGameRectangle;        

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Position where te menu item will be shown
            NewGameRectangle = new Rectangle(   (this.Parent.ClientRectangle.Width - ItemWidth) / 2,
                                                (this.Parent.ClientRectangle.Height - ItemHeight) / 2,
                                                ItemWidth,
                                                ItemHeight);

            // Position where te menu item will be shown
            EndGameRectangle = new Rectangle(   (this.Parent.ClientRectangle.Width - ItemWidth) / 2,
                                                (this.Parent.ClientRectangle.Height - ItemHeight) / 2 + ItemHeight * 2,
                                                ItemWidth,
                                                ItemHeight);
        }

        private void PaintEventoperation(object sender, PaintEventArgs e)
        {
            Image newGameImg = Properties.Resources.NovaHraNeoznaceno;
            Image endGameImg = Properties.Resources.KonecNeoznaceno;

            // Change of menu items appearance.
            switch (ChoosedItem)
            {
                case MenuItems.NewGame:
                    newGameImg = Properties.Resources.NovaHraOznaceno;
                    break;
                case MenuItems.End:
                    endGameImg = Properties.Resources.KonecOznaceno;
                    break;
            }

            //Drawing of geme menu items.
            e.Graphics.DrawImage(newGameImg, NewGameRectangle);
            e.Graphics.DrawImage(endGameImg, EndGameRectangle);
        }

        // generated service method
        private void MainMenu_MouseClick(object sender, MouseEventArgs e)
        {
            int countOfClicks = e.Clicks;

            if (NewGameRectangle.Contains(e.Location))
            {
                ChoosedItem = MenuItems.NewGame;
            }
            else if (EndGameRectangle.Contains(e.Location))
            {
                ChoosedItem = MenuItems.End;
            }

            // discern double click
            if (countOfClicks == 2)
            {
                ItemChoosed(ChoosedItem);
            }

            Invalidate();
        }

        public delegate void DelegateChoosingItem(MenuItems menuItems);

        public event DelegateChoosingItem ItemChoosed;
    }
}
