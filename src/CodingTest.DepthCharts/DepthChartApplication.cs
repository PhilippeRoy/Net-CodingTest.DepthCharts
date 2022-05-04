using System;
using System.Collections.Generic;
using CodingTest.DepthCharts.Models;
using CodingTest.DepthCharts.Services.Interfaces;

namespace CodingTest.DepthCharts
{
    public class DepthChartApplication
    {
        private readonly IConsoleService _console;

        public DepthChartApplication(IConsoleService console)
        {
            _console = console;
        }

        public void Run()
        {
            var nflDepthChart = new DepthChart(new List<string>
            {
                Constants.NFLPositions.QB,
                Constants.NFLPositions.WR,
                Constants.NFLPositions.RB,
                Constants.NFLPositions.TE,
                Constants.NFLPositions.K,
                Constants.NFLPositions.P,
                Constants.NFLPositions.KR,
                Constants.NFLPositions.PR,
            });

            var bob = new Player()
            {
                Name = "Bob",
                Position = Constants.NFLPositions.QB,
                PlayerId = 1
            };
            var alice = new Player()
            {
                Name = "Alice",
                Position = Constants.NFLPositions.QB,
                PlayerId = 2
            };
            var charlie = new Player()
            {
                Name = "Charlie",
                Position = Constants.NFLPositions.QB,
                PlayerId = 3
            };

            nflDepthChart.AddPlayerToDepthChart(bob, Constants.NFLPositions.WR, 0);
            nflDepthChart.AddPlayerToDepthChart(alice, Constants.NFLPositions.WR, 0);
            nflDepthChart.AddPlayerToDepthChart(charlie, Constants.NFLPositions.WR, 2);
            nflDepthChart.AddPlayerToDepthChart(bob, Constants.NFLPositions.KR);


            _console.WriteLine(string.Empty);
            _console.WriteLine("*** Game on! ***");
            _console.WriteLine(string.Empty);

            _console.WriteLine("Full depth chart");
            _console.WriteLine(nflDepthChart.GetFullDepthChart());

            _console.WriteLine(string.Empty);

            _console.WriteLine($"Players under {alice.Name} in depth chart");
            _console.WriteLine(nflDepthChart.GetPlayersUnderPlayerInDepthChart(alice, Constants.NFLPositions.WR));

            _console.WriteLine(string.Empty);
            _console.WriteLine("*** Game over! ***");
            _console.WriteLine(string.Empty);


        }
    }
}