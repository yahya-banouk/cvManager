using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using cvManager.Model;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace cvManager.View
{
    /// <summary>
    /// Logique d'interaction pour CondidateCRViewerView.xaml
    /// </summary>
    public partial class CondidateCRViewerView : Window 
    {
        readonly string connectionString = "Server=(local); Database=cvManager; Integrated Security=true";
        readonly SqlConnection sqlConnection= new SqlConnection();
        string searchString;
        public CondidateCRViewerView()
        {
            InitializeComponent();
        }
        public CondidateCRViewerView(string searchString)
        {
            InitializeComponent();
            this.searchString = searchString;

        }

        private void CondidateViewer_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection.ConnectionString = connectionString;
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                string requestString;

                SqlCommand countCommand = new SqlCommand("select count(*) from condidate where (Name LIKE '%" + searchString + "%' ) or (LastName LIKE '%" + searchString + "%') or  (Email LIKE '%" + searchString + "%') or ([Level] LIKE '%" + searchString + "%') or (Profession LIKE '%" + searchString + "%') or (Sexe LIKE '%" + searchString + "%') or (City LIKE '%" + searchString + "%') or (Driver LIKE '%" + searchString + "%')",sqlConnection) ;
                int counted = (Int32)countCommand.ExecuteScalar();
                if(counted>=1)
                {
                    requestString = "Select * from condidate where (Name LIKE '%" + searchString + "%' ) or (LastName LIKE '%" + searchString + "%') or  (Email LIKE '%" + searchString + "%') or ([Level] LIKE '%" + searchString + "%') or (Profession LIKE '%" + searchString + "%') or (Sexe LIKE '%" + searchString + "%') or (City LIKE '%" + searchString + "%') or (Driver LIKE '%" + searchString + "%')";

                }
                else
                {
                    requestString = "Select * from condidate ";
                }

                //doesn't matter now 
                //requestString = "Select * from condidate where (Name LIKE '%" + searchString + "%' ) or (LastName LIKE '%" + searchString + "%') or  (Email LIKE '%" + searchString + "%') or ([Level] LIKE '%" + searchString + "%') or (Profession LIKE '%" + searchString + "%') or (Sexe LIKE '%" + searchString + "%') or (City LIKE '%" + searchString + "%') or (Driver LIKE '%" + searchString + "%')";
                CondidateCRDataset CondidateDataset = new CondidateCRDataset();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(requestString, sqlConnection);
                sqlDataAdapter.Fill(CondidateDataset.Tables["condidate"]);
                CRCondidatePrinter cRCondidatePrinter = new CRCondidatePrinter();
                //CrystalReport1 cRCondidatePrinter = new CrystalReport1();

                cRCondidatePrinter.SetDataSource(CondidateDataset.Tables["condidate"]);
                CondidateViewer.ViewerCore.ReportSource = cRCondidatePrinter;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


        }




        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, (IntPtr)2, (IntPtr)0);
            //DragMove();
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }
    }
}
