using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Project_O0001_ColorGrid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        

        
        

        void F1()
        {
            String k;
            int x;
            int y;
            Random rnd = new Random();
            while (param == true)
            {
                x = rnd.Next(0, 9);
                y = rnd.Next(0, 9);
                k = "R" + x.ToString() + y.ToString();
               
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                        {
                            // x = rnd.Next(0,9)
                            // R00.Fill = Brushes.AliceBlue;      // k.Fill = Brushes.Aqua;
                            //var u = (Rectangle)this.FindName(k);
                            //u.Fill = Brushes.Azure;
                            ((Rectangle)this.FindName(k)).Fill = Brushes.Red;
                        }
                                            );

                Thread.Sleep(TimeSpan.FromSeconds(1));

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                    {
                        // R00.Fill = Brushes.Blue;
                        ((Rectangle)this.FindName(k)).Fill = Brushes.White;
                    }
                                            );

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            
        }



        void F2()
        {
            String k;
            int x;
            int y;
            Random rnd = new Random();
            while (param == true)
            {
                x = rnd.Next(0, 9);
                y = rnd.Next(0, 9);
                k = "R" + x.ToString() + y.ToString();
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                    {
                        ((Rectangle)this.FindName(k)).Fill = Brushes.Blue;
                    }
                                            );

                Thread.Sleep(TimeSpan.FromSeconds(2));

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                    {
                        ((Rectangle)this.FindName(k)).Fill = Brushes.White;
                    }
                                            );

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

        }



        //   Thread myTread2 = new Thread(F2);


        Boolean param;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread Tread1 = new Thread(F1);
            Thread Tread2 = new Thread(F2);

            


            if ((String)btn.Content == "Старт")
            {
               // x = rnd.Next(0, 9);
              //  MessageBox.Show(x.ToString());
                btn.Content = "Стоп";
                param = true;
                Tread1.Start();
                Tread2.Start();
            }
            else
            {
                btn.Content = "Старт";
                // myTread.Suspend();
                // myTread2.Suspend();
                param = false; 
                 Tread1.Abort();
             //   myTread.Join(500);
                Tread2.Abort();
               // myTread2.Join(500);
            }

            //  Button myButton = new Button();
            // myButton.Content = "Привет";

            //Rectangle rectangle1 = new Rectangle();

            // object tag = ((Button)e.OriginalSource).Tag;
            // MessageBox.Show((string)tag);

           // Rectangle rectangle2 = new Rectangle();
            

            //R00.Fill = Brushes.Black;
            
            //Grid.SetColumn(btn, 0); //myRect is Rectangle
            //Grid.SetRow(btn, 1);
           

            //btn.Content = "Стоп";
        }
    }
}
