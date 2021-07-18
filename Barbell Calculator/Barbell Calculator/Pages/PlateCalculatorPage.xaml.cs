using Barbell_Calculator.Data;
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
        }

        /// <summary>
        /// Reset the entry field when focusing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClearText(object sender, EventArgs e)
        {
            BarbellWeightInputEntry.Text = string.Empty;
        }

        /// <summary>
        /// Recalculate and update label with new plate calculations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnInputWeightChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(BarbellWeightInputEntry.Text, out double inputWeight))
            {
                inputWeight = StandardWeights.BarWeight;
            };

            PlateOutputText.Text = CalculatePlates(inputWeight);
        }

        /// <summary>
        /// Calculate the number of plates needed to add up to a given weight
        /// </summary>
        /// <param name="inputWeight"></param>
        /// <returns>String formatted to list number of plates needed per plate weight</returns>
        private string CalculatePlates(double inputWeight = 0, bool isLbs = true)
        {
            double[] usedPlates;

            // Subtract bar weight and then divide by 2 to calculate plates needed for a single side
            if (isLbs)
            {
                // 45, 35, 25, 10, 5
                usedPlates = new double[6] { 45, 35, 25, 10, 5, 2.5 };
                inputWeight -= StandardWeights.BarWeight;
            } else
            {
                // 25, 20, 15, 10
                usedPlates = new double[4] { 25, 20, 15, 10 };
                inputWeight -= StandardWeights.BarWeight / StandardWeights.KgToLbRatio;
            }
            inputWeight /= 2;

            // Array to store the plate counts in decreasing order
            int[] plateSum = new int[usedPlates.Length];

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