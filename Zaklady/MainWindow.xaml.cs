using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zaklady
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Typo[] typy = {new Typo(50, "Zbychu"), new Typo(50, "Stachu"), new Typo(50, "Mirek")};
        private List<Bets> bets = new List<Bets>();
        private Random rand = new Random();
        private List<ContentControl> dogs;
        private int winner = 0;
        public MainWindow()
        {
            InitializeComponent();
            Load();
            this.dogs = new List<ContentControl> { d1, d2, d3, d4 };
        }

        private void Load()
        {
            RadioButton[] typyRad = { Zbychu, Stachu, Mirek };
            for(int i = 0;i<3;i++)
            typyRad[i].Content =typy[i].name + " ma " + typy[i].money + "zł";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BetHandler();
        }

        private double Start(ContentControl dog)
        {
            Storyboard story = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 0,
                To = track.Width-imgDog.Width,
                Duration = new Duration(TimeSpan.FromSeconds(rand.Next(4, 10)))
            };
            animation.Completed += (s, a) => EndOfAnimation(dog);
            story.Children.Add(animation);
            Storyboard.SetTarget(animation, dog);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Left)"));
            story.Children.Add(animation);
            story.Begin();
            return (double)animation.Duration.TimeSpan.TotalSeconds;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WinnerLabel.Content = "";
            win = false;
            double[] times = {0,0,0,0};
            for(int i=0;i<4;i++)
            {
                repeat:
                double temp = Start(dogs[i]);
                for (int j = 0; j < 4; j++)
                {
                    if(times[j] == temp)
                    {
                        goto repeat;
                    }
                }
                times[i] = temp;

            }
            LetTheDogs.IsEnabled = false;
            BetButton.IsEnabled = false;
        }

        bool win = false;
        int temp = 0;
        private void EndOfAnimation(ContentControl name)
        {
            temp++;
            if(temp == 8)
            {
                LetTheDogs.IsEnabled = true;
                BetButton.IsEnabled = true;
                bets.Clear();
                ShowBets(0);
                temp = 0;
            }
            if(!win)
            {
                WinnerLabel.Content = "York numer " + name.Name.Substring(1) + " wygrywa!";
                win = true;
                winner = int.Parse(name.Name.Substring(1));
                for(int i=0;i<bets.Count;i++)
                {
                    if(bets[i].Check(winner))
                    {
                        for(int j=0;j<3;j++)
                        {
                            if(typy[j].name == bets[i].name)
                                typy[j].money += (bets[i].amount * 2);
                        }
                    }
                }
            }
        }

        private void ChangeName(object sender, RoutedEventArgs e)
        {
            RadioButton[] radio = { Zbychu, Stachu, Mirek };
            foreach(RadioButton element in radio)
            {
                if((bool)element.IsChecked)
                {
                    BetName.Content = element.Name;
                }
            }
        }

        private int Check(string name)
        {
            for(int i=0;i<3;i++)
            {
                if (name == typy[i].name)
                    return typy[i].money;
            }
            return 0;
        }

        private void BetHandler()
        {
            try
            {
                int bet = int.Parse(Bet.Text);
                if (bet >= 5 && bet <= Check((string)BetName.Content) && int.Parse(DogNumber.Text) < 5 && int.Parse(DogNumber.Text) > 0)
                {
                    if(bets.Count != 0)
                    {
                        for (int i = 0; i < bets.Count; i++)
                        {
                            
                            if (bets[i].name == (string)BetName.Content)
                            {
                                bets[i].amount += bet;
                                break;
                            }
                            else if(i+1 == bets.Count)
                            {
                                bets.Add(new Bets((string)BetName.Content, bet, int.Parse(DogNumber.Text)));
                                break;
                            }
                        }
                        ShowBets(bet);
                    }
                    else
                    {
                        bets.Add(new Bets((string)BetName.Content, bet, int.Parse(DogNumber.Text)));
                        ShowBets(bet);
                    }
                }
                else if(bet < 5)
                {
                    MessageBox.Show("Za mały zakład");
                }
                else
                {
                    MessageBox.Show("Za malo pieniedzy lub zły numer psa");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wpisz poprawne dane");
            }
        }

        private void ShowBets(int bet)
        {
            
            try
            {
                Bets last = bets.Last();
            
                if (last.name == "Zbychu")
                {
                    ZbychuBet.Text = last.name + " wrzucił " + last.amount + " zł na psa numer " + last.york;
                    typy[0].money -= bet;
                }
                else if (last.name == "Stachu")
                {
                    StachuBet.Text = last.name + " wrzucił " + last.amount + " zł na psa numer " + last.york;
                    typy[1].money -= bet;
                }
                else
                {
                    MirekBet.Text = last.name + " wrzucił " + last.amount + " zł na psa numer " + last.york;
                    typy[2].money -= bet;
                }
            }
            catch (Exception)
            {
                MirekBet.Text = "";
                StachuBet.Text = "";
                ZbychuBet.Text = "";
            }
            Load();
        }
    }
}
