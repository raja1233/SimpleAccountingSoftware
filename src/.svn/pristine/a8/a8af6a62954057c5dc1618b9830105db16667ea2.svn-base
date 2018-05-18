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

namespace SDN.Product.View
{
    using Microsoft.Win32;
    using SDN.Product.ViewModel;
    using System.Data;
    using System.IO;
  

    //using System.Windows.Forms;

    /// <summary>
    /// Interaction logic for PandSDetailsView.xaml
    /// </summary>
    public partial class PandSDetailsView : UserControl
    {
        private PAndSDetailsViewModel pandsViewModel;

        #region "Constructors"
        public PandSDetailsView()
        {
            InitializeComponent();
            pandsViewModel= new PAndSDetailsViewModel();
            this.DataContext = pandsViewModel;
        }
        #endregion

        #region "Events"
        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {// open file dialog
                System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
                // image filters
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp,*.png)|*.jpg; *.jpeg; *.gif; *.bmp;*.png";

                foreach (var img in FindVisualChildren<Image>(this))
                {
                    if (img.Name == "imgPicture")
                    {
                        
                        if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {

                            FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);

                            byte[] photo_aray = new byte[fs.Length];

                            fs.Read(photo_aray, 0, Convert.ToInt32(fs.Length));
                            fs.Close();

                            if (photo_aray != null)
                            {
                                pandsViewModel.SetPandSPicture(photo_aray);
                            }
                            
                        }
                      
                    }
                }
                // display image in picture box


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Image loading error....");
            }
        }
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;

                }
            }
        }

        private void DecimalTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtPSCode.Focus();
        }


        #endregion

       
    }
}
