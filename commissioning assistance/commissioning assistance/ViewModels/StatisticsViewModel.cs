using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Windows.Media;

namespace commissioning_assistance.ViewModels
{
    public class StatisticsViewModel : Screen
    {
		private SeriesCollection _MySeries;
		public Func<double, string> Formatter { get; set; }

		public SeriesCollection MySeries
		{
			get { return _MySeries; }
			set 
			{ 
				_MySeries = value;
				NotifyOfPropertyChange(() => MySeries);
			}
		}

		public ChartValues<float> Values { get; private set; }

		public StatisticsViewModel()
		{
			ChartSetUp();
		}

		private void ChartSetUp()
		{
			//Days
			var dayConfig = Mappers.Xy<DateModel>()
			  .X(dateModel => dateModel.DateTime.Ticks / TimeSpan.FromDays(1).Ticks)
			  .Y(dateModel => dateModel.Value);
			//and the formatter
			Formatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("d");


			MySeries = new SeriesCollection(dayConfig)
			{
				new LineSeries
				{
					Values = new ChartValues<DateModel>
					{
						new DateModel
						{
							DateTime = DateTime.Now,
							Value = 5
						},
						new DateModel
						{
							DateTime = DateTime.Now.AddDays(2),
							Value = 9
						},
						new DateModel
						{
							DateTime = DateTime.Now.AddDays(6),
							Value = 3
						}
					},
					Fill = Brushes.Transparent
				}
			};
		}

	}

	public class DateModel
	{
		public DateTime DateTime { get; set; }
		public double Value { get; set; }
	}
}
