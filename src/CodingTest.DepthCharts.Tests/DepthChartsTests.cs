using System;
using System.Collections.Generic;
using System.Text;
using CodingTest.DepthCharts.Models;
using FluentAssertions;
using Xunit;

namespace CodingTest.DepthCharts.Tests
{
    public class DepthChartsTests
    {
        public class AddPlayerToDepthChart
        {
            [Fact]
            public void AddPlayerToDepthChart_ForAGivenPosition()
            {
                // Arrange
                StringBuilder sb = new StringBuilder();
                sb.Append("QB: [50]");
                sb.Append(Environment.NewLine);
                sb.Append("WR: [90]");

                var expected = sb.ToString();

                var player1 = new Player()
                {
                    Name = "Player1",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 50
                };
                var player2 = new Player()
                {
                    Name = "Player2",
                    Position = Constants.NFLPositions.WR,
                    PlayerId = 90
                };

                var chart = new DepthChart(new List<string>
                {
                    Constants.NFLPositions.QB,
                    Constants.NFLPositions.WR
                });

                // Act
                chart.AddPlayerToDepthChart(player1, Constants.NFLPositions.QB, 0);
                chart.AddPlayerToDepthChart(player2, Constants.NFLPositions.WR, 0);

                var actual = chart.GetFullDepthChart();

                // Assert
                actual.Should().Be(expected);
            }

            [Fact]
            public void AddPlayerToDepthChart_NoPositionDepthProvided_AddToEndOfDepthChart()
            {
                // Arrange
                StringBuilder sb = new StringBuilder();
                sb.Append("QB: [1,50,90]");

                var expected = sb.ToString();

                var player1 = new Player()
                {
                    Name = "Player1",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 50
                };
                var player2 = new Player()
                {
                    Name = "Player2",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 90
                };
                var player3 = new Player()
                {
                    Name = "Player3",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 1
                };

                var chart = new DepthChart(new List<string>
                {
                    Constants.NFLPositions.QB
                });

                // Act
                chart.AddPlayerToDepthChart(player1, Constants.NFLPositions.QB, 1);
                chart.AddPlayerToDepthChart(player2, Constants.NFLPositions.QB);
                chart.AddPlayerToDepthChart(player3, Constants.NFLPositions.QB, 0);

                var actual = chart.GetFullDepthChart();

                // Assert
                actual.Should().Be(expected);
            }
            
            [Fact]
            public void AddPlayerToDepthChart_NegativePositionDepthProvided_AddToEndOfDepthChart()
            {
                // Arrange
                StringBuilder sb = new StringBuilder();
                sb.Append("QB: [50,90,1]");

                var expected = sb.ToString();

                var player1 = new Player()
                {
                    Name = "Player1",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 50
                };
                var player2 = new Player()
                {
                    Name = "Player2",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 90
                };
                var player3 = new Player()
                {
                    Name = "Player3",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 1
                };

                var chart = new DepthChart(new List<string>
                {
                    Constants.NFLPositions.QB
                });

                // Act
                chart.AddPlayerToDepthChart(player1, Constants.NFLPositions.QB, -1);
                chart.AddPlayerToDepthChart(player2, Constants.NFLPositions.QB);
                chart.AddPlayerToDepthChart(player3, Constants.NFLPositions.QB, -5);

                var actual = chart.GetFullDepthChart();

                // Assert
                actual.Should().Be(expected);
            }

            [Fact]
            public void AddPlayerToDepthChart_EnteringTwoPlayersIntoTheSameSlot_LastPlayerEnteredGetsPriority()
            {
                // Arrange
                StringBuilder sb = new StringBuilder();
                sb.Append("QB: [90,50]");

                var expected = sb.ToString();

                var player1 = new Player()
                {
                    Name = "Player1",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 50
                };
                var player2 = new Player()
                {
                    Name = "Player2",
                    Position = Constants.NFLPositions.QB,
                    PlayerId = 90
                };

                var chart = new DepthChart(new List<string>
                {
                    Constants.NFLPositions.QB
                });

                // Act
                chart.AddPlayerToDepthChart(player1, Constants.NFLPositions.QB, 0);
                chart.AddPlayerToDepthChart(player2, Constants.NFLPositions.QB, 0);

                var actual = chart.GetFullDepthChart();

                // Assert
                actual.Should().Be(expected);
            }
        }


        [Fact]
        public void RemovePlayerFromDepthChart()
        {
            // Arrange
            StringBuilder sb = new StringBuilder();
            sb.Append("QB: [50]");

            var expected = sb.ToString();

            var player1 = new Player()
            {
                Name = "Player1",
                Position = Constants.NFLPositions.QB,
                PlayerId = 50
            };
            var player2 = new Player()
            {
                Name = "Player2",
                Position = Constants.NFLPositions.WR,
                PlayerId = 90
            };

            var chart = new DepthChart(new List<string>
            {
                Constants.NFLPositions.QB,
                Constants.NFLPositions.WR
            });

            // Act
            chart.AddPlayerToDepthChart(player1, Constants.NFLPositions.QB, 0);
            chart.AddPlayerToDepthChart(player2, Constants.NFLPositions.WR, 0);
            chart.RemovePlayerFromDepthChart(player2, Constants.NFLPositions.WR);

            var actual = chart.GetFullDepthChart();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void GetFullDepthChart()
        {
            // Arrange
            StringBuilder sb = new StringBuilder();
            sb.Append("QB: [50]");
            sb.Append(Environment.NewLine);
            sb.Append("WR: [90]");

            var expected = sb.ToString();

            var player1 = new Player()
            {
                Name = "Player1",
                Position = Constants.NFLPositions.QB,
                PlayerId = 50
            };
            var player2 = new Player()
            {
                Name = "Player2",
                Position = Constants.NFLPositions.WR,
                PlayerId = 90
            };

            var chart = new DepthChart(new List<string>
            {
                Constants.NFLPositions.QB,
                Constants.NFLPositions.WR
            });

            // Act
            chart.AddPlayerToDepthChart(player1, Constants.NFLPositions.QB, 0);
            chart.AddPlayerToDepthChart(player2, Constants.NFLPositions.WR, 0);

            var actual = chart.GetFullDepthChart();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void GetPlayersUnderPlayerInDepthChart()
        {
            // Arrange
            StringBuilder sb = new StringBuilder();
            sb.Append("QB: [50,90]");

            var expected = sb.ToString();

            var player1 = new Player()
            {
                Name = "Player1",
                Position = Constants.NFLPositions.QB,
                PlayerId = 1
            };
            var player2 = new Player()
            {
                Name = "Player2",
                Position = Constants.NFLPositions.QB,
                PlayerId = 50
            };
            var player3 = new Player()
            {
                Name = "Player3",
                Position = Constants.NFLPositions.QB,
                PlayerId = 90
            };

            var chart = new DepthChart(new List<string>
            {
                Constants.NFLPositions.QB
            });

            // Act
            chart.AddPlayerToDepthChart(player1, Constants.NFLPositions.QB);
            chart.AddPlayerToDepthChart(player2, Constants.NFLPositions.QB);
            chart.AddPlayerToDepthChart(player3, Constants.NFLPositions.QB);

            var actual = chart.GetPlayersUnderPlayerInDepthChart(player1, Constants.NFLPositions.QB);

            // Assert
            actual.Should().Be(expected);
        }
    }
}