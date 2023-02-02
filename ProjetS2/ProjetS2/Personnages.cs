using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetS2
{
    public class Personnages
    {
        private int Health;
        private string Name;
        private int Speed;

        public Personnages(int health, string name, int speed)
        {
            Health = health;
            Name = name;
            Speed = speed;
        }
    }
}
