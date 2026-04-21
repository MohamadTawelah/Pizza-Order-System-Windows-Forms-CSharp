using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class frmPizzaOrder : Form
    {
        int TotalPrice = 0;
        public frmPizzaOrder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
            this.BackColor = Color.FromArgb(253, 242, 233);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTakeOut.Checked)
            {
                lblWheretoEat.Text = rbTakeOut.Text;
            }
        }

        void UpdateOrderSummary()
        {
            UpdateCrust();
            UpdateSize();
            UpdateToppings();
            UpdateTotalPrice();
            UpdateWhereToEat();
        }

        float CalculateToppingsPrice()
        {
            float ToppingsTotalPrice = 0;

            if (chkExtraChesse.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkExtraChesse.Tag);

            if (chkOnions.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkOnions.Tag);

            if (chkMushrooms.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);

            if (chkOlives.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);

            if (chkTomatoes.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);

            if (chkGreenPeperres.Checked)
                ToppingsTotalPrice += Convert.ToSingle(  chkGreenPeperres.Tag);

           return ToppingsTotalPrice;
        }

        float GetSelectedSizePrice()
        {
            if(rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);

            else if (rbMedium.Checked) return Convert.ToSingle(rbMedium.Tag);

            else
                return Convert.ToSingle(rbLarge.Tag);

            return 0;
        }

        float GetSelectedCrustPrice()
        {
            if (rbThinCrust.Checked)
            {
                return Convert.ToSingle(rbThinCrust.Tag);
            }
            else
            {
                return Convert.ToSingle(rbThikCrust.Tag);
            }
        }

        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalculateToppingsPrice() + GetSelectedCrustPrice();
        }
        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$ " + CalculateTotalPrice().ToString();

        }

        void UpdateSize()
        {

            UpdateTotalPrice();
            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;

            }
            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;

            }
            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;

            }
        }

        void UpdateWhereToEat()
        {
            UpdateTotalPrice();
            if (rbEatIn.Checked)
                lblWheretoEat.Text = rbEatIn.Text;
            else if (rbTakeOut.Checked)
                lblWheretoEat.Text = rbTakeOut.Text;
        }

        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThinCrust.Checked)
            {
                lblCrustType.Text = "Thin Crust";
            }
            else if (rbThikCrust.Checked)
            {
                lblCrustType.Text = "Thick Crust";
            }
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";

            if (chkExtraChesse.Checked)
            {
                sToppings = "Extra Cheese";
            }

            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }

            if (chkOnions.Checked)
            {
                sToppings += "\n, Onions";
            }
            if (chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }

            if (chkGreenPeperres.Checked)
            {
                sToppings += "\n, GreenPeperres";
            }
            if (chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }
            if (sToppings.StartsWith(","))
            {
                sToppings=sToppings.Substring(1, sToppings.Length - 1).Trim();
            }

            if (sToppings == "")
            {
                sToppings = "No Toppings";
            }
            lblToppings.Text = sToppings;
        }

        void ResetForm()
        {

            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbCrustType.Enabled = true;

            rbMedium.Enabled = true;

            chkExtraChesse.Checked = false;
            chkOnions.Checked = false;
            chkOlives.Checked = false;
            chkMushrooms.Checked = false;
            chkTomatoes.Checked = false;
            chkGreenPeperres.Checked = false;

            rbThinCrust.Checked = true;

            rbEatIn.Checked = true;

            btnOrderPizza.Enabled = true;   

        }

        private void rdSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();


        }

        private void rdMedium_CheckedChanged(object sender, EventArgs e)
        {

            UpdateSize();


        }

        private void rdLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();


        }

  

        private void chkExtraChesse_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnions_CheckedChanged(object sender, EventArgs e)
        {

            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {

            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {

            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeperres_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rdThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();


        }

        private void rdThikCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rdEatIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEatIn.Checked)
            {
                lblWheretoEat.Text = rbEatIn.Text;
            }
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            var Result=MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(Result == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Succefully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                gbCrustType.Enabled=false;
                gbSize.Enabled=false;
                gbToppings.Enabled=false;
                gbWhereToEat.Enabled=false;
                btnOrderPizza.Enabled=false;

            }
        }

        private void lbTotalPrice_Click(object sender, EventArgs e)
        {
        }

        private void gbOrderSummery_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void gbSize_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 248, 240);

        }
    }
}
