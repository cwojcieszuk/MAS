using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP1
{
    public class Player
    {
        private string _name;
        private DateTime _dateOfBirth;
        private string? _gender = String.Empty;

        public Player(string name, DateTime dateOfBirth, string? gender = null)
        {
            _name = name;
            _dateOfBirth = dateOfBirth;
            _gender = gender;

            addPlayer(this);
        }

        private static List<Player> players = new List<Player>();

        private string getPlayerData()
        {
            return $"Player: {this._name} date of birth: {this._dateOfBirth} {(_gender == null ? "" : $"gender: {this._gender}")}";
        }

        private static void addPlayer(Player player)
        {
            players.Add(player);
        }

        private static void removeGracz(Player player)
        {
            players.Remove(player);
        }

        public static void showExtent()
        {
            Console.WriteLine($"Extent of the class: {typeof(Player).Name} \n");

            foreach(Player player in players)
            {
                Console.WriteLine(player.getPlayerData());
            } 
        }
    }
}
