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
        }
        
        MainMenu GameMenu;


    }
}
