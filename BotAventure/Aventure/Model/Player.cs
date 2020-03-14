using System;
using System.Collections.Generic;
using System.Text;

namespace Aventure.Model
{
    public class Player
    {
        public Player(string name, string firstname, string description, string weapon, int age)
        {
            Name = name;
            FirstName = firstname;
            Age = age;
            Weapon = weapon;
            Description = description;
        }

        public Player(string firstname)
        {
            FirstName = firstname;
        }


        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Weapon { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            string rep = "Personnage : \n";
            rep +="Prénom : "+ this.FirstName??"Pas de prénom" + "\n";
            rep += "Nom : "+this.Name ?? "Pas de bom" + "\n";
            rep += "Age : "+this.Age ?? "Pas d'age" + "\n";
            rep += "Arme : "+this.Weapon ?? "Pas d'arme" + "\n";
            rep += "Description : "+this.Description ?? "Pas de description" + "\n";
            return rep;
        }
    }
}
