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

namespace DelegatiV2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public int x = 8;

		public string txt = "Nesto";

		public delegate string OpisDelegata(string x);
		OpisDelegata OvoJeDelegat;
		OpisDelegata OvoJeDelegat2;
		OpisDelegata OvoJeDelegat3;

		Nesto OvoJeKlasa;
		Nesto OvoJeKlasa2;

		public MainWindow()
		{
			InitializeComponent();
			txt = "neki string";
			OvoJeDelegat = NekaMetoda;

			//MessageBox.Show(NekaMetoda("Test"));
			//MessageBox.Show(OvoJeDelegat("Test"));

			Nesto n1 = new Nesto(Nesto.Sabiranje);
			Nesto n2 = new Nesto(Nesto.Oduzimanje);
			Nesto n3 = new Nesto(Mnozenje);

			List<Nesto> lst = new List<Nesto>();
			lst.Add(n1);
			lst.Add(n2);
			lst.Add(n3);


			foreach (Nesto n in lst)
			{
				//MessageBox.Show(n.Operacija(5, 6).ToString());
			}

			Nesto Sveeee = new Nesto(Nesto.Sabiranje);
			Sveeee.Operacija += Nesto.Oduzimanje;
			Sveeee.Operacija += Mnozenje;
			Sveeee.Operacija += Nesto.Oduzimanje;
			Sveeee.Operacija += Nesto.Oduzimanje;
			Sveeee.Operacija += Nesto.Sabiranje;



			MessageBox.Show(Sveeee.Operacija(1, 2).ToString());


		}

		public string NekaMetoda(string a) => a.ToUpper();

		private int Mnozenje(int x, int y)
		{
			MessageBox.Show("Mnozenje");
			return x * y;
		}
	}

	public class Nesto
	{
		public static int Sabiranje(int x, int y)
		{
			MessageBox.Show("Sabiranje");
			return x + y;
		}
		public static int Oduzimanje(int x, int y)
		{
			MessageBox.Show("Oduzimanje");
			return x - y;
		}

		public delegate int TipOperacije(int a, int b);
		public TipOperacije Operacija;

		public Nesto(TipOperacije o)
		{
			Operacija = o;
			//MessageBox.Show(Operacija(5, 4).ToString());
		}

	}
}
