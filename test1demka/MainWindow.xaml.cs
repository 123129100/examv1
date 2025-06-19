using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
using test1demka.model;
namespace test1demka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<request> requests= new List<request>();
        private int currentPage = 1;
        private const int PageSize = 3; // Количество записей на странице
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private async void LoadData()

        {
            using (var context = new traintryEntities())
            {
                requests= await context.request.Include(e=>e.climateTechType).Include(e=>e.requestStatus).ToListAsync();
                datagrid.ItemsSource = requests;
                ShowCurrentPage();
            }
               
        }

      
        private void ShowCurrentPage()
        {
            // Берем нужную страницу из уже отсортированной коллекции
            var pageData = requests
                .Skip((currentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            datagrid.ItemsSource = pageData;
            PageInfo.Text = $"Стр. {currentPage}/{Math.Ceiling((double)requests.Count / PageSize)}";
        }

        private void PrevPage(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowCurrentPage();
            }
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
           
            if (currentPage < (int)Math.Ceiling((double)requests.Count / PageSize))
            {
                
                currentPage++;
                ShowCurrentPage();
            }

        }

        private void textSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string search = textSearch.Text.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(search))
                {
                    datagrid.ItemsSource = requests;
                    return;
                }

                if (requests == null || !requests.Any())
                {
                    return;
                }

                var filteredRequests = requests
          .Where(r =>
              (r.climateTechModel != null && r.climateTechModel.ToLower().Contains(search))
            
     
          )
          .ToList();

                datagrid.ItemsSource = filteredRequests;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}");
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            var AddNewReqest = new Addnew();

            AddNewReqest.Owner=this;
            AddNewReqest.ShowDialog();
        }
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = datagrid.SelectedItem as request;
            if (selectedRequest == null)
            {
                MessageBox.Show("Выберите запись для редактирования!");
                return;
            }

            // Открываем окно добавления в режиме редактирования
            var editWindow = new Addnew(selectedRequest);
            editWindow.Owner = this;
            editWindow.ShowDialog();

            // Обновляем данные после закрытия окна редактирования
            if (editWindow.DialogResult == true)
            {
                LoadData();
            }
        }
        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedDatagridItem = datagrid.SelectedItem as request;
            using (var context = new traintryEntities())
            {
                context.request.Attach(selectedDatagridItem);
                context.request.Remove(selectedDatagridItem);
                context.SaveChanges();
            }
            LoadData();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSort.SelectedIndex == 0) return;



            int selectedSortIndex = cbSort.SelectedIndex;


          
            var sortedRequests = requests.AsQueryable(); // Конвертируем в IQueryable для сортировки

            switch (selectedSortIndex)
            {
                case 0:
                    sortedRequests = sortedRequests.OrderBy(x => x.clientID);
                    break;
                case 1:
                    sortedRequests = sortedRequests.OrderBy(x => x.climateTechModel);
                    break;
               
                    // Добавьте другие варианты сортировки по необходимости
            }

            requests = sortedRequests.ToList();
            datagrid.ItemsSource = requests;
            ShowCurrentPage();
        }
    }
}
