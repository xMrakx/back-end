using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScrumBoard
{
    internal class Board
    {
        private const int _columnLimit = 10;
        public string BoardName { get; }
        private List<BoardColumn> _columns;

        public Board(string name)
        {
            BoardName = name;
            _columns = new List<BoardColumn>();
        }
        
        public void AddColumn(string name)
        {
            if(_columns.Count < _columnLimit)
            {
                _columns.Add(new BoardColumn(name));
            }
            else
            {
                Console.WriteLine("Amount columns cant be more than 10");
            }
        }

        public void AddObjective(string name, string description, PriorytyType prioryty)
        {
            _columns[0].AddObjective(name, description, prioryty);
        }

        public void MoveObjective(string nameColumn, string nameObjective, string targetColumn)
        {
            Objective Obj = _columns.Find(Col => Col.Name == nameColumn).GetObjective(nameObjective);
            _columns.Find(Col => Col.Name == nameColumn).RemoveObjective(nameObjective);
            _columns.Find(Col => Col.Name == targetColumn).AddObjective(Obj.Name, Obj.Description, Obj.Priority);
        }

        public void ShowBoard()
        {
            foreach(BoardColumn col in _columns)
            {
                Console.WriteLine(col.Name, ":");
                col.ShowObjectives();
            }
        }

    }
}
