using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CalculatriceLaporte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        double nb1 = 0;
        double nb2 = 0;
        char op = ' ';
        double res = 0;
        string affichage = " ";
        bool newEntry = true;
        char point = ' ';
        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            String btnContent = btn.Content.ToString();
            if (newEntry || TB_Display.Text == "0" || TB_Display.Text == "Erreur") // efface s'il y a un zéro ou une erreur pour mettre le nouveau chiffre

            {
                TB_Display.Text = btnContent;
                newEntry = false;
            }
            else
            {
                // Sinon on ajoute à la fin (concaténation)
                TB_Display.Text += btnContent;

            }
        }
        private void BTN_OP_Click(object sender, RoutedEventArgs e)
        {
            // Récupération du bouton cliqué
            Button btn = sender as Button;
            char btnContent = char.Parse(btn.Content.ToString());
            try
            {
                nb1 = double.Parse(TB_Display.Text);
            }
            catch
            {
                TB_Display.Text = "Erreur";
            }
            TB_Display.Text += " " + btnContent;
            op = btnContent;
            TB_Display.Text = null;
            point = ' ';
        }
        private void BTN_CARRE8RACINE_Click(object sender, RoutedEventArgs e)
        {
            // Récupération du bouton cliqué si c'est une racine carre ou un carre
            Button btn = sender as Button;
            char btnContent = char.Parse(btn.Content.ToString());
            try
            {
                nb1 = double.Parse(TB_Display.Text);
            }
            catch
            {
                TB_Display.Text = "Erreur";
            }
            if (btnContent == '²')
                TB_Display.Text = nb1 + "²";
            else
                TB_Display.Text = "√" + nb1;
            op = btnContent;
            point = ' ';
        }
        private void BTN_PO_Click(object sender, RoutedEventArgs e)
        //Chiffre à virguyle
        {
            if (point == ',')
            {
                TB_Display.Text = TB_Display.Text;
            }
            else
            {
                TB_Display.Text += ",";
                point = ',';
            }
        }
        private void BTN_E_Click(object sender, RoutedEventArgs e)
        {
            if (op == '√')
                res = Math.Round(Math.Sqrt(nb1), 8);
            else if (op == '²')
                res = Math.Pow(nb1, 2);
            else
                nb2 = double.Parse(TB_Display.Text);

            affichage = rescase(nb1, nb2, op);
            TB_Display.Text = affichage;
            op = ' ';
            point = ' ';
        }
        public double addition(double nb1, double nb2)
        {
            return res = nb1 + nb2;
        }
        public double multiplication(double nb1, double nb2)
        {
            return res = nb1 * nb2;
        }
        public double soustraction(double nb1, double nb2)
        {
            return res = nb1 - nb2;
        }
        public double modulo(double nb1, double nb2)
        {
            return res = nb1 % nb2;
        }
        public double division(double nb1, double nb2)
        {
            return res = nb1 / nb2;
        }
        public string rescase(double nb1, double nb2, char op)
        {

            switch (op)
            {
                case '+':
                    res = addition(nb1, nb2);
                    break;

                case '-':
                    res = soustraction(nb1, nb2);
                    break;

                case '%':
                    res = modulo(nb1, nb2);
                    break;

                case '*':
                    res = multiplication(nb1, nb2);
                    break;

                case '/':
                    res = division(nb1, nb2);
                    break;

            }
            string result = res.ToString();

            return result;
        }

        private void BTN_CE_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = null;
            point = ' ';
            op = ' ';
        }
    }
}
