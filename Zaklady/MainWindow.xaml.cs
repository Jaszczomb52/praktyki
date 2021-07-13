using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Zaklady
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region global variables
        private Typo[] typy = {new Typo(50, "Zbychu"), new Typo(50, "Stachu"), new Typo(50, "Mirek")};
        private List<Bets> bets = new List<Bets>();
        private Random rand = new Random();
        private List<ContentControl> dogs;
        private int winner = 0;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Load();
            this.dogs = new List<ContentControl> { d1, d2, d3, d4 };
        }

        private void Load()
        {
            // method for loading RadioButton contents
            RadioButton[] typyRad = { Zbychu, Stachu, Mirek };
            for(int i = 0;i<3;i++)
            typyRad[i].Content =typy[i].name + " ma " + typy[i].money + "zł";
        }


        private double Start(ContentControl dog)
        {
            // method creating and playing animation of the dogs
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

        // global vars for this method
        bool win = false;
        int temp = 0;
        private void EndOfAnimation(ContentControl name)
        {
            // method to handle end of animation of the dogs
            temp++;
            if(temp == 8)
            {
                // what to do if every dog is at the end of the track
                LetTheDogs.IsEnabled = true;
                BetButton.IsEnabled = true;
                bets.Clear();
                ShowBets(0);
                temp = 0;
            }
            if(!win)
            {
                //what to do when the first dog made it to the end
                WinnerLabel.Content = "York numer " + name.Name.Substring(1) + " wygrywa!";
                win = true;
                winner = int.Parse(name.Name.Substring(1));
                //basicly adding money for the winner
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
            // method that is sending into label content the name of rn checked RadioButton
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
            // method to check if the person has enough money to bet
            for(int i=0;i<3;i++)
            {
                if (name == typy[i].name)
                    return typy[i].money;
            }
            return 0;
        }

        private void BetHandler()
        {
            // method for handling bets
            try
            {
                int bet = int.Parse(Bet.Text);
                if (bet >= 5 && bet <= Check((string)BetName.Content) && int.Parse(DogNumber.Text) < 5 && int.Parse(DogNumber.Text) > 0)
                {
                    // if guy has enough money and bet is not higher than his money and the number of the dog is between 1 and 4
                    if(bets.Count != 0) // check if any bet exists
                    {
                        for (int i = 0; i < bets.Count; i++)
                        {
                            
                            if (bets[i].name == (string)BetName.Content) // check if there is already bet of cetrain guy
                            {
                                bets[i].amount += bet; // add money to the bet
                                bets[i].york = int.Parse(DogNumber.Text); // change the dog
                                break;
                            }
                            else if(i+1 == bets.Count) // check if the loop is at the end of the list and still no existing bet of this person
                            {
                                bets.Add(new Bets((string)BetName.Content, bet, int.Parse(DogNumber.Text))); // add the bet to the list
                                break;
                            }
                        }
                        ShowBets(bet); // show the list of the bets
                    }
                    else
                    {
                        bets.Add(new Bets((string)BetName.Content, bet, int.Parse(DogNumber.Text))); // add new bet if there's no bets
                        ShowBets(bet); // and show the list of the bets
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
                Bets last = bets.Last(); // get the last bet that has been added
            

                // basicly checking which guy made the last bet and sending info to the textboxes which represents the list of the bets
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
            catch (Exception) // if something goes brrr then just make them empty
            {
                MirekBet.Text = "";
                StachuBet.Text = "";
                ZbychuBet.Text = "";
            }
            Load(); //reload RadioButtons with info about guys and their money
        }

        #region click handlers
        private void BetButtonClick(object sender, RoutedEventArgs e)
        {
            BetHandler();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            // starting animation of the dogs
            WinnerLabel.Content = "";
            win = false;
            //this block of code is creating animation with the time of the animation that hasn't been used yet so every dog has diffrent speed
            double[] times = { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
            repeat: 
                double temp = Start(dogs[i]);
                for (int j = 0; j < 4; j++)
                {
                    if (times[j] == temp)
                    {
                        goto repeat;
                    }
                }
                times[i] = temp;
            }
            // disabling stuffs so people won't break it
            LetTheDogs.IsEnabled = false;
            BetButton.IsEnabled = false;
        }
        #endregion
    }
}
