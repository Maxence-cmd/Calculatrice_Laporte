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







<Window x:Class="CalculatriceLaporte.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CalculatriceLaporte"
        mc:Ignorable="d"
                Title="Calculateur" Height="400" Width="350" Background="#5E807F">
    <Grid>
        <Grid.ColumnDefinitions>
            <!-- ******************************* Définition des colonnes **********************************-->
            <ColumnDefinition/>
            <ColumnDefinition Width="17*"/>
            <ColumnDefinition Width="18*"/>
            <ColumnDefinition Width="18*"/>
            <ColumnDefinition Width="80"/>
        </Grid.ColumnDefinitions>
        <!-- ******************************* Définition des lignes **********************************-->
        <Grid.RowDefinitions>
            <RowDefinition Height="150"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Grid.Resources>
            <!-- ******************************* Définition couleur et taille,... de tous les boutons **********************************-->
            <Style TargetType="{x:Type Button}">
                <Setter Property="Margin" Value="10"/>
                <Setter Property="Background" Value="#DEE5E5"/>
                <Setter Property="FontSize" Value="14"/>
                <Style.Resources>
                    <Style TargetType="Border">
                        <Setter Property="CornerRadius" Value="5"/>
                    </Style>
                </Style.Resources>
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Background" Value="DarkGray"/>
                        <Setter Property="Foreground" Value="White"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
            <!-- *******************************  Définition couleur et taille,... du texteblock **********************************-->
            <Style x:Key="TB" TargetType="{x:Type TextBlock}">
                <Setter Property="Margin" Value="10"/>
                <Setter Property="Background" Value="#17B890"/>
                <Setter Property="FontSize" Value="28"/>
                <Style.Resources>
                    <Style TargetType="Border">
                        <Setter Property="Background" Value="Black"/>
                    </Style>
                </Style.Resources>

            </Style>
            <!-- *******************************  Définition couleur et taille,... du button égale **********************************-->
            <Style x:Key="Egale" TargetType="{x:Type Button}">
                <Setter Property="Margin" Value="10"/>
                <Setter Property="Background" Value="#9DC5BB"/>
                <Setter Property="FontSize" Value="18"/>
            </Style>
        </Grid.Resources>
        <!-- ******************************* Row1 **********************************-->
        <TextBlock Grid.Row="0"  Grid.ColumnSpan="4" x:Name="TB_Display" Text="0" Style="{StaticResource TB}" Grid.Column="1"/>
        <!-- ******************************* Row2 **********************************-->

        <Button Grid.Column="4" Content="/"  Grid.Row="1" Name="BTN_D" Click="BTN_OP_Click" />
        <Button Grid.Column="1" Content="CE"  Grid.Row="1" Name="BTN_CE" Click="BTN_CE_Click" />
        <Button Grid.Column="2" Content="√"  Grid.Row="1" Name="BTN_RCN" Click="BTN_CARRE8RACINE_Click" />
        <Button Grid.Column="3" Content="%"  Grid.Row="1" Name="BTN_MOD" Click="BTN_OP_Click" />

        <!-- ******************************* Row3 **********************************-->
        <Button Grid.Column="1" Content="1"  Grid.Row="2" Name="BTN_1" Click="BTN_Click"  />
        <Button Grid.Column="2" Content="2" Grid.Row="2" Name="BTN_2" Click="BTN_Click"  />
        <Button Grid.Column="3" Content="3"  Grid.Row="2" Name="BTN_3" Click="BTN_Click" />
        <Button Grid.Column="4" Content="*"  Grid.Row="2" Name="BTN_F" Click="BTN_OP_Click" />
        <!-- ******************************* Row4 **********************************-->

        <Button Grid.Column="1" Content="4"  Grid.Row="3" Name="BTN_4" Click="BTN_Click"  />
        <Button Grid.Column="2" Content="5"  Grid.Row="3" Name="BTN_5" Click="BTN_Click" />
        <Button Grid.Column="3" Content="6"  Grid.Row="3" Name="BTN_6" Click="BTN_Click" />
        <Button Grid.Column="4" Content="-"  Grid.Row="3" Name="BTN_M" Click="BTN_OP_Click" />
        <!-- ******************************* Row5 **********************************-->

        <Button Grid.Column="1" Content="7"  Grid.Row="4" Name="BTN_7" Click="BTN_Click" />
        <Button Grid.Column="2" Content="8"  Grid.Row="4" Name="BTN_8" Click="BTN_Click" />
        <Button Grid.Column="3" Content="9"  Grid.Row="4" Name="BTN_9" Click="BTN_Click" />
        <Button Grid.Column="4" Content="+"  Grid.Row="4" Name="BTN_PL" Click="BTN_OP_Click" />
        <!-- ******************************* Row6 **********************************-->

        <Button Grid.Column="1" Content="0"  Grid.Row="5" Name="BTN_0" Click="BTN_Click" />
        <Button Grid.Column="2" Content="."  Grid.Row="5" Name="BTN_PO" Click="BTN_PO_Click" />
        <Button Grid.Column="4" Content="="  Style="{StaticResource Egale}" Grid.Row="5" Name="BTN_E" Click="BTN_E_Click" />
        <Button Grid.Column="3" Content="²"  Grid.Row="5" Name="BTN_carre" Click="BTN_CARRE8RACINE_Click"  />


    </Grid>

</Window>

