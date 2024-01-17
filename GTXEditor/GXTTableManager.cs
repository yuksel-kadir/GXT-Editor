using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GTXEditor
{
    public class GXTTableManager
    {
        /*
         * Base table dictionary. This dictionary holds all of the mission tables' key-value pairs.
         */
        private Dictionary<string, Dictionary<string, string>> baseDictionary = new Dictionary<string, Dictionary<string, string>>();        

        /*
         * Table dictionary. This dictionary holds key-value pairs of mission tables.
         * Like MAIN table and it's contents.
         */
        private Dictionary<string, string> currentDictionary;
        
        private DataGridView gxt_table;
        
        private int lastFoundRowIndex = -1;
        private string lastSearchKeyword = "";

        public GXTTableManager(DataGridView gxt_table)
        {
            this.gxt_table = gxt_table;
        }

        public Dictionary<string, Dictionary<string, string>> GetBaseDictionary()
        {
            return baseDictionary;
        }

        public void InitializeTable(DataGridView table)
        {
            table.VirtualMode = true;
            table.CellValueNeeded += GXTTable_CellValueNeeded;
            table.CellValuePushed += GXTTable_CellValuePushed;
        }

        private void GXTTable_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= this.currentDictionary.Count || e.RowIndex < 0)
                return;

            KeyValuePair<string, string> rowData = currentDictionary.ElementAt(e.RowIndex);

            if (e.ColumnIndex == 0)
            {
                e.Value = rowData.Key;
            }
            else if (e.ColumnIndex == 1)
            {
                e.Value = rowData.Value;
            }
        }

        private void GXTTable_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= this.currentDictionary.Count || e.RowIndex < 0)
                return;

            KeyValuePair<string, string> rowData = this.currentDictionary.ElementAt(e.RowIndex);

            if (e.ColumnIndex == 0)
            {
                rowData = new KeyValuePair<string, string>(e.Value.ToString(), rowData.Value);
            }
            else if (e.ColumnIndex == 1)
            {
                rowData = new KeyValuePair<string, string>(rowData.Key, e.Value.ToString());
            }

            // Update the data source with the new value
            this.currentDictionary[rowData.Key] = rowData.Value;
        }

        public void ClearBaseDictionary()
        {
            this.baseDictionary.Clear();
        }

        public void ClearTable()
        {
            this.gxt_table.Rows.Clear();
        }

        public void LoadSelectedMissionTableToDataGridView(string selectedTable)
        {
            this.currentDictionary = this.baseDictionary[selectedTable];
            this.gxt_table.RowCount = this.currentDictionary.Count;
        }

        public int FindGxtKey(string keyword)
        {            
            return SearchTableColumnAndSelectCell(keyword, Constants.GXT_KEY_COLUMN);
        }

        public int FindGxtValue(string keyword)
        {            
            return SearchTableColumnAndSelectCell(keyword, Constants.GXT_VALUE_COLUMN);
        }

        //0 -> GXT key, 1-> GXT value for columnIndex
        public int SearchTableColumnAndSelectCell(string keyword, int columnIndex)
        {
            if (keyword != lastSearchKeyword)
            {
                ResetLastSearchKeywordAndIndex(keyword);
            }

            int startRowIndex = lastFoundRowIndex + 1; // Start searching from the next row

            for (int rowIndex = startRowIndex; rowIndex < this.gxt_table.Rows.Count; rowIndex++)
            {
                if (this.gxt_table.Rows[rowIndex].Cells[columnIndex].Value != null &&
                    this.gxt_table.Rows[rowIndex].Cells[columnIndex].Value.ToString().ToLower().Contains(keyword.ToLower()))
                {
                    this.gxt_table.CurrentCell = this.gxt_table.Rows[rowIndex].Cells[columnIndex]; // Select the cell
                    this.gxt_table.FirstDisplayedScrollingRowIndex = rowIndex; // Scroll to the row
                    this.lastFoundRowIndex = rowIndex; // Update the last found index                                       
                    return this.lastFoundRowIndex; // Found and selected the row
                }
            }
            return -1;
        }
        public void ResetLastSearchKeywordAndIndex(string keyword)
        {
            this.lastSearchKeyword = keyword;
            this.lastFoundRowIndex = -1; // Reset the last found index
        }
    }
}
