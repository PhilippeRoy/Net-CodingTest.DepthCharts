using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.DepthCharts.Models
{
    public class DepthChart
    {
        private readonly Dictionary<string, List<Player>> _chart;

        public DepthChart(List<string> positions)
        {
            _chart = new Dictionary<string, List<Player>>();

            foreach (var position in positions)
            {
                _chart.Add(position, new List<Player>());
            }
        }

        public void AddPlayerToDepthChart(Player player, string position, int? positionDepth = null)
        {
            if (_chart.TryGetValue(position, out List<Player> values))
            {
                if (ValidatePositionDepth(positionDepth, values))
                {
                    // Adds a player to a depth chart for a given position (at a specific spot).
                    values.Insert((int) positionDepth, player);
                }
                else
                {
                    // If no position_depth is provided, then add them to the end of the depth chart for that position.
                    values.Add(player);
                }
            }
        }

        public void RemovePlayerFromDepthChart(Player player, string position)
        {
            if (_chart.TryGetValue(position, out List<Player> values))
            {
                values.Remove(player);
            }
        }

        public string GetFullDepthChart()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var position in _chart)
            {
                // Skip if no values available for position 
                if (!position.Value.Any())
                {
                    continue;
                }

                // Return string of comma seperated playerIds
                var playerIds = string.Join(",", position.Value.Select(x => x.PlayerId));

                sb.Append($"{position.Key}: [{playerIds}]");
                sb.Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }

        public string GetPlayersUnderPlayerInDepthChart(Player player, string position)
        {
            StringBuilder sb = new StringBuilder();

            if (_chart.TryGetValue(position, out List<Player> values))
            {
                var index = values.IndexOf(player);
                var playerIds = string.Join(",", values.Skip(index + 1).Select(x => x.PlayerId));

                sb.Append($"{position}: [{playerIds}]");
            }

            return sb.ToString().Trim();
        }

        private bool ValidatePositionDepth(int? positionDepth, List<Player> values)
        {
            return positionDepth != null
                   && positionDepth <= values.Count - 1
                   && positionDepth >= 0;
        }
    }
}