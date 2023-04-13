using System.Linq;
using System.Windows;


namespace InstrumetShop
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string password;
		public MainWindow()
		{
			InitializeComponent();
			Helper.DB = new Classes.DBInstrument();
			pbPassword.Visibility = Visibility.Visible;
			tbPassword.Visibility = Visibility.Hidden;
			isVisiblePas.IsChecked = false;

		}

		private void isVisiblePas_Checked(object sender, RoutedEventArgs e)
		{
			password = pbPassword.Password;
			pbPassword.Visibility = Visibility.Hidden;
			tbPassword.Text = password;
			tbPassword.Visibility = Visibility.Visible;
		}

		/// Отключить символы пароля
		private void isVisiblePas_Unchecked(object sender, RoutedEventArgs e)
		{
			password = tbPassword.Text;
			pbPassword.Password = password;
			pbPassword.Visibility = Visibility.Visible;
			tbPassword.Visibility = Visibility.Hidden;
		}

		private void Authorize_Click(object sender, RoutedEventArgs e)
		{
			string login = Login.Text;
			string password;



			if (isVisiblePas.IsChecked == true)
			{
				password = tbPassword.Text;
			}
			else
			{
				password = pbPassword.Password;
			}


			if (login == "" || password == "")
			{
				MessageBox.Show("Не все данные введены","Заполните все поля");
				return;
			}


			//Получить данные о пользователе с введенным логином и паролем
			Helper.user = Helper.DB.User.Where(x => x.UserLogin == login && x.UserPassword == password).ToList().FirstOrDefault();
			if (Helper.user == null)
			{
				MessageBox.Show("Ваших данных нет в БД","Ошибка данных");
				return;
			}
			else
			{
				MessageBox.Show("Вы зашли с ролью " + Helper.user.Role.RoleName);
				var newForm = new Catalog(); 
				newForm.Show(); 
				this.Close();
			}
			

		}

		private void GuestAutho_Click(object sender, RoutedEventArgs e)
		{
			Helper.user = null;                 
			MessageBox.Show("Вы зашли как гость");
			this.Hide();
			var newForm = new Catalog();
			newForm.Show();
			this.Close();

		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}
	}
}
