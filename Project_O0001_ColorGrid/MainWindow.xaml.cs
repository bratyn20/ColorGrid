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
using System.Globalization;

namespace Project_O0001_ColorGrid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> Cars = new List<Car>();
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
                            // ((Rectangle)this.FindName(k)).Fill = Brushes.Red;
                            var firstRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items[x]);
                            var firstColumnFirstRow = (DataGridCell)dataGrid.Columns[y].GetCellContent(firstRow).Parent;
                            firstColumnFirstRow.Background = Brushes.Red;
                        }
                                            );

                Thread.Sleep(TimeSpan.FromSeconds(1));

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                    {
                        // R00.Fill = Brushes.Blue;
                        //((Rectangle)this.FindName(k)).Fill = Brushes.White;
                        var firstRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items[x]);
                        var firstColumnFirstRow = (DataGridCell)dataGrid.Columns[y].GetCellContent(firstRow).Parent;
                        firstColumnFirstRow.Background = Brushes.White;
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
                        //((Rectangle)this.FindName(k)).Fill = Brushes.Blue;
                        var firstRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items[x]);
                        var firstColumnFirstRow = (DataGridCell)dataGrid.Columns[y].GetCellContent(firstRow).Parent;
                        firstColumnFirstRow.Background = Brushes.Blue;
                    }
                                            );

                Thread.Sleep(TimeSpan.FromSeconds(2));

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                    {
                        //((Rectangle)this.FindName(k)).Fill = Brushes.White;
                        var firstRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items[x]);
                        var firstColumnFirstRow = (DataGridCell)dataGrid.Columns[y].GetCellContent(firstRow).Parent;
                        firstColumnFirstRow.Background = Brushes.White;
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


        public class Car
        {
            public int Id1 { get; set; }
            public int Id2 { get; set; }
            public int Id3 { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cars.Clear();
            for (int i = 0; i<= 9; i++) {
                Cars.Add(new Car() { Id1 = i*10 + 0, Id2 = i*10 + 1, Id3 = i*10 + 2 });
            }

        /*    Cars.Add(new Car() { Id1 = "1", Id2 = "2", Id3 = "3" });
            Cars.Add(new Car() { Id1 = "4", Id2 = "5", Id3 = "6" });
            Cars.Add(new Car() { Id1 = "7", Id2 = "8", Id3 = "9" });
            Cars.Add(new Car() { Id1 = "10", Id2 = "11", Id3 = "12" });*/


            dataGrid.ItemsSource = Cars;
            dataGrid.Background = Brushes.White;
        }


    }
    class IdToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           /* if ((int)value == 20)
            {
              new SolidColorBrush(Colors.Aqua);
            }
            else
            {
               new SolidColorBrush(Colors.White);
            }*/
             return (int)value == 20 ? new SolidColorBrush(Colors.Yellow) : new SolidColorBrush(Colors.White);
           // return new  SolidColorBrush();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
