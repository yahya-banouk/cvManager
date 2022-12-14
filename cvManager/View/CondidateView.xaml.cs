using cvManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace cvManager.View
{
    /// <summary>
    /// Logique d'interaction pour CondidateView.xaml
    /// </summary>
    public partial class CondidateView : UserControl
    {
        public CondidateView()
        {
            InitializeComponent();
            this.DataContext = new CondidateViewModel();
            
        }
        

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CondidateCRViewerView x = new CondidateCRViewerView(searchString.Text);
                x.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }
    }
}
