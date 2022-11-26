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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Home5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// static void BuyBeer(int age) {
    public partial class MainWindow : Window
    {
        static void Correct(int number1, int number2, int number3)
        {
            if (number1 < 0 || number2 < 0 || number3 < 0)
            {
                throw new Exception("Ошибка!");
            }
        }
        class Vagon
        {
            public int number;
            public int quan_bdseat;
            public int quan_seat;
            public int SUMM(int a, int b)
            {
                return a + b;
            }

        }
        int num = 0, Summax = 0;//какой по счету вагон
        Vagon[] vagon = new Vagon[4];
        private void button_Click(object sender, RoutedEventArgs e) //обработка нажатия кнопки
        {
            vagon[num] = new Vagon();//инициализация
            string input_numb = Tb_numb.Text;
            string input_bdst = Tb_bdst.Text;
            string input_seat = Tb_seat.Text;
            int numb = 0, bdst = 0, seat = 0;
            try //обработка нажатия кнопки
            {
                numb = int.Parse(input_numb);
                bdst = int.Parse(input_bdst);
                seat = int.Parse(input_seat);
                Correct(numb, bdst, seat);//проверка на положитнльность
                for (int i = 0; i < num; i++)
                {
                    if (vagon[i].number == numb)
                    {
                        MessageBox.Show("Номера вагонов совпали", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                }
            }
            catch (FormatException)

            {
                MessageBox.Show("Некоректный ввод", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Числа меньше ноля", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int Sum = vagon[num].SUMM(bdst, seat);
            Tb_seatsum.Text = Sum.ToString();//вывод суммы
            vagon[num].number = numb;
            vagon[num].quan_bdseat = bdst;
            vagon[num].quan_seat = seat;
            if (num == 3)//находим максмальный и выводим о нем информацию
            {
                int summax = 0, purp = 0;
                for (int j = 0; j < 4; j++)
                {
                    int tp = vagon[j].SUMM(vagon[j].quan_bdseat, vagon[j].quan_seat);//сумма j
                    if (tp > summax)
                    {
                        summax = tp;
                        purp = j;
                    }
                }
                Tb_numb.Text = vagon[purp].number.ToString();
                Tb_bdst.Text = vagon[purp].quan_bdseat.ToString();
                Tb_seat.Text = vagon[purp].quan_seat.ToString();
                Tb_seatsum.Text = summax.ToString();
                Lbl_result.Visibility = Visibility.Visible; ;
            }
            num++;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}