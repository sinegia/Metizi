using InstrumetShop.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InstrumetShop
{
	/// <summary>
	/// Логика взаимодействия для Catalog.xaml
	/// </summary>
	public partial class Catalog : Window
	{
		public Catalog()
		{
			InitializeComponent();

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//Формирование списка категорий из таблицы БД + строка "Все категории"
			var category = Helper.DB.Type.Select(x => x.TypeName).ToList();
			var purp = Helper.DB.Purpose.Select(x => x.PurposeName).ToList();
			var name = Helper.DB.Name.Select(x => x.NameOfProduct).ToList();//Все категории

			purp.Insert(0, "Все категории");
			category.Insert(0, "Все категории");
			//Добавить первой «Все категории»
			comboCategory.ItemsSource = category;
			comboSale.ItemsSource = purp;

			comboCategory.Text = comboCategory.Items[0].ToString();
			comboSale.Text = comboSale.Items[0].ToString();
			comboSort.Text = comboSort.Items[0].ToString();
			if (Helper.user == null)
			{
				FIOUser.Text = "Гость";
			}
			else
			{
				FIOUser.Text = Helper.user.UserPatronymic + " " + Helper.user.UserSurname + " " + Helper.user.UserName;    // ФИО клиента
			}
			//Начальные данные для фильтрации
			filterDiscount = 0;
			filterCategory = 0;
			sort = "ASC";

			//Видимость кнопки для добавления товара (роль Администратора)
			butAddProduct.Visibility = Visibility.Hidden;
			butViewOrder.Visibility = Visibility.Hidden;
			conMenu.Visibility = Visibility.Hidden;
			if (Helper.user != null && Helper.user.RoleId == 3)
			{
				butAddProduct.Visibility = Visibility.Visible;
			}
			//Возможность сделать заказ для клиента или менеджера
			if (Helper.user == null || Helper.user.RoleId == 1)
			{
				conMenu.Visibility = Visibility.Visible;
			}
			else
			{
				conMenu.Visibility = Visibility.Hidden;
			}
			ShowProduct();
		}

		/// Выбор направления сортировки
		private void comboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (comboSort.SelectedIndex == 0) sort = "ASC";
			else sort = "DESC";
			ShowProduct();
		}

		/// Выбор назначения
		private void comboSale_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			filterDiscount = comboSale.SelectedIndex;
			ShowProduct();
		}

		/// Выбор категории
		private void comboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			filterCategory = comboCategory.SelectedIndex;
			ShowProduct();
		}

		/// Ввод строки поиска
		private void search_TextChanged(object sender, TextChangedEventArgs e)
		{
			searchProduct = search.Text;
			ShowProduct();
		}


		int filterDiscount, filterCategory;         //Фильтр по скидке и категории
		string sort;								//Направление сортировки
		int countAll, countFilter;					//Количество всех записей и после фильтрации
		string searchProduct;						//Строка поиска

		private void buttonExit_Click(object sender, RoutedEventArgs e)
		{               
			this.Hide();
			var newForm = new MainWindow();
			newForm.Show();
			this.Close();
		}

		private void butViewOrder_Click(object sender, RoutedEventArgs e)
		{

		}

		private void butAddProduct_Click(object sender, RoutedEventArgs e)
		{

		}

		private void listProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		List<Classes.Product> products;

		/// Получить данные из БД по условия фильтра и отобразить их
		private void ShowProduct()
		{
			products = Helper.DB.Product.ToList();
			//Общее количество товаров в таблице товаров
			countAll = products.Count();

			//Фильтрация по категории
			if (filterCategory != 0)
			{
				products = products.Where(x => x.TypeId == filterCategory).ToList();
			}

			if (filterDiscount != 0)
			{
				products = products.Where(x => x.PurposeId == filterDiscount).ToList();
			}
			//Поиск по названию
			if (!String.IsNullOrEmpty(searchProduct))
			{
				products = products.Where(x => x.Name.NameOfProduct.Contains(searchProduct)).ToList();
			}
			//Сортировка
			if (sort == "ASC")
			{
				products = products.OrderBy(x => x.ProductCost).ToList();
			}
			else
			{
				products = products.OrderByDescending(x => x.ProductCost).ToList();
			}
			//Количество записей посел фильтрации
			countFilter = products.Count();
			CountRec.Text = countFilter + " из " + countAll;


			//Отобразить все продукты в ListView
			listProducts.ItemsSource = products;  
		}

	}
}
