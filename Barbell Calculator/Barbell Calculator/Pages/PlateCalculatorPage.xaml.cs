using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Barbell_Calculator.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlateCalculatorPage : ContentPage
    {
        public PlateCalculatorPage()
        {
            InitializeComponent();
            PlateOutputText.Text = CalculatePlates();
        }

        public void ClearText(object sender, EventArgs e)
        {
            BarbellWeightInputEntry.Text = string.Empty;
        }

        public void OnInputWeightChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(BarbellWeightInputEntry.Text, out double inputWeight))
            {
                inputWeight = 45;
            };

            string result = CalculatePlates(inputWeight);
            PlateOutputText.Text = result;
        }

        private string CalculatePlates(double inputWeight = 0)
        {
            // 45, 35, 25, 10, 5
            double[] usedPlates = new double[6] { 45, 35, 25, 10, 5, 2.5 };
            int[] plateSum = new int[6] { 0, 0, 0, 0, 0, 0 };

            // Reduce by 45 to eliminate barbell, divide by 2 to calculate plates for a single side
            inputWeight -= 45;
            inputWeight /= 2;

            StringBuilder sb = new StringBuilder("Plates");
            int currPlate = 0;

            foreach (double plate in usedPlates)
            {
                while (inputWeight >= plate)
                {
                    plateSum[currPlate]++;
                    inputWeight -= plate;
                }
                sb.Append($"\n{plate}: {plateSum[currPlate]}");
                currPlate++;
            }

            return sb.ToString();
        }
    }
}