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
using System.Windows.Shapes;

namespace WorkIt.View
{
    /// <summary>
    /// Interaction logic for EditClass.xaml
    /// </summary>
    public partial class EditClass : Window
    {
        public EditClass()
        {
            InitializeComponent();
            Cancel = true;

        }
        private string m_Name;
        public string M_Name { get { return m_Name; } set { m_Name = value; } }

        private string m_days;
        public string Days { get { return m_days; } set { m_days = value; } }

        private string m_h;
        public string Hours { get { return m_h; } set { m_h = value; } }

        private string m_EID;
        public string Eid { get { return m_EID; } set { m_EID = value; } }

        private string m_room;
        public string Room { get { return m_room; } set { m_room = value; } }

        private bool m_cancel = false;
        public bool Cancel { get { return m_cancel; } set { m_cancel = value; } }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            int mroom;
            int eid;
            if (int.TryParse(txtbx_numroom.Text, out mroom) && mroom > 0 && int.TryParse(txtbx_em.Text, out eid) && eid>0 ) {

                if (txtbx_Name.Text != null)
                {
                    Cancel = false;
                    M_Name = txtbx_Name.Text;
                    Days = txtbx_days.ToString();
                    Hours = txtbx_H.ToString();
                    Eid = txtbx_em.ToString();
                    Room = txtbx_numroom.ToString();

                    MessageBox.Show("Emails were sent to the following customers");
                }
                else
                {
                    Cancel = true;
                    MessageBox.Show("Error: Please enter Class Name");
                }

            }
            else
            {
                Cancel = true;
                MessageBox.Show("Error: Error input. Please Validate Room and Employee ID are correct");
            }
            this.Close();

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Cancel = true;
            this.Close();
        }
    }
}
