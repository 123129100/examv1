using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using test1demka.model;

namespace test1demka
{
    /// <summary>
    /// Логика взаимодействия для Addnew.xaml
    /// </summary>
    /// 
    public partial class Addnew : Window
    {
        private bool _isEditMode;
        private readonly request _editingRequest;
        public Addnew()
        {
            InitializeComponent();
            LoadData();
        }

         public async void LoadData()
        {
            using (var context = new traintryEntities())
            {
                var statuses = await context.requestStatus.ToArrayAsync();

                cmb_status.DisplayMemberPath = "requestStatusName"; // Какое свойство отображать
                cmb_status.SelectedValuePath = "requestStatusID"; // Какое свойство использовать как значение

                foreach (var stat in statuses)
                {
                    cmb_status.Items.Add(stat); // Добавляем объект целиком
                }


            }
        }
        public Addnew(request requestToEdit) : this()
        {
            _editingRequest = requestToEdit;
            _isEditMode = true;
            FillFormWithData(requestToEdit);
        }

        private void FillFormWithData(request request)
        {
            if (request == null) return;

            // Заполняем элементы управления данными из объекта
            dpStartDate.SelectedDate = request.startDate;
            txbClimateTechTypeID.Text = request.climateTechTypeID.ToString();
            txbProblemDescription.Text = request.problemDescryption;
            txbCompletionDate.Text = request.completionDate;
            txbRepairParts.Text = request.repairParts;
            txbMasterID.Text = request.masterID.ToString();
            txbClientID.Text = request.clientID.ToString();
            txbRequest.Text = request.climateTechModel;
            cmb_status.SelectedValue = request.requestStatusID;
            txbClimateTechTypeID.Text = request.climateTechTypeID.ToString();
            // Если нужно заполнить combobox для climateTechType
          
        }
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new traintryEntities())
                {
                    request requestToSave;

                    if (_isEditMode)
                    {
                        // Редактирование существующей записи
                        requestToSave = context.request.Find(_editingRequest.requestID);
                        if (requestToSave == null) return;
                    }
                    else
                    {
                        // Создание новой записи
                        requestToSave = new request();
                        context.request.Add(requestToSave);
                    }
                    var climetTech = new climateTechType
                    {
                        climateTechType1 = tbxTypeTech.Text,

                    };

                    context.climateTechType.Add(climetTech);
                    context.SaveChanges();
                    int climetTechId = climetTech.climateTechTypeID;
                    var Request = new request
                    {


                        startDate = dpStartDate.SelectedDate.Value,
                        climateTechTypeID = climetTechId,

                        problemDescryption = txbProblemDescription.Text,

                        completionDate = txbCompletionDate.Text,
                        repairParts = txbRepairParts.Text,
                        masterID = Int32.Parse(txbMasterID.Text),
                        clientID = Int32.Parse(txbClientID.Text),
                        climateTechModel = txbRequest.Text,
                        requestStatusID = (int)cmb_status.SelectedValue,


                    };

                    context.SaveChanges();
                    DialogResult = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Остальные методы остаются без изменений
    }

  
    }

