namespace Super2DGame
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.Text = "Tank Game";
            this.Size = new Size(600, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            var game = new Game();
            this.Hide();
            game.ShowDialog();
            this.Show();
        }
    }
}
