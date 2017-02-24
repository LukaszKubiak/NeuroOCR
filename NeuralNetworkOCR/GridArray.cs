using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceGrid2.Cells.Virtual;

namespace NeuralNetworkOCR
{
    public partial class GridArray : SourceGrid2.GridVirtual
    {
        public GridArray()
        {
            InitializeComponent();
        }

        private CellVirtual columnHeader;
        private CellVirtual rowHeader;
        private CellVirtual cellHeader;
        private CellVirtual dataCell;
        private Array array;
        private bool readOnly = false;

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                RefreshCellsStyle();
            }
        }
        public void LoadData(Array array)
        {
            //
            this.array = array;
            FixedRows = 1;
            FixedColumns = 1;
            Redim(array.GetLength(0) + FixedRows, array.GetLength(1) + FixedColumns);
            columnHeader = new CellColumnHeaderTemplate();
            columnHeader.BindToGrid(this);
            rowHeader = new CellRowHeaderTemplate();
            rowHeader.BindToGrid(this);

            cellHeader = new CellHeaderTemplate();
            cellHeader.BindToGrid(this);

            dataCell = new CellArrayTemplate(array); ;
            dataCell.BindToGrid(this);

            RefreshCellsStyle();
        }
        public override SourceGrid2.Cells.ICellVirtual GetCell(int row, int col)
        {
            try
            {
                if (array != null)
                {
                    if ((row < FixedRows) && (col < FixedColumns))
                        return cellHeader;
                    else if (row < FixedRows)
                        return columnHeader;
                    else if (col < FixedColumns)
                        return rowHeader;
                    else
                        return dataCell;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public override void SetCell(int row, int col, SourceGrid2.Cells.ICellVirtual cell)
        {
            throw new ApplicationException("Cell error!");
        }
        private void RefreshCellsStyle()
        {
            if (dataCell != null)
            {
                dataCell.DataModel.EnableEdit = !readOnly;
            }
        }

        private class CellColumnHeaderTemplate : SourceGrid2.Cells.Virtual.ColumnHeader
        {
            public override object GetValue(SourceGrid2.Position position)
            {
                return position.Column - Grid.FixedColumns;
            }
            public override void SetValue(SourceGrid2.Position position, object val)
            {
                throw new ApplicationException("Cell error!");
            }
            public override SourceGrid2.SortStatus GetSortStatus(SourceGrid2.Position position)
            {
                return new SourceGrid2.SortStatus(SourceGrid2.GridSortMode.None, false);
            }
            public override void SetSortMode(SourceGrid2.Position position, SourceGrid2.GridSortMode mode)
            {
            }
        }
        private class CellRowHeaderTemplate : SourceGrid2.Cells.Virtual.RowHeader
        {
            public override object GetValue(SourceGrid2.Position position)
            {
                return position.Row - Grid.FixedRows;
            }
            public override void SetValue(SourceGrid2.Position position, object val)
            {
                throw new ApplicationException("Cell error!");
            }
        }

        private class CellHeaderTemplate : SourceGrid2.Cells.Virtual.Header
        {
            public override object GetValue(SourceGrid2.Position position)
            {
                return null;
            }
            public override void SetValue(SourceGrid2.Position position, object val)
            {
                throw new ApplicationException("Cell error!");
            }
        }

        public class CellArrayTemplate : SourceGrid2.Cells.Virtual.CellVirtual
        {
            private Array array;

            public CellArrayTemplate(Array array)
            {
                this.array = array;
                DataModel = SourceGrid2.Utility.CreateDataModel(array.GetType().GetElementType());
            }
            public override object GetValue(SourceGrid2.Position position)
            {
                return array.GetValue(position.Row - Grid.FixedRows, position.Column - Grid.FixedColumns);
            }
            public override void SetValue(SourceGrid2.Position position, object val)
            {
                array.SetValue(val, position.Row - Grid.FixedRows, position.Column - Grid.FixedColumns);
                OnValueChanged(new SourceGrid2.PositionEventArgs(position, this));
            }
        }
    }
}
