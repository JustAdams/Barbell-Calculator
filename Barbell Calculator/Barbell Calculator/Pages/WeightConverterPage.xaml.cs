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
    public partial class WeightConverterPage : ContentPage
    {
        public WeightConverterPage()
        {
            InitializeComponent();
        }

        public void OnUpdateWeight(object sender, EventArgs e)
        {

        }
    }
}