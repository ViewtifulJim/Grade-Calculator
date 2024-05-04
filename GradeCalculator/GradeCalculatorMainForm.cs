using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeCalculator
{
    public partial class GradeCalculator : Form
    {
        public GradeCalculator()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Attach key press event to percent and weight text boxes to only allow numbers and one decimal point.
            AttachKeyPressEventToTextBoxes(txtBoxPercent1, txtBoxPercent2, txtBoxPercent3, txtBoxPercent4, txtBoxPercent5, txtBoxPercent6, txtBoxPercent7, txtBoxPercent8, txtBoxPercent9, txtBoxPercent10);
            AttachKeyPressEventToTextBoxes(txtBoxWeight1, txtBoxWeight2, txtBoxWeight3, txtBoxWeight4, txtBoxWeight5, txtBoxWeight6, txtBoxWeight7, txtBoxWeight8, txtBoxWeight9, txtBoxWeight10);
        }

        // Attach key press event to text boxes (percent and weight) to only allow numbers and one decimal point.
        private void AttachKeyPressEventToTextBoxes(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.KeyPress += TextBox_KeyPress;
            }
        }

        // Clear all text boxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam1.Text = "";
            txtBoxAssignmentExam2.Text = "";
            txtBoxAssignmentExam3.Text = "";
            txtBoxAssignmentExam4.Text = "";
            txtBoxAssignmentExam5.Text = "";
            txtBoxAssignmentExam6.Text = "";
            txtBoxAssignmentExam7.Text = "";
            txtBoxAssignmentExam8.Text = "";
            txtBoxAssignmentExam9.Text = "";
            txtBoxAssignmentExam10.Text = "";
            txtBoxPercent1.Text = "";
            txtBoxPercent2.Text = "";
            txtBoxPercent3.Text = "";
            txtBoxPercent4.Text = "";
            txtBoxPercent5.Text = "";
            txtBoxPercent6.Text = "";
            txtBoxPercent7.Text = "";
            txtBoxPercent8.Text = "";
            txtBoxPercent9.Text = "";
            txtBoxPercent10.Text = "";
            txtBoxWeight1.Text = "";
            txtBoxWeight2.Text = "";
            txtBoxWeight3.Text = "";
            txtBoxWeight4.Text = "";
            txtBoxWeight5.Text = "";
            txtBoxWeight6.Text = "";
            txtBoxWeight7.Text = "";
            txtBoxWeight8.Text = "";
            txtBoxWeight9.Text = "";
            txtBoxWeight10.Text = "";
            txtBoxAverageGradePercentage.Text = "";  
            txtBoxAverageGradeAlpha.Text = "";
            txtBoxAverageClassification.Text = "";
        }

        // reset the form
        private void btnReset_Click(object sender, EventArgs e)
        {
            GradeCalculator gradeCalculator = new GradeCalculator();
            gradeCalculator.Show();
            this.Hide();
        }

        // print the form to a file
        private void btnPrint_Click(object sender, EventArgs e)
        {

            
            System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();

            
            document.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(document_PrintPage);

            
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = document;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }

        // Function to screenshot the form
        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        // Get the grades from the text boxes
        public double[] GetGrades()
        {
            double[] grades = new double[10];
            double tempGrade;

            if (double.TryParse(txtBoxPercent1.Text, out tempGrade))
                grades[0] = tempGrade;

            if (double.TryParse(txtBoxPercent2.Text, out tempGrade))
                grades[1] = tempGrade;

            if (double.TryParse(txtBoxPercent3.Text, out tempGrade))
                grades[2] = tempGrade;

            if (double.TryParse(txtBoxPercent4.Text, out tempGrade))
                grades[3] = tempGrade;

            if (double.TryParse(txtBoxPercent5.Text, out tempGrade))
                grades[4] = tempGrade;

            if (double.TryParse(txtBoxPercent6.Text, out tempGrade))
                grades[5] = tempGrade;

            if (double.TryParse(txtBoxPercent7.Text, out tempGrade))
                grades[6] = tempGrade;

            if (double.TryParse(txtBoxPercent8.Text, out tempGrade))
                grades[7] = tempGrade;

            if (double.TryParse(txtBoxPercent9.Text, out tempGrade))
                grades[8] = tempGrade;

            if (double.TryParse(txtBoxPercent10.Text, out tempGrade))
                grades[9] = tempGrade;

            return grades;
        }

        // Get the weights from the text boxes
        public double[] GetWeights()
        {
            double[] weights = new double[10];
            double tempWeight;

            if (double.TryParse(txtBoxWeight1.Text, out tempWeight))
                weights[0] = tempWeight;

            if (double.TryParse(txtBoxWeight2.Text, out tempWeight))
                weights[1] = tempWeight;

            if (double.TryParse(txtBoxWeight3.Text, out tempWeight))
                weights[2] = tempWeight;

            if (double.TryParse(txtBoxWeight4.Text, out tempWeight))
                weights[3] = tempWeight;

            if (double.TryParse(txtBoxWeight5.Text, out tempWeight))
                weights[4] = tempWeight;

            if (double.TryParse(txtBoxWeight6.Text, out tempWeight))
                weights[5] = tempWeight;

            if (double.TryParse(txtBoxWeight7.Text, out tempWeight))
                weights[6] = tempWeight;

            if (double.TryParse(txtBoxWeight8.Text, out tempWeight))
                weights[7] = tempWeight;

            if (double.TryParse(txtBoxWeight9.Text, out tempWeight))
                weights[8] = tempWeight;

            if (double.TryParse(txtBoxWeight10.Text, out tempWeight))
                weights[9] = tempWeight;

            return weights;
        }

        // Calculate the avergage grade from the grades and weights
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double averageGrade = calculateAverageGrade();

            if (averageGrade == 0)
            {
                return;
            }

            txtBoxAverageGradePercentage.Text = averageGrade.ToString("F2") + "%";
            txtBoxAverageGradeAlpha.Text = GetLetterGrade(averageGrade);
            txtBoxAverageClassification.Text = GetClassifications(averageGrade);
            valid();
        }

        // Calculate the average/overall grade
        public double calculateAverageGrade()
        {
            double[] grades = GetGrades();
            double[] weights = GetWeights();


            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 0 || grades[i] > 100)
                {
                    MessageBox.Show("Grades must be between 0 and 100");
                    error("Error.");
                    
                    return 0;
                }

                if (weights[i] < 0 || weights[i] > 100)
                {
                    MessageBox.Show("Weights must be between 0 and 100");
                    error("Error.");
                    return 0;
                }
            }

            double weightedSum = 0.00;

            for (int i = 0; i < 10; i++)
            {
                weightedSum += grades[i] * weights[i];
            }

            double sumOfWeights = weights.Sum();

            if (sumOfWeights > 100)
            {
                MessageBox.Show("Sum of weights must be less than or equal to 100");
                error("Error.");
                return 0;
            }

            double averageGrade = weightedSum / sumOfWeights;

            return averageGrade;
        }

        // Get the letter grade based on the percentage
        public string GetLetterGrade(double percentage)
        { 

            if (percentage >= 97)
                return "A+";
            else if (percentage >= 93)
                return "A";
            else if (percentage >= 90)
                return "A-";
            else if (percentage >= 87)
                return "B+";
            else if (percentage >= 83)
                return "B";
            else if (percentage >= 80)
                return "B-";
            else if (percentage >= 77)
                return "C+";
            else if (percentage >= 73)
                return "C";
            else if (percentage >= 70)
                return "C-";
            else if (percentage >= 67)
                return "D+";
            else if (percentage >= 63)
                return "D";
            else if (percentage >= 60)
                return "D-";
            else
                return "F";
        }

        // UK University Classifications 
        public string GetClassifications(double percentage)
        {
            if (percentage >= 70)
                return "1st";
            else if (percentage >= 60)
                return "2:1";
            else if (percentage >= 50)
                return "2:2";
            else if (percentage >= 40)
                return "3rd";
            else
                return "Fail";
        }

        // Error message
        void error(string message)
        {
            txtBoxAverageGradePercentage.Text = message;
            txtBoxAverageGradeAlpha.Text = message;
            txtBoxAverageClassification.Text = message;
            txtBoxAverageGradePercentage.ForeColor = Color.Red;
            txtBoxAverageGradeAlpha.ForeColor = Color.Red;
            txtBoxAverageClassification.ForeColor = Color.Red;
        }

        // Valid message
        void valid()
        {
            txtBoxAverageGradePercentage.ForeColor = Color.Black;
            txtBoxAverageGradeAlpha.ForeColor = Color.Black;
            txtBoxAverageClassification.ForeColor = Color.Black;
        }

        // Clear rows
        private void btnClearRow1_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam1.Text = "";
            txtBoxPercent1.Text = "";
            txtBoxWeight1.Text = "";
        }

        private void btnClearRow2_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam2.Text = "";
            txtBoxPercent2.Text = "";
            txtBoxWeight2.Text = "";
        }

        private void btnClearRow3_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam3.Text = "";
            txtBoxPercent3.Text = "";
            txtBoxWeight3.Text = "";
        }

        private void btnClearRow4_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam4.Text = "";
            txtBoxPercent4.Text = "";
            txtBoxWeight4.Text = "";
        }

        private void btnClearRow5_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam5.Text = "";
            txtBoxPercent5.Text = "";
            txtBoxWeight5.Text = "";
        }

        private void btnClearRow6_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam6.Text = "";
            txtBoxPercent6.Text = "";
            txtBoxWeight6.Text = "";
        }

        private void btnClearRow7_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam7.Text = "";
            txtBoxPercent7.Text = "";
            txtBoxWeight7.Text = "";
        }

        private void btnClearRow8_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam8.Text = "";
            txtBoxPercent8.Text = "";
            txtBoxWeight8.Text = "";
        }

        private void btnClearRow9_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam9.Text = "";
            txtBoxPercent9.Text = "";
            txtBoxWeight9.Text = "";
        }

        private void btnClearRow10_Click(object sender, EventArgs e)
        {
            txtBoxAssignmentExam10.Text = "";
            txtBoxPercent10.Text = "";
            txtBoxWeight10.Text = "";
        }

        // Add a new module - loads ModuleNameForm.cs form to get the module name from the user then adds it to the list of modules in the datagridview
        private void btnAddModule_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBoxAverageGradePercentage.Text) && string.IsNullOrEmpty(txtBoxAverageGradeAlpha.Text) && string.IsNullOrEmpty(txtBoxAverageClassification.Text))
            {
                MessageBox.Show("Please calculate before adding a new module.");
                return;
            }

            using (ModuleNameForm moduleNameForm = new ModuleNameForm())
            {

                DialogResult result = moduleNameForm.ShowDialog();


                if (result == DialogResult.OK)
                {
                    string markerName = moduleNameForm.ModuleName;

                    // Add the module name to the list of modules in the datagridview, Name, Percentage, Grade, Classification.
                    if (!string.IsNullOrEmpty(markerName))
                    {

                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                        row.Cells[0].Value = markerName;
                        row.Cells[1].Value = txtBoxAverageGradePercentage.Text;
                        row.Cells[2].Value = txtBoxAverageGradeAlpha.Text;
                        row.Cells[3].Value = txtBoxAverageClassification.Text;
                        dataGridView1.Rows.Add(row);
                        
                    }
                    else
                    {
                        MessageBox.Show("No module added.");
                    }
                }
            }

        }

        // Close the application if the form is closed
        private void GradeCalculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Save everything in the datagridview to a csv file
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save CSV File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] array = new string[dataGridView1.Columns.Count];
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                array[i] = row.Cells[i].Value.ToString();
                            }
                            string line = string.Join(",", array);
                            writer.WriteLine(line);
                        }
                    }
                }
                MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // MessageBox with information about the application showing the user how to use it and how grades are calculated
        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application allows you to calculate your average grade based on the grades and weights of your assignments and exams.\n\n" +
                            "To use the application, enter the grades and weights of your assignments and exams in the text boxes provided. Then click the 'Calculate' button to calculate your average grade.\n\n" +
                            "The application will then display your average grade as a percentage, letter grade and classification.\n\n" +
                            "You can also add your module name to the list of modules in the datagridview by clicking the 'Add Module' button.\n\n" +
                            "You can save the list of modules to a CSV file by clicking the 'Save to File' button.\n\n" +
                            "You can also print the form to a file by clicking the 'Print' button.\n\n" +
                            "To clear the form, click the 'Clear' button. To reset the form, click the 'Reset' button.\n\n" +
                            "To clear a row, click the 'Clear Row' button next to the row you want to clear.\n\n" +
                            "To close the application, click the 'X' button or the 'Exit' button.\n\n" +
                            "Enjoy using the application!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Close the application when the Exit button is clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Opens system mailing application with the email address, subject and body filled in
        private void btnReport_Click(object sender, EventArgs e)
        {
            string devEmail = "jamescolinwilliams@outlook.com",
                    subject = "Grade Calculator Issue",
                    message = "<Please describe the issue>";

            string mailToURI = $"mailto:{devEmail}?subject={Uri.EscapeUriString(subject)}&body={Uri.EscapeUriString(message)}";

            DialogResult userChoice = MessageBox.Show("Would you like to report an issue?", "Report", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (userChoice == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(mailToURI) { UseShellExecute = true });
            }

        }

        // Used in conjunction with the TextBox_KeyPress method to only allow numbers and one decimal point in the text boxes
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!IsValidKeyPress(textBox, e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Only allow numbers and one decimal point in the text boxes
        private bool IsValidKeyPress(TextBox textBox, char keyPressed)
        {
            if (!char.IsControl(keyPressed) && !char.IsDigit(keyPressed) && keyPressed != '.')
            {
                return false;
            }

            // only allow one decimal point
            if (keyPressed == '.' && textBox.Text.IndexOf('.') > -1)
            {
                return false;
            }

            return true;
        }

    }
}
