using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard
{
    internal class BoardColumn
    {
        public string Name { get;}
        private List<Objective> _objectives;

        public BoardColumn(string name)
        {
            Name = name;
            _objectives = new List<Objective>();
        }

        public int GetAmountObjectives()
        {
            return _objectives.Count;
        }

        public void AddObjective(string name, string description, PriorytyType prioryty)
        {
           _objectives.Add(new Objective(name, description, prioryty));
        }

        public Objective GetObjective(string name)
        {
            return _objectives.Find(Obj => Obj.Name == name);
        }
                

        public void RemoveObjective(string name)
        {
            _objectives.RemoveAt(_objectives.IndexOf(_objectives.Find(Obj => Obj.Name == name)));
        }

        public void ShowObjectives()
        {
            foreach (Objective obj in _objectives)
            {
                Console.WriteLine("  ", obj.Name);
                Console.WriteLine("  ", obj.Description);
                Console.WriteLine("  ", obj.Priority);
                Console.WriteLine();
            }
        }

        
    }
}
