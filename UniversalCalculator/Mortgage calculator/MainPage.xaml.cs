using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mortgage_calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		private void Calculate_Click(object sender, RoutedEventArgs e)
		{
			// Parse input values
			decimal principal = decimal.Parse(txtPrincipal.Text);
			int years = int.Parse(txtYears.Text);
			int months = int.Parse(txtMonths.Text);
			decimal yearlyInterestRate = decimal.Parse(txtYearlyInterestRate.Text);

			// Calculate monthly repayment
			decimal monthlyRepayment = CalculateMonthlyRepayment(principal, years, months, yearlyInterestRate);

			// Display the result
			txtMonthlyRepayment.Text = monthlyRepayment.ToString("C");
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Exit();
		}

		private decimal CalculateMonthlyRepayment(decimal principal, int years, int months, decimal yearlyInterestRate)
		{
			// Calculate monthly interest rate
			decimal monthlyInterestRate = yearlyInterestRate / 12;

			// Calculate total number of months
			int totalMonths = years * 12 + months;

			// Calculate monthly repayment
			decimal i = monthlyInterestRate / 100;
			decimal M = principal * (i * (decimal)Math.Pow(1 + (double)i, totalMonths)) / ((decimal)Math.Pow(1 + (double)i, totalMonths) - 1);

			return M;
		}
	}
}

