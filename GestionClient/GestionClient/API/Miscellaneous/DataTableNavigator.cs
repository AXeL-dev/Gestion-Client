using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GestionClient
{
    class DataTableNavigator
    {
        private int _position;

        public DataTable Table { get; private set; }
        public DataRow Current { get; private set; }
        public int Count { get { return Table.Rows.Count; } }
        public int FirstPosition { get { return 0; } }
        public int LastPosition { get { return Table.Rows.Count - 1; } }
        public bool Loop { get; set; }
        public int Position
        {
            get { return _position; }
            set { Move(value); }
        }

        public DataTableNavigator(DataTable dataTable, bool loop = true)
        {
            this.Table = dataTable;
            this.Loop = loop;
            Move(FirstPosition);
        }

        public bool HasCurrent(string columnName, object columnValue)
        {
            return (Current[columnName].ToString().ToLower() == columnValue.ToString().ToLower());
        }

        public void Move(int position)
        {
            if (Count > 0)
            {
                if (position < FirstPosition)
                {
                    _position = Loop ? LastPosition : FirstPosition;
                }
                else if (position > LastPosition)
                {
                    _position = Loop ? FirstPosition : LastPosition;
                }
                else
                {
                    _position = position;
                }
                this.Current = Table.Rows[_position];
            }
            else
            {
                _position = -1;
                this.Current = null;
            }
        }

        public void MoveFirst()
        {
            Move(FirstPosition);
        }

        public void MoveLast()
        {
            Move(LastPosition);
        }

        public void MoveNext()
        {
            Move(++_position);
        }

        public void MovePrevious()
        {
            Move(--_position);
        }
    }
}
